namespace Models;
public class ServiceAgreement
{
    public required string AgreementId { get; set; }
    public required string PartnerId { get; set; }
    public required DateTime EffectiveDate { get; set; }
    public required DateTime ExpiryDate { get; set; }
    public required string Terms { get; set; }
}
