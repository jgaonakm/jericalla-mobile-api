using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var services = builder.Services;

services.AddControllers()
        .AddXmlDataContractSerializerFormatters();

services.AddScoped<ISupportService, SupportService>();
services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));
services.AddSingleton<MongoContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => "Jericalla Mobile API - Support");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();


