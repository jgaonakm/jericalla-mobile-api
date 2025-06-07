namespace Models;
public class EnterpriseAccount
{
    public required string AccountId { get; set; }
    public required string PartnerId { get; set; }
    public required string CompanyName { get; set; }
    public required string Industry { get; set; }
    public required int TotalLines { get; set; }
}
