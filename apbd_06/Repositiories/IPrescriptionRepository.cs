using apbd_06.Commands;
using apbd_06.Models;

namespace apbd_06.Repositiories;

public interface IPrescriptionRepository
{
    public Task<Prescription> AddPrescription(AddPrescriptionCommand command);
}