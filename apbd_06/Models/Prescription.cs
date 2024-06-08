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
    public int IdPatient { get; set; }
    [Required]
    public int IdDoctor { get; set; }
    
    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    [ForeignKey("IdPatient")]
    public virtual Patient Patient { get; set; }

    [ForeignKey("IdDoctor")]
    public virtual Doctor Doctor { get; set; }
    
    public Prescription(){}

    public Prescription(AddPrescriptionCommand command)
    {
        this.Date = command.Date;
        this.DueDate = command.DueDate;
        this.IdPatient = command.patient.IdPatient;
        this.IdDoctor = command.doctorId;
    }
}