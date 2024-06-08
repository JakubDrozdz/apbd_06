using apbd_06.Models;
using apbd_06.Models.DataTransferObjects;

namespace apbd_06.Repositiories;

public interface IPatientRepository
{
    public Task<Patient> IsPatientExist(PatientDto patient);
    
    public Task<Patient> AddPatient(PatientDto patient);
    
    public Task<Patient> GetPatientDetails(int patientId);
}