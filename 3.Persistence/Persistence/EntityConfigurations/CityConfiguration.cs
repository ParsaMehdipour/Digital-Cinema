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

        builder.ComplexProperty(c => c.CityName, cn =>
        {
            cn.Property(p => p.Value).HasColumnName("CityName").IsRequired();
        });

        builder.HasQueryFilter(c => c.IsDeleted == false);
    }
}
