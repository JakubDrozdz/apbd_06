using apbd_06.Commands;
using Microsoft.AspNetCore.Mvc;

namespace apbd_06.Controllers;

[ApiController]
[Route("prescriptions")]
public class PrescriptionController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddPrescription(AddPrescriptionCommand command)
    {
        return Ok();
    }
}