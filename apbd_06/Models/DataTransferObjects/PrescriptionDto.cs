namespace apbd_06.Models.DataTransferObjects;

public class PrescriptionDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public IEnumerable<MedicamentDto> Medicaments { get; set; }
    public DoctorDto Doctor { get; set; }
}