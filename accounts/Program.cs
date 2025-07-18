using Services;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
// Add services to the container.

services.AddCors(options =>
{
        options.AddPolicy(name: "AllowedOrigins",
            policy =>
            {
                    policy
                    .WithOrigins("https://localhost:8443") // For local dev only!!
                    .WithOrigins(
                        "https://*.zuplo.dev", // For demo environment in Zuplo
                        "https://*.akamai-apl.net") // For APIs hosted using Akamai AppPlatform
                        .SetIsOriginAllowedToAllowWildcardSubdomains();
            });
});
services.AddControllers()
        .AddXmlDataContractSerializerFormatters();

services.AddSingleton<ICustomerService, CustomerService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowedOrigins");


app.MapGet("/", () => "Jericalla Mobile API - Accounts");


app.UseHttpsRedirection();
app.MapControllers();
app.Run();
