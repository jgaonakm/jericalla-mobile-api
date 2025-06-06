namespace Models;

public class Partner
{
    public required string PartnerId { get; set; }
    public required string CompanyName { get; set; }
    public required string ContactEmail { get; set; }
    public required string ApiKey { get; set; }
    public required DateTime RegisteredAt { get; set; }
}
