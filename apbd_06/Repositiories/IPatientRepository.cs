namespace apbd_06.Repositiories;

public interface IPatientRepository
{
    public Task<bool> IsPatientExist(int patientId);
}