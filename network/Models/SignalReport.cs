namespace Models;
public class SignalReport
{
    public required string Location { get; set; }  // e.g., "CDMX" or lat/lng
    public required int SignalStrengthDbm { get; set; }  // e.g., -70
    public required string NetworkType { get; set; }  // 4G, 5G
}
