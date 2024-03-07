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

        builder
            .Property(c => c.Title)
            .HasConversion(x => x.Value, v => Title.Create(v).Value)
            .HasMaxLength(Title.MaxLength);

        builder.HasQueryFilter(g => g.IsDeleted == false);
    }
}
