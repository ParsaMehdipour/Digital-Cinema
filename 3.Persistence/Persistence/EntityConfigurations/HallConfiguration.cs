using Domain.Entities.Halls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

/// <summary>
/// Hall configurations
/// </summary>
public class HallConfiguration : IEntityTypeConfiguration<Hall>
{
    public void Configure(EntityTypeBuilder<Hall> builder)
    {
        builder.ToTable(TableNames.Halls);

        builder.HasKey(h => h.Id);

        builder.Property(h => h.Capacity).IsRequired();

        builder.Property(h => h.CinemaId).IsRequired();

        builder.HasQueryFilter(h => h.IsDeleted == false);
    }
}
