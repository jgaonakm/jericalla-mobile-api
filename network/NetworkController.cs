using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

[ApiController]
[Route("api/[controller]")]
public class NetworkController : ControllerBase
{
    private readonly INetworkService _service;

    public NetworkController(INetworkService service)
    {
        _service = service;
    }

    [HttpGet("signal")]
    public ActionResult<SignalReport> GetSignal([FromQuery] string location)
    {
        var result = _service.CheckSignal(location);
        return Ok(result);
    }

    [HttpPost("sim/activate")]
    public IActionResult ActivateSim([FromQuery] string simId)
    {
        var success = _service.ActivateSim(simId);
        return success ? Ok("SIM activated") : NotFound();
    }

    [HttpPost("sim/deactivate")]
    public IActionResult DeactivateSim([FromQuery] string simId)
    {
        var success = _service.DeactivateSim(simId);
        return success ? Ok("SIM deactivated") : NotFound();
    }

    [HttpPost("device/register")]
    public IActionResult RegisterDevice([FromBody] Device device)
    {
        var success = _service.RegisterDevice(device);
        return success ? Ok("Device registered") : BadRequest();
    }

    [HttpGet("roaming")]
    public ActionResult<RoamingStatus> GetRoaming([FromQuery] string simId)
    {
        var status = _service.GetRoamingStatus(simId);
        return status != null ? Ok(status) : NotFound();
    }

    [HttpPost("roaming/update")]
    public IActionResult UpdateRoaming([FromQuery] string simId, [FromQuery] bool enable)
    {
        var success = _service.UpdateRoamingStatus(simId, enable);
        return success ? Ok("Roaming status updated") : NotFound();
    }
}
