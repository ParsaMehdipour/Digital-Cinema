using Domain.Entities.Genres;
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

        builder.OwnsOne(g => g.Title);

        builder.HasQueryFilter(g => g.IsDeleted == false);
    }
}
