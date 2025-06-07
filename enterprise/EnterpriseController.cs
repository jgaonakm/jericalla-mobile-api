using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

[ApiController]
[Route("api/{version}/[controller]")]
public class EnterpriseController : ControllerBase
{
    private readonly IEnterpriseService _service;

    public EnterpriseController(IEnterpriseService service)
    {
        _service = service;
    }

    [HttpGet("partners")]
    public IActionResult GetPartners() => Ok(_service.GetPartners());

    [HttpGet("accounts")]
    public IActionResult GetAccounts() => Ok(_service.GetEnterpriseAccounts());

    [HttpPost("sim/provision")]
    public IActionResult ProvisionSims([FromBody] BulkSimProvision request)
    {
        var id = _service.ProvisionBulkSims(request);
        return Ok(new { requestId = id });
    }

    [HttpGet("agreements")]
    public IActionResult GetAgreements() => Ok(_service.GetAgreements());
}
