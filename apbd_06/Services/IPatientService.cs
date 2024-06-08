using apbd_06.Models.DataTransferObjects;

namespace apbd_06.Services;

public interface IPatientService
{
    public Task<PatientDetailsDto> GetPatientDetails(int patientId);
}