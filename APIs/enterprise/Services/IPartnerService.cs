using Models;
using System.Collections.Generic;

namespace Services;
public interface IEnterpriseService
{
    IEnumerable<Partner> GetPartners();
    IEnumerable<EnterpriseAccount> GetEnterpriseAccounts();
    IEnumerable<ServiceAgreement> GetAgreements();
    string ProvisionBulkSims(BulkSimProvision request);
}
