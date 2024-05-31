using apbd_06.Models;
using apbd_06.Models.DataTransferObjects;

namespace apbd_06.Commands;

public class AddPrescriptionCommand
{
    public PatientDto patient { get; set; }
    public int doctorId { get; set; }
    public IEnumerable<PrescriptionMedicamentDto> medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}