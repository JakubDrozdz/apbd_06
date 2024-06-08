using apbd_06.Commands;
using apbd_06.Models;
using apbd_06.Models.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace apbd_06.Services;

public class PrescriptionMedicamentRepository(MainDbContext mainDbContext) : IPrescriptionMedicamentRepository
{
    public async Task<PrescriptionMedicament> AddPrescription(PrescriptionMedicamentDto prescriptionMedicamentDto, int prescriptionId)
    {
        PrescriptionMedicament persistedPrescriptionMedicament = (await mainDbContext.PrescriptionMedicaments.AddAsync(new PrescriptionMedicament(prescriptionMedicamentDto, prescriptionId))).Entity;
        await mainDbContext.SaveChangesAsync();
        return persistedPrescriptionMedicament;
    }

    public async Task<List<PrescriptionMedicament>> GetMedicaments(int prescriptionId)
    {
        return await mainDbContext.PrescriptionMedicaments.Where(pm => pm.IdPrescription == prescriptionId).ToListAsync();
    }
}