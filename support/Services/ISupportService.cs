using Models;
using System.Collections.Generic;
namespace Services;
public interface ISupportService
{
    Ticket FileTicket(Ticket ticket);
    Ticket GetTicket(string ticketId);
    IEnumerable<Ticket> GetAllTickets();

    OutageReport GetOutageStatus(string region);
    DeviceDiagnostics GetDeviceDiagnostics(string deviceId);
}
