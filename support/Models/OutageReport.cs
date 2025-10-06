using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Models;

public class OutageReport
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ReportId { get; set; }
    public string Region { get; set; }
    public bool HasOutage { get; set; }
    public string Details { get; set; }
    public DateTime LastUpdated { get; set; }
}
