using Models;
using Bogus;
using System.Collections.Concurrent;

namespace Services;

public class CustomerService: ICustomerService
{
    private static readonly ConcurrentDictionary<string, Customer> Customers = new();
    private static readonly ConcurrentDictionary<string, AccountUsage> UsageData = new();

    public Customer GetCustomerById(string id) => Customers.TryGetValue(id, out var customer) ? customer : null!;

    static CustomerService()
    {
        Console.WriteLine("****** Seeding data... *******");
        // Seed Customers
        var customerFaker = new Faker<Customer>("es_MX")
            .RuleFor(c => c.CustomerId, f => f.Random.Number(100, 199).ToString())
            .RuleFor(c => c.FullName, f => f.Name.FullName())
            .RuleFor(c => c.Email, f => f.Internet.ExampleEmail())
            .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(c => c.Address, f => f.Address.FullAddress());

        var usageFaker = new Faker<AccountUsage>()
            .RuleFor(u => u.DataUsedGB, f => Math.Round(f.Random.Double(0.1, 20.0), 2))
            .RuleFor(u => u.MinutesUsed, f => f.Random.Number(0, 1000))
            .RuleFor(u => u.SMSUsed, f => f.Random.Number(0, 500));

        var existingIds = new HashSet<string>();

        while (Customers.Count < 100)
        {
            var customer = customerFaker.Generate();
            if (existingIds.Contains(customer.CustomerId)) continue;

            existingIds.Add(customer.CustomerId);
            Customers[customer.CustomerId] = customer;

            var usage = usageFaker.Generate();
            usage.CustomerId = customer.CustomerId;
            UsageData[customer.CustomerId] = usage;
        }
    }
    public bool UpdateCustomer(string id, Customer customer)
    {
        if (!Customers.ContainsKey(id)) return false;
        Customers[id] = customer;
        return true;
    }

    public AccountUsage GetUsageByCustomerId(string id) => UsageData.TryGetValue(id, out var usage) ? usage : null!;

    public bool ChangePlan(string customerId, string newPlanId)
    {
        // Stub logic
        return Customers.ContainsKey(customerId);
    }
}
