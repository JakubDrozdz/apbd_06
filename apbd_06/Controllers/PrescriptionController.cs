using apbd_06.Commands;
using apbd_06.Exceptions;
using apbd_06.Models;
using apbd_06.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_06.Controllers;

[ApiController]
[Route("prescriptions")]
public class PrescriptionController(IPrescriptionService prescriptionService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddPrescription(AddPrescriptionCommand command)
    {
        int response;
        try
        {
            response = await prescriptionService.AddPrescription(command);
        }
        catch (InvalidPrescriptionRequestException e)
        {
            return BadRequest(e.Message);
        }
        return Ok("ID: " + response);
    }
}