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

        builder.ComplexProperty(c => c.FirstName, fn =>
        {
            fn.Property(p => p.Value).HasColumnName("FirstName").IsRequired();
        });

        builder.ComplexProperty(c => c.LastName, ln =>
        {
            ln.Property(p => p.Value).HasColumnName("LastName").IsRequired();
        });

        builder.ComplexProperty(c => c.Age, a =>
        {
            a.Property(p => p.Value).HasColumnName("Age").IsRequired();
        });

        builder.Property(c => c.Gender).IsRequired();

        builder.Property(c => c.IsAlive).IsRequired();

        builder.Property(c => c.CastType).IsRequired();

        builder.HasQueryFilter(c => c.IsDeleted == false);
    }
}
