namespace apbd_06.Models.DataTransferObjects;

public class PatientDetailsDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public IEnumerable<PrescriptionDto> Prescriptions { get; set; }
}