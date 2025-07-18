using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Models;
using Services;

[ApiController]
[Route("api/{version}/[controller]")]
public class SupportController : ControllerBase
{
    private readonly ISupportService _service;

    public SupportController(ISupportService service)
    {
        _service = service;
    }

    [HttpPost("ticket")]
    public ActionResult<Ticket> FileTicket([FromBody] Ticket ticket)
    {
        return Ok(_service.FileTicket(ticket));
    }

    [HttpGet("ticket/{id}")]
    public ActionResult<Ticket> GetTicket(string id)
    {
        var ticket = _service.GetTicket(id);
        return ticket != null ? Ok(ticket) : NotFound();
    }

    [HttpGet("tickets")]
    public ActionResult<IEnumerable<Ticket>> GetAllTickets()
    {
        return Ok(_service.GetAllTickets());
    }

    [HttpGet("outage")]
    public ActionResult<OutageReport> CheckOutage([FromQuery] string region)
    {
        return Ok(_service.GetOutageStatus(region));
    }

    [HttpGet("diagnostics/{deviceId}")]
    public ActionResult<DeviceDiagnostics> GetDiagnostics(string deviceId)
    {
        var diag = _service.GetDeviceDiagnostics(deviceId);
        return diag != null ? Ok(diag) : NotFound();
    }
}
