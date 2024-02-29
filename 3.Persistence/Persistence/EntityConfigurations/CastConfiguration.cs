using Domain.Entities.Casts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

public class CastConfiguration : IEntityTypeConfiguration<Cast>
{
    public void Configure(EntityTypeBuilder<Cast> builder)
    {
        builder.ToTable(TableNames.Casts);

        builder.OwnsOne(c => c.FirstName);

        builder.OwnsOne(c => c.LastName);

        builder.Property(c => c.Gender).IsRequired();

        builder.Property(c => c.IsAlive).IsRequired();

        builder.Property(c => c.CastType).IsRequired();

        builder.HasKey(c => c.Id);

        builder.HasQueryFilter(c => c.IsDeleted == false);
    }
}
