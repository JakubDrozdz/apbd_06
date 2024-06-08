using apbd_06.Commands;

namespace apbd_06.Services;

public interface IPrescriptionService
{
    public Task<int> AddPrescription(AddPrescriptionCommand command);
}