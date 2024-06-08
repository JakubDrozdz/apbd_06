using apbd_06.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_06;

public class MainDbContext : DbContext
{
    public MainDbContext()
    {
        
    }

    public MainDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        dbContextOptionsBuilder.UseSqlServer("Data Source=db-mssql.pjwstk.edu.pl;Initial Catalog=S24871;Integrated Security=True;TrustServerCertificate=True");
    }
}