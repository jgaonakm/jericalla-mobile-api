using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Models;

public class DeviceDiagnostics
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string DeviceId { get; set; }
    public int BatteryLevelPercent { get; set; }
    public int SignalStrengthDbm { get; set; }
    public double CpuLoadPercent { get; set; }
    public DateTime Timestamp { get; set; }
}
