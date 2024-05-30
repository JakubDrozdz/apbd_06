using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using apbd_06.Commands;

namespace apbd_06.Models;

[Table("Prescription")]
public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    [Required] 
    public DateTime Date { get; set; }
    [Required] 
    public DateTime DueDate { get; set; }
    [Required]
    [ForeignKey("Patient")]
    public int IdPatient { get; set; }
    [Required]
    [ForeignKey("Doctor")]
    public int IdDoctor { get; set; }
    
    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    public Prescription(){}

    public Prescription(AddPrescriptionCommand command)
    {
        this.Date = command.Date;
        this.DueDate = command.DueDate;
        this.IdPatient = command.patient.IdPatient;
        this.IdDoctor = 1;
    }
}