using apbd_06.Commands;
using apbd_06.Repositiories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Storage;

namespace apbd_06.Services;

public class PrescriptionService(MainDbContext mainDbContext,
    IPrescriptionRepository prescriptionRepository,
    IMedicamentRepository medicamentRepository,
    IPatientRepository patientRepository) : IPrescriptionService
{
    public async Task<int> AddPrescription(AddPrescriptionCommand command)
    {
        using (IDbContextTransaction transaction = mainDbContext.Database.BeginTransaction())
        {
            try
            {
                transaction.Commit();
                return 0;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return -1;
            }
        }
    }
}