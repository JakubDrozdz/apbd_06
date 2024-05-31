using apbd_06.Exceptions;
using apbd_06.Models.DataTransferObjects;
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
        PatientDetailsDto response;
        try
        {
            response = await patientService.GetPatientDetails(patientId);
        }
        catch (InvalidPatientRequestException e)
        {
            return BadRequest(e.Message);
        }
        return Ok(response);
    }
}