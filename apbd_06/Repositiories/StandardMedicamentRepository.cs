using apbd_06.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_06.Repositiories;

public class StandardMedicamentRepository(MainDbContext mainDbContext) : IMedicamentRepository
{
    public async Task<bool> IsMedicamentExist(int medicamentId)
    {
        return await mainDbContext.Medicaments.Where(m => m.IdMedicament == medicamentId).FirstOrDefaultAsync() != null;
    }

    public async Task<Medicament> GetMedicament(int medicamentId)
    {
        return await mainDbContext.Medicaments.Where(m => m.IdMedicament == medicamentId).FirstOrDefaultAsync();
    }
}