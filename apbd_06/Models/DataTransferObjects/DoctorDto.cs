namespace apbd_06.Models.DataTransferObjects;

public class DoctorDto
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
    
    public DoctorDto(){}

    public DoctorDto(Doctor doctor)
    {
        this.IdDoctor = doctor.IdDoctor;
        this.FirstName = doctor.FirstName;
    }
}