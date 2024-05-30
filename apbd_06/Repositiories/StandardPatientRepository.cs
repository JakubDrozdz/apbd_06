using apbd_06.Models;
using apbd_06.Models.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace apbd_06.Repositiories;

public class StandardPatientRepository(MainDbContext mainDbContext) : IPatientRepository
{
    public async Task<Patient> IsPatientExist(PatientDto patient)
    {
        return await mainDbContext.Patients.Where(p => 
            p.IdPatient == patient.IdPatient && 
            p.Birthdate.Date.Equals(patient.Birthdate.Date) && 
            p.FirstName.Equals(patient.FirstName) && 
            p.LastName.Equals(patient.LastName)
        ).FirstOrDefaultAsync();
    }

    public async Task<Patient> AddPatient(PatientDto patient)
    {
        Patient persistedPatient = (await mainDbContext.Patients.AddAsync(new Patient(patient))).Entity;
        await mainDbContext.SaveChangesAsync();
        return persistedPatient;
    }

    public async Task<Patient> GetPatientDetails(int patientId)
    {
        return await mainDbContext.Patients.Include(np => np.Prescriptions).Where(p => p.IdPatient == patientId).FirstOrDefaultAsync();
    }
}