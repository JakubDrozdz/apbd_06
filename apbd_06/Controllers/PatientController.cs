using apbd_06.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_06.Controllers;

[ApiController]
[Route("patients")]
public class PatientController(IPatientService patientService) : ControllerBase
{
    [HttpGet("{patientId}")]
    public async Task<IActionResult> GetPatientDetails(int patientId)
    {
        return Ok(await patientService.GetPatientDetails(patientId));
    }
}