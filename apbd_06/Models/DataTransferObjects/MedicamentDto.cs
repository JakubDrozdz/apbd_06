namespace apbd_06.Models.DataTransferObjects;

public class MedicamentDto
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public int Dose { get; set; }
    public string Description { get; set; }
    
    public MedicamentDto(){}

    public MedicamentDto(PrescriptionMedicament prescriptionMedicament, Medicament medicament)
    {
        this.IdMedicament = medicament.IdMedicament;
        this.Name = medicament.Name;
        this.Dose = prescriptionMedicament.Dose;
        this.Description = medicament.Description;
    }
}