using Domain.Entities.Casts;
using Domain.Enums;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public class SeedData
{
    public static readonly Cast Cast1 = Cast.Create(FirstName.Create("Parsa").Value, LastName.Create("Mehdipour").Value, Gender.Male, CastType.Director, true, Age.Create(23).Value);

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var dbContext = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
        // Look for any Contributors.
        if (dbContext.Casts.Any())
        {
            return;   // DB has been seeded
        }

        PopulateTestData(dbContext);
    }
    public static void PopulateTestData(ApplicationDbContext dbContext)
    {
        foreach (var item in dbContext.Casts)
        {
            dbContext.Remove(item);
        }
        dbContext.SaveChanges();

        dbContext.Casts.Add(Cast1);

        dbContext.SaveChanges();
    }
}
