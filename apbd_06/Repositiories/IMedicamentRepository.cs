using apbd_06.Models;

namespace apbd_06.Repositiories;

public interface IMedicamentRepository
{
    public Task<bool> IsMedicamentExist(int medicamentId);
    public Task<Medicament> GetMedicament(int medicamentId);
}