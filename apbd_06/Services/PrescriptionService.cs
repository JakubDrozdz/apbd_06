using apbd_06.Commands;
using apbd_06.Exceptions;
using apbd_06.Repositiories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;

namespace apbd_06.Services;

public class PrescriptionService(MainDbContext mainDbContext,
    IPrescriptionRepository prescriptionRepository,
    IPrescriptionMedicamentRepository prescriptionMedicamentRepository,
    IMedicamentRepository medicamentRepository,
    IPatientRepository patientRepository,
    IDoctorRepository doctorRepository) : IPrescriptionService
{
    public async Task<int> AddPrescription(AddPrescriptionCommand command)
    {
        using (IDbContextTransaction transaction = mainDbContext.Database.BeginTransaction())
        {
            try
            {
                if (command.medicaments.Count() > 10)
                {
                    throw new InvalidPrescriptionRequestException("Too much medicaments on a prescription");
                }

                var patient = await patientRepository.IsPatientExist(command.patient);
                if (patient == null)
                {
                    patient = await patientRepository.AddPatient(command.patient);
                }

                foreach (var medicament in command.medicaments)
                {
                    if (!await medicamentRepository.IsMedicamentExist(medicament.IdMedicament))
                    {
                        throw new InvalidPrescriptionRequestException($"Medicament with ID {medicament.IdMedicament} does not exist");  
                    }
                }

                if (command.DueDate.Date < command.Date.Date)
                {
                    throw new InvalidPrescriptionRequestException("Due date is invalid");  
                }

                if (await doctorRepository.GetDoctor(command.doctorId) == null)
                {
                    throw new InvalidPrescriptionRequestException($"Doctor with ID {command.doctorId} not exists");
                }

                command.patient.IdPatient = patient.IdPatient;
                var prescription = prescriptionRepository.AddPrescription(command);
                foreach (var prescriptionMedicamentDto in command.medicaments)
                {
                    await prescriptionMedicamentRepository.AddPrescription(prescriptionMedicamentDto, prescription.Result.IdPrescription);
                }
                
                
                transaction.Commit();
                return prescription.Result.IdPrescription;
            }
            finally
            {
                try
                {
                    transaction.Rollback();
                } catch(Exception sqlEx){}
            }
        }
    }
}