using Services;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
// Add services to the container.
services.AddControllers()
        .AddXmlDataContractSerializerFormatters();

services.AddSingleton<INetworkService, NetworkService>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();



app.MapGet("/", () => "Jericalla Mobile API - Network");


app.UseHttpsRedirection();
app.MapControllers();
app.Run();
