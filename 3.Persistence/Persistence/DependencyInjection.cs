using Domain.Repositories;
using Domain.Repositories.BaseRepositories;
using Domain.Repositories.BaseRepositories.MongoRepositories;
using Domain.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Persistence.Repositories;
using Persistence.Repositories.MongoRepositories;
using Persistence.Repositories.PostgressRepositories;
using Persistence.Repositories.UnitOFWork;

namespace Persistence;

public static class DependencyInjection
{
    /// <summary>
    /// Set's persistence's dependency injections
    /// </summary>
    /// <param name="services"></param>
    /// <param name="mongoConnectionString"></param>
    /// <param name="postgresConnectionString"></param>
    public static void AddPersistence(this IServiceCollection services, string mongoConnectionString,
        string postgresConnectionString) => services.Setup(mongoConnectionString, postgresConnectionString);

    /// <summary>
    /// Set's persistence's service dependency injections
    /// </summary>
    /// <param name="services"></param>
    /// <param name="mongoConnectionString"></param>
    /// <param name="postgresConnectionString"></param>
    public static void Setup(this IServiceCollection services, string mongoConnectionString,
        string postgresConnectionString)
    {
        //Base repositories -> Postgres
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));

        //Application repositories
        services.AddScoped(typeof(ICastRepository), typeof(CastRepository));


        //Unit of work
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

        //Base repositories -> MongoDB
        services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

        //MongoDB
        services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoConnectionString));

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(postgresConnectionString));
    }
}
