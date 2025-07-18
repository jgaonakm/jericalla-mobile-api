namespace Models;

public class Payments
{
    public required string CustomerId { get; set; }
    public double Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string TransactionId { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}