using Domain.Entities.Casts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

/// <summary>
/// Cast configurations
/// </summary>
public class CastConfiguration : IEntityTypeConfiguration<Cast>
{
    public void Configure(EntityTypeBuilder<Cast> builder)
    {
        builder.ToTable(TableNames.Casts);

        builder.HasKey(c => c.Id);

        builder.OwnsOne(c => c.FirstName);

        builder.OwnsOne(c => c.LastName);

        builder.Property(c => c.Gender).IsRequired();

        builder.Property(c => c.IsAlive).IsRequired();

        builder.Property(c => c.CastType).IsRequired();

        builder.HasQueryFilter(c => c.IsDeleted == false);
    }
}
