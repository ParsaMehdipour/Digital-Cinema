using Application;
using Persistence;
using Serilog;
using SharedKernel;
using SharedKernel.DataProviderSettings.MongoDB;
using System.Reflection;
using WebApi.Endpoints;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;

#region Read data from environment variables or appsettings

var seqUrl = (Environment.GetEnvironmentVariable("SeqUrl") ?? configuration["SeqUrl"])!;

// Fetch mongo db settings from env or appsettings
MongoDbDatabaseSettings mongoDbDatabaseSettings = new()
{
    ConnectionString = (Environment.GetEnvironmentVariable("DomainEventsConnectionString.ConnectionString") ?? configuration["DomainEventsConnectionString:ConnectionString"])!,
    DatabaseName = (Environment.GetEnvironmentVariable("DomainEventsConnectionString.DatabaseName") ?? configuration["DomainEventsConnectionString:DatabaseName"])!,
};

var postgresConnectionString = (Environment.GetEnvironmentVariable("ApplicationConnectionString") ?? configuration["ApplicationConnectionString"])!;

#endregion

#region Serilog

// Enable SelfLog with a specified level (optional)
Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine($"----------------------[Serilog Internal]------------------ {msg}"));

builder.Host.UseSerilog((context, loggerConfig) =>
{
    loggerConfig.ReadFrom.Configuration(context.Configuration)
        .WriteTo.Console()
        .WriteTo.Seq(seqUrl);
});

#endregion

#region Setup dependency injections

// Set shared kernel dependencies
services.AddSharedKernel();

// Set persistence dependencies
services.AddPersistence(mongoDbDatabaseSettings.ConnectionString, postgresConnectionString);

// Set application dependencies
services.AddApplication();

#endregion

services.AddExceptionHandler<GlobalExceptionHandler>();
services.AddProblemDetails();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(sg =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    sg.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

SeedDatabase(app);

// Customer exception handler
app.UseExceptionHandler();

// Map Casts api endpoints
app.MapCastsApi();

app.Run();


// Seed data operations
static void SeedDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        logger.LogInformation("Initializing seed data ...");
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