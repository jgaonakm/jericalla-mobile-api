using Models;
using System.Collections.Concurrent;
namespace Services;
public class SupportService : ISupportService
{
    private static readonly ConcurrentDictionary<string, Ticket> Tickets = new();
    private static readonly ConcurrentDictionary<string, OutageReport> Outages = new();
    private static readonly ConcurrentDictionary<string, DeviceDiagnostics> Diagnostics = new();

    public SupportService()
    {
        // Seed with sample data
        Outages["CDMX"] = new OutageReport { Region = "CDMX", HasOutage = false, Details = "All systems normal.", LastUpdated = DateTime.UtcNow };
        Diagnostics["device-1001"] = new DeviceDiagnostics
        {
            DeviceId = "device-1001",
            BatteryLevelPercent = 78,
            SignalStrengthDbm = -62,
            CpuLoadPercent = 34.5,
            Timestamp = DateTime.UtcNow
        };
    }

    public Ticket FileTicket(Ticket ticket)
    {
        ticket.TicketId = Guid.NewGuid().ToString();
        ticket.CreatedAt = DateTime.UtcNow;
        ticket.Status = "Open";
        Tickets[ticket.TicketId] = ticket;
        return ticket;
    }

    public Ticket GetTicket(string ticketId)
    {
        return Tickets.TryGetValue(ticketId, out var ticket) ? ticket : null;
    }

    public IEnumerable<Ticket> GetAllTickets()
    {
        return Tickets.Values;
    }

    public OutageReport GetOutageStatus(string region)
    {
        return Outages.TryGetValue(region, out var report) ? report : new OutageReport
        {
            Region = region,
            HasOutage = false,
            Details = "No information available.",
            LastUpdated = DateTime.UtcNow
        };
    }

    public DeviceDiagnostics GetDeviceDiagnostics(string deviceId)
    {
        return Diagnostics.TryGetValue(deviceId, out var diag) ? diag : null;
    }
}
