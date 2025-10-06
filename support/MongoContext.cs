using MongoDB.Driver;
using Models;
using Microsoft.Extensions.Options;


public class MongoContext
{
    private readonly IMongoDatabase _db;

    public void SeedData()
    {
        // Seed Tickets
        if (Tickets.CountDocuments(FilterDefinition<Ticket>.Empty) == 0)
        {
            Tickets.InsertMany(new[]
            {
                new Ticket { CustomerId="101", Subject = "Error de red", Description = "No puedo conectarme a 5G cuando viajo por la carretera", Status = "Open" },
                new Ticket { CustomerId="101", Subject = "Fallo de App", Description = "La aplicacion falla al intentar pagar mi factura", Status = "Closed" }
            });
        }

        // Seed OutageReports
        if (OutageReports.CountDocuments(FilterDefinition<OutageReport>.Empty) == 0)
        {
            OutageReports.InsertMany(new[]
            {
                new OutageReport { Region = "Urbana", Details = "Falla eléctrica en zona oriente", LastUpdated = DateTime.UtcNow.AddHours(-2) },
                new OutageReport { Region = "Carretera", Details = "Falla de conectividad 5G en carretera 57, tramo Los Chorros-Puerto México", LastUpdated = DateTime.UtcNow.AddHours(-1) }
            });
        }

    }
    public MongoContext(IOptions<MongoSettings> settings, ILogger<MongoContext> logger)
    {
        logger.LogInformation("MongoContext constructor called");

        // Uncomment the following lines if you want to use the settings from appsettings.json
        // var client = new MongoClient(settings.Value.ConnectionString);
        // _db = client.GetDatabase(settings.Value.DatabaseName);

        // Use environment variables for connection string and database name
        logger.LogInformation("Using environment variables for MongoDB connection");
    
        
        var connString = Environment.GetEnvironmentVariable("CONN_STRING");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        logger.LogInformation($"MongoDB name: {dbName}");

        var client = new MongoClient(connString);
        _db = client.GetDatabase(dbName);
    }

    public IMongoCollection<Ticket> Tickets =>
        _db.GetCollection<Ticket>("Tickets");

    public IMongoCollection<OutageReport> OutageReports =>
        _db.GetCollection<OutageReport>("OutageReports");

    public IMongoCollection<DeviceDiagnostics> DeviceDiagnostics =>
        _db.GetCollection<DeviceDiagnostics>("DeviceDiagnostics");
}
