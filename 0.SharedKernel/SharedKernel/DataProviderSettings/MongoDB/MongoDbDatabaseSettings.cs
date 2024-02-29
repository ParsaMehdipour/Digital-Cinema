namespace SharedKernel.DataProviderSettings.MongoDB;

public class MongoDbDatabaseSettings
{
    public required string ConnectionString { get; set; }
    public required string DatabaseName { get; set; }
}
