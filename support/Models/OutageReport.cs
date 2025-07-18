namespace Models;
public class OutageReport
{
    public string Region { get; set; }
    public bool HasOutage { get; set; }
    public string Details { get; set; }
    public DateTime LastUpdated { get; set; }
}
