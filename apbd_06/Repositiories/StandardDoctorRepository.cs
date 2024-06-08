using apbd_06.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_06.Repositiories;

public class StandardDoctorRepository(MainDbContext mainDbContext) : IDoctorRepository
{
    public async Task<Doctor> GetDoctor(int doctorId)
    {
        return await mainDbContext.Doctors.Where(d => d.IdDoctor == doctorId).FirstOrDefaultAsync();
    }
}