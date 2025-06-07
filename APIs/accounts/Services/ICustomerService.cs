using Models;

namespace Services;
public interface ICustomerService
{
    Customer GetCustomerById(string id);
    bool UpdateCustomer(string id, Customer customer);
    AccountUsage GetUsageByCustomerId(string id);
    bool ChangePlan(string customerId, string newPlanId);
}
