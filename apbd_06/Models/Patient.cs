using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using apbd_06.Models.DataTransferObjects;

namespace apbd_06.Models;

[Table("Patient")]
public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [Required]
    public DateTime Birthdate { get; set; }
    
    public virtual ICollection<Prescription> Prescriptions { get; set; }

    public Patient(){}
    public Patient(PatientDto patientDto)
    {
        this.FirstName = patientDto.FirstName;
        this.LastName = patientDto.LastName;
        this.Birthdate = patientDto.Birthdate.Date;
    }
}