namespace Models;
public class SignalReport
{
    public string Location { get; set; }  // e.g., "CDMX" or lat/lng
    public int SignalStrengthDbm { get; set; }  // e.g., -70
    public string NetworkType { get; set; }  // 4G, 5G
}
