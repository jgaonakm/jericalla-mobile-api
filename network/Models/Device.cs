namespace Models;
public class Device
{
    public required string DeviceId { get; set; }
    public required string Model { get; set; }
    public required string SimId { get; set; }
    public required DateTime RegisteredAt { get; set; }
}
