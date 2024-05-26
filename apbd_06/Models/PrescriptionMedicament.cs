using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_06.Models;

[Table("Prescription_Medicament")]
public class PrescriptionMedicament
{
    [Key]
    [ForeignKey("Medicament")]
    public Medicament IdMedicament { get; set; }
    [Key]
    [ForeignKey("Medicament")]
    public Prescription IdPrescription { get; set; }
    public int Dose { get; set; }
    [Required]
    [MaxLength(100)]
    public string Details { get; set; }
}