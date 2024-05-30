using apbd_06.Commands;
using apbd_06.Models;

namespace apbd_06.Repositiories;

public class StandardPrescriptionRepository(MainDbContext mainDbContext) : IPrescriptionRepository
{
    public async Task<Prescription> AddPrescription(AddPrescriptionCommand command)
    {
        Prescription persistedPrescription = (await mainDbContext.Prescriptions.AddAsync(new Prescription(command))).Entity;
        await mainDbContext.SaveChangesAsync();
        return persistedPrescription;
    }
}