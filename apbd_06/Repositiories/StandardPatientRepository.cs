using Microsoft.EntityFrameworkCore;

namespace apbd_06.Repositiories;

public class StandardPatientRepository(MainDbContext mainDbContext) : IPatientRepository
{
    public async Task<bool> IsPatientExist(int patientId)
    {
        return await mainDbContext.Patients.Where(p => p.IdPatient == patientId).FirstOrDefaultAsync() != null;
    }
}