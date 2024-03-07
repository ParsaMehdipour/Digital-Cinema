using Domain.Entities.Casts;
using Domain.ValueObjects;
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

        builder
            .Property(c => c.FirstName)
            .HasConversion(x => x.Value, v => FirstName.Create(v).Value)
            .HasMaxLength(FirstName.MaxLength);

        builder
            .Property(c => c.LastName)
            .HasConversion(x => x.Value, v => LastName.Create(v).Value)
            .HasMaxLength(LastName.MaxLength);

        builder
            .Property(c => c.Age)
            .HasConversion(x => x.Value, v => Age.Create(v).Value);

        builder.Property(c => c.Gender).IsRequired();

        builder.Property(c => c.IsAlive).IsRequired();

        builder.Property(c => c.CastType).IsRequired();

        builder.HasQueryFilter(c => c.IsDeleted == false);
    }
}
