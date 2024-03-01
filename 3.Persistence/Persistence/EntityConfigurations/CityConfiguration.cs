using Domain.Entities.Cities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

/// <summary>
/// City configurations
/// </summary>
public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable(TableNames.Cities);

        builder.HasKey(c => c.Id);

        builder.OwnsOne(c => c.CityName);

        builder.HasQueryFilter(c => c.IsDeleted == false);
    }
}
