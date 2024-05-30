using apbd_06.Commands;
using apbd_06.Repositiories;
using Microsoft.EntityFrameworkCore.Storage;

namespace apbd_06.Services;

public class PrescriptionService(MainDbContext mainDbContext,
    IPrescriptionRepository prescriptionRepository,
    IMedicamentRepository medicamentRepository,
    IPatientRepository patientRepository) : IPrescriptionService
{
    public async Task<int> AddPrescription(AddPrescriptionCommand command)
    {
        using (IDbContextTransaction transaction = mainDbContext.Database.BeginTransaction())
        {
            //var dbTransaction = transaction.GetDbTransaction();
            try
            {
                if (command.medicaments.Count() > 10)
                {
                    //TODO: dedicated exception
                    throw new Exception("Too much medicaments on a prescription");
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
                        //TODO: dedicated exception
                        throw new Exception($"Medicament with ID {medicament.IdMedicament} does not exist");  
                    }
                }

                transaction.Commit();
                //dbTransaction.
                return 0;
            }
            finally
            {
                transaction.Rollback();
            }
        }
    }
}