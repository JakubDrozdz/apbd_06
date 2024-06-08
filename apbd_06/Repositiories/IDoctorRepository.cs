using apbd_06.Models;

namespace apbd_06.Repositiories;

public interface IDoctorRepository
{
    public Task<Doctor> GetDoctor(int doctorId);
}