using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_06.Models;

[Table("Prescription")]
public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    [Required] 
    public DateOnly Date { get; set; }
    [Required] 
    public DateOnly DueDate { get; set; }
    [Required]
    [ForeignKey("Patient")]
    public int IdPatient { get; set; }
    [Required]
    [ForeignKey("Doctor")]
    public int IdDoctor { get; set; }
    
    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}