using apbd_06.Commands;
using apbd_06.Models;
using apbd_06.Models.DataTransferObjects;

namespace apbd_06.Services;

public interface IPrescriptionMedicamentRepository
{
    public Task<PrescriptionMedicament> AddPrescription(PrescriptionMedicamentDto prescriptionMedicamentDto, int prescriptionId);
    
    public Task<List<PrescriptionMedicament>> GetMedicaments(int prescriptionId);
}