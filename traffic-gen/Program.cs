HttpClient httpClient = new HttpClient();
List<string> endpoints = new List<string>
    {
        "v1/Customer/{0}",
        "v1/Customer/{0}/usage",
        "v1/Network/signal?location={0}",
        "v1/Network/roaming",
        "v1/Enterprise/partners",
        "v1/Enterprise/accounts",
        "v1/Enterprise/agreements",
        "v2/Customer/{0}",
        "v2/Customer/{0}/usage",
        "v2/Network/signal?location={0}",
        "v2/Network/roaming",
        "v2/Enterprise/partners",
        "v2/Enterprise/accounts",
        "v2/Enterprise/agreements",
        "v2/dummy"
    };

string baseUrl = Environment.GetEnvironmentVariable("API_BASE_URL")!;//Pointing to the API Manager URL;

Random random = new Random();


using var cts = new CancellationTokenSource();

Console.CancelKeyPress += (sender, e) =>
{
    Console.WriteLine("Stopping...");
    e.Cancel = true;
    cts.Cancel();
};

Console.WriteLine("Starting requests. Press Ctrl+C to stop.");
await StartRequestLoopAsync(cts.Token, random);


async Task StartRequestLoopAsync(CancellationToken cancellationToken, Random random)
{
    while (!cancellationToken.IsCancellationRequested)
    {
        _ = Task.Run(async () =>
        {
            string url = baseUrl + string.Format(GetRandomEndpoint(), random.Next(80, 120));
            try
            {
                Console.WriteLine("GET {0}", url);
                HttpResponseMessage response = await httpClient.GetAsync(url);
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {url} - Status: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calling {url}: {ex.Message}");
            }
        });

        await Task.Delay(500, cancellationToken);
    }
}

string GetRandomEndpoint()
{
    lock (random) // Random is not thread-safe
    {
        int index = random.Next(endpoints.Count);
        return endpoints[index];
    }
}

