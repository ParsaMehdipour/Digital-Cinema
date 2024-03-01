using Domain.Entities.Cinemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

/// <summary>
/// Cinema configurations
/// </summary>
public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
{
    public void Configure(EntityTypeBuilder<Cinema> builder)
    {
        builder.ToTable(TableNames.Cinemas);

        builder.HasKey(c => c.Id);

        builder.OwnsOne(c => c.CinemaName);

        builder.Property(c => c.CityId).IsRequired();

        builder.Property(c => c.StateId).IsRequired();

        builder.OwnsOne(c => c.Address);

        builder.Property(c => c.OpeningHour).IsRequired();

        builder.Property(c => c.ClosingHour);

        builder.HasQueryFilter(c => c.IsDeleted == false);
    }
}
