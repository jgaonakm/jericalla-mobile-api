using Models;
using MongoDB.Driver;

using System.Collections.Concurrent;
namespace Services;

public class SupportService : ISupportService
{
    private readonly MongoContext _context;

    public SupportService(MongoContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new ticket by assigning a unique TicketId, setting the creation date to the current UTC time,
    /// initializing the ticket status to "Open", and inserting the ticket into the database.
    /// </summary>
    /// <param name="ticket">The <see cref="Ticket"/> object to be filed.</param>
    /// <returns>The filed <see cref="Ticket"/> object with updated properties.</returns>
    /// <example>
    /// Example of a generated ticket:
    /// TicketId: "665f9c2e7b3e2a1f8c9d1234"
    /// CreatedAt: 2024-06-10T14:23:45Z
    /// Status: "Open"
    /// </example>
    public Ticket FileTicket(Ticket ticket)
    {
        ticket.CreatedAt = DateTime.UtcNow;
        ticket.Status = "Open";
        _context.Tickets.InsertOne(ticket);
        return ticket;
    }

    public Ticket GetTicket(string ticketId)
    {

        return _context.Tickets.Find(t => t.TicketId == ticketId).FirstOrDefault();
    }

    public IEnumerable<Ticket> GetAllTickets()
    {
        return _context.Tickets.Find(_ => true).ToList();
    }


    public IEnumerable<Ticket> GetAllTickets(string customerId)
    {   
        return _context.Tickets.Find(t => t.CustomerId == customerId).ToList();
    }

    public OutageReport GetOutageStatus(string region)
    {
        return _context.OutageReports.Find(r => r.Region == region).FirstOrDefault()
                   ?? new OutageReport { Region = region, HasOutage = false, Details = "No data", LastUpdated = DateTime.UtcNow };
    }

    public DeviceDiagnostics GetDeviceDiagnostics(string deviceId)
    {
        return _context.DeviceDiagnostics.Find(d => d.DeviceId == deviceId).FirstOrDefault();
    }
}
