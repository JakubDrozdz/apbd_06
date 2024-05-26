using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd_06.Models;

[Table("Prescription_Medicament")]
[PrimaryKey(nameof(IdMedicament),nameof(IdPrescription))]
public class PrescriptionMedicament
{
    [ForeignKey("Medicament")]
    public int IdMedicament { get; set; }
    [ForeignKey("Medicament")]
    public int IdPrescription { get; set; }
    public int Dose { get; set; }
    [Required]
    [MaxLength(100)]
    public string Details { get; set; }
}