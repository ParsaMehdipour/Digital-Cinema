using Domain.Repositories.BaseRepositories;
using Domain.Repositories.BaseRepositories.MongoRepositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Persistence.Repositories;
using Persistence.Repositories.MongoRepositories;

namespace Persistence;

public static class DependencyInjection
{
    /// <summary>
    /// Set's persistence's dependency injections
    /// </summary>
    /// <param name="services"></param>
    /// <param name="mongoConnectionString"></param>
    /// <param name="sqlConnectionString"></param>
    public static void AddPersistence(this IServiceCollection services, string mongoConnectionString, string sqlConnectionString) => services.Setup(mongoConnectionString, sqlConnectionString);

    /// <summary>
    /// Set's persistence's service dependency injections
    /// </summary>
    /// <param name="services"></param>
    /// <param name="mongoConnectionString"></param>
    /// <param name="sqlConnectionString"></param>
    public static void Setup(this IServiceCollection services, string mongoConnectionString, string sqlConnectionString)
    {
        //Base repositories -> SQL
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));

        //Base repositories -> MongoDB
        services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

        //MongoDB
        services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoConnectionString));
    }
}
