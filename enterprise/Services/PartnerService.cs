using Bogus;
using Models;
using System.Collections.Concurrent;

namespace Services;
public class EnterpriseService : IEnterpriseService
{
    private static readonly ConcurrentDictionary<string, Partner> Partners = new();
    private static readonly ConcurrentDictionary<string, EnterpriseAccount> Accounts = new();
    private static readonly ConcurrentDictionary<string, ServiceAgreement> Agreements = new();
    private static readonly ConcurrentDictionary<string, BulkSimProvision> SimRequests = new();

    public EnterpriseService()
    {
        var partnerFaker = new Faker<Partner>("es_MX")
            .RuleFor(p => p.PartnerId, f => f.Random.Guid().ToString())
            .RuleFor(p => p.CompanyName, f => f.Company.CompanyName())
            .RuleFor(p => p.ContactEmail, f => f.Internet.Email())
            .RuleFor(p => p.ApiKey, f => f.Random.AlphaNumeric(32))
            .RuleFor(p => p.RegisteredAt, f => f.Date.Past(3));

        var partners = partnerFaker.Generate(10);
        foreach (var p in partners)
        {
            Partners[p.PartnerId] = p;

            var account = new EnterpriseAccount
            {
                AccountId = Guid.NewGuid().ToString(),
                PartnerId = p.PartnerId,
                CompanyName = p.CompanyName,
                Industry = new[] { "Retail", "Finance", "Transport", "Healthcare" }[new Random().Next(4)],
                TotalLines = new Random().Next(10, 1000)
            };
            Accounts[account.AccountId] = account;

            var agreement = new ServiceAgreement
            {
                AgreementId = Guid.NewGuid().ToString(),
                PartnerId = p.PartnerId,
                EffectiveDate = DateTime.UtcNow.AddMonths(-12),
                ExpiryDate = DateTime.UtcNow.AddMonths(12),
                Terms = "Standard enterprise service agreement terms."
            };
            Agreements[agreement.AgreementId] = agreement;
        }
    }

    public IEnumerable<Partner> GetPartners() => Partners.Values;
    public IEnumerable<EnterpriseAccount> GetEnterpriseAccounts() => Accounts.Values;
    public IEnumerable<ServiceAgreement> GetAgreements() => Agreements.Values;

    public string ProvisionBulkSims(BulkSimProvision request)
    {
        request.RequestId = Guid.NewGuid().ToString();
        request.RequestedAt = DateTime.UtcNow;
        SimRequests[request.RequestId] = request;
        return request.RequestId;
    }
}
