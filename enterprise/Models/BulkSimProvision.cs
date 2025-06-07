namespace Models;

public class BulkSimProvision
{
    public required string RequestId { get; set; }
    public required string PartnerId { get; set; }
    public required int Quantity { get; set; }
    public required DateTime RequestedAt { get; set; }
}
