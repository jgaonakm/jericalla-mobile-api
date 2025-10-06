using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Models;


public class Ticket
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? TicketId { get; set; }
    public string CustomerId { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? Status { get; set; }
}
