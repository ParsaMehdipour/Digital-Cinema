using NLog;
using Persistence;
using SharedKernel;
using SharedKernel.DataProviderSettings.MongoDB;
using SharedKernel.Logging;

var builder = WebApplication.CreateBuilder(args);

var nlogFile = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != null ? $"NLog.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.config" : "NLog.config";

LogManager.LoadConfiguration(nlogFile);

// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;

#region Read data from environment variables or appsettings

//Fetch mongo db settings from env or appsettings
MongoDbDatabaseSettings mongoDbDatabaseSettings = new()
{
    ConnectionString = (Environment.GetEnvironmentVariable("DomainEventsConnectionString.ConnectionString") ?? configuration["DomainEventsConnectionString:ConnectionString"])!,
    DatabaseName = (Environment.GetEnvironmentVariable("DomainEventsConnectionString.DatabaseName") ?? configuration["DomainEventsConnectionString:DatabaseName"])!,
};

var postgresConnectionString = (Environment.GetEnvironmentVariable("ApplicationConnectionString") ?? configuration["ApplicationConnectionString"])!;

#endregion

#region Setup dependency injections

//Set shared kernel dependencies
services.AddSharedKernel();

//Set persistence dependencies
services.AddPersistence(mongoDbDatabaseSettings.ConnectionString, postgresConnectionString);

#endregion

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

SeedDatabase(app);

app.Run();


static void SeedDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILoggerManager>();

    try
    {
        logger.LogInfo("Initializing seed data ...");
        var context = services.GetRequiredService<ApplicationDbContext>();
        //                    context.Database.Migrate();
        context.Database.EnsureCreated();
        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        logger.LogError($"An error occurred seeding the DB. {ex.Message}");
    }
}