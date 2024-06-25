using Domain.Entities.Genres;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

/// <summary>
/// Genre configurations
/// </summary>
public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable(TableNames.Genres);

        builder.HasKey(g => g.Id);

        builder.ComplexProperty(g => g.Title, t =>
        {
            t.Property(p => p.Value).HasColumnName("Title").IsRequired();
        });

        builder.HasQueryFilter(g => g.IsDeleted == false);
    }
}
