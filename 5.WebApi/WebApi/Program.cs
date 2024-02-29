using Persistence;
using SharedKernel;
using SharedKernel.DataProviderSettings.MongoDB;

var builder = WebApplication.CreateBuilder(args);

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

#endregion

#region Setup dependency injections

//Set shared kernel dependencies
services.AddSharedKernel();

//Set persistence dependencies
services.AddPersistence(mongoDbDatabaseSettings.ConnectionString, string.Empty);

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

app.Run();
