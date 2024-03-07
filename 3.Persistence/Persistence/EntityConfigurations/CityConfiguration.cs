using Domain.Entities.Cities;
using Domain.ValueObjects;
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

        builder
            .Property(c => c.CityName)
            .HasConversion(x => x.Value, v => CityName.Create(v).Value)
            .HasMaxLength(CityName.MaxLength);

        builder.HasQueryFilter(c => c.IsDeleted == false);
    }
}
