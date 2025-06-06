using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _service;

    public CustomerController()
    {
        _service = new();
    }

    [HttpGet("{id}")]
    public ActionResult<Customer> GetCustomer(string id)
    {
        var customer = _service.GetCustomerById(id);
        if (customer == null)
            return NotFound();
        return Ok(customer);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(string id, [FromBody] Customer updatedCustomer)
    {
        var success = _service.UpdateCustomer(id, updatedCustomer);
        if (!success)
            return NotFound();
        return NoContent();
    }

    [HttpGet("{id}/usage")]
    public ActionResult<AccountUsage> GetUsage(string id)
    {
        var usage = _service.GetUsageByCustomerId(id);
        if (usage == null)
            return NotFound();
        return Ok(usage);
    }

    [HttpPost("{id}/change-plan")]
    public IActionResult ChangePlan(string id, [FromQuery] string newPlanId)
    {
        var success = _service.ChangePlan(id, newPlanId);
        if (!success)
            return BadRequest("Invalid plan or customer ID.");
        return Ok("Plan changed successfully.");
    }
}
