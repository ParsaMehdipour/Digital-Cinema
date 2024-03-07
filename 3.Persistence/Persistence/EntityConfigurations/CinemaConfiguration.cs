using Domain.Entities.Cinemas;
using Domain.ValueObjects;
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

        builder
            .Property(c => c.CinemaName)
            .HasConversion(x => x.Value, v => CinemaName.Create(v).Value)
            .HasMaxLength(CinemaName.MaxLength);

        builder.Property(c => c.CityId).IsRequired();

        builder.Property(c => c.StateId).IsRequired();

        builder
            .Property(c => c.Address)
            .HasConversion(x => x.Value, v => Address.Create(v).Value)
            .HasMaxLength(Address.MaxLength);

        builder.Property(c => c.OpeningHour).IsRequired();

        builder.Property(c => c.ClosingHour);

        builder.HasQueryFilter(c => c.IsDeleted == false);
    }
}
