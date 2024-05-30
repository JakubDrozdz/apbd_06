using apbd_06;
using apbd_06.Repositiories;
using apbd_06.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
builder.Services.AddScoped<IPrescriptionRepository, StandardPrescriptionRepository>();
builder.Services.AddScoped<IPatientRepository, StandardPatientRepository>();
builder.Services.AddScoped<IMedicamentRepository, StandardMedicamentRepository>();
builder.Services.AddScoped<IPrescriptionMedicamentRepository, PrescriptionMedicamentRepository>();
builder.Services.AddScoped<MainDbContext, MainDbContext>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorRepository, StandardDoctorRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();