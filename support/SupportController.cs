using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Models;
using Services;

[ApiController]
[Route("api/{version}/[controller]")]
public class SupportController : ControllerBase
{
    private readonly ISupportService _service;
    private readonly ILogger<SupportController> _logger;

    public SupportController(ISupportService service, ILogger<SupportController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost("ticket")]
    public ActionResult<Ticket> FileTicket([FromBody] Ticket ticket)
    {
        _logger.LogInformation("Filing a new support ticket");
        return Ok(_service.FileTicket(ticket));
    }

    [HttpGet("ticket/{id}")]
    public ActionResult<Ticket> GetTicket(string id)
    {
        _logger.LogInformation($"Retrieving ticket with ID: {id}");
        var ticket = _service.GetTicket(id);
        return ticket != null ? Ok(ticket) : NotFound();
    }

    [HttpGet("tickets")]
    public ActionResult<IEnumerable<Ticket>> GetAllTickets()
    {
        _logger.LogInformation("Retrieving all support tickets");
        return Ok(_service.GetAllTickets());
    }

    [HttpGet("tickets/customer/{customerId}")]
    public ActionResult<IEnumerable<Ticket>> GetAllTicketsForCustomer(int customerId)
    {
        _logger.LogInformation($"Retrieving all tickets for customer ID: {customerId}");
        return Ok(_service.GetAllTickets(customerId.ToString()));
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
