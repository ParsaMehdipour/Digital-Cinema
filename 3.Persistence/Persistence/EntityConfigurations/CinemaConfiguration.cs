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

        builder.ComplexProperty(c => c.CinemaName, cn =>
        {
            cn.Property(p => p.Value).HasColumnName("CinemaName").IsRequired();
        });

        builder.Property(c => c.CityId).IsRequired();

        builder.Property(c => c.StateId).IsRequired();

        builder.ComplexProperty(c => c.Address, a =>
        {
            a.Property(p => p.Value).HasColumnName("Address").IsRequired();
        });

        builder.Property(c => c.OpeningHour).IsRequired();

        builder.Property(c => c.ClosingHour);

        builder.HasQueryFilter(c => c.IsDeleted == false);
    }
}
