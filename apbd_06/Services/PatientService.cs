using apbd_06.Exceptions;
using apbd_06.Models;
using apbd_06.Models.DataTransferObjects;
using apbd_06.Repositiories;

namespace apbd_06.Services;

public class PatientService(IPatientRepository patientRepository,
    IPrescriptionMedicamentRepository prescriptionMedicamentRepository,
    IDoctorRepository doctorRepository,
    IMedicamentRepository medicamentRepository) : IPatientService
{
    public async Task<PatientDetailsDto> GetPatientDetails(int patientId)
    {
        PatientDetailsDto patientDetailsDto = new PatientDetailsDto();
        var patient = await patientRepository.GetPatientDetails(patientId);
        if (patient == null)
        {
            throw new InvalidPatientRequestException("Patient does not exist");
        }

        patientDetailsDto.IdPatient = patient.IdPatient;
        patientDetailsDto.FirstName = patient.FirstName;
        patientDetailsDto.LastName = patient.LastName;
        patientDetailsDto.Birthdate = patient.Birthdate;

        var prescriptionsForPatient = new List<PrescriptionDto>();
        var prescriptions = patient.Prescriptions;
        foreach (var prescription in prescriptions)
        {
            PrescriptionDto prescriptionDto = new PrescriptionDto();
            prescriptionDto.IdPrescription = prescription.IdPrescription;
            prescriptionDto.DueDate = prescription.DueDate;
            prescriptionDto.Date = prescription.Date;
            var medicaments = new List<MedicamentDto>();
            var prescriptionMedicaments = await prescriptionMedicamentRepository.GetMedicaments(prescription.IdPrescription) ;
            foreach (var prescriptionMedicament in prescriptionMedicaments)
            {
                var medicament = await medicamentRepository.GetMedicament(prescriptionMedicament.IdMedicament);
                medicaments.Add(new MedicamentDto(prescriptionMedicament, medicament));
            }
            prescriptionDto.Medicaments = medicaments;
            prescriptionDto.Doctor = new DoctorDto(await doctorRepository.GetDoctor(prescription.IdDoctor));
            prescriptionsForPatient.Add(prescriptionDto);
        }

        patientDetailsDto.Prescriptions = prescriptionsForPatient;
        return patientDetailsDto;
    }
}