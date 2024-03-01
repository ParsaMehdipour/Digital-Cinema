using Domain.Entities.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

/// <summary>
/// Movie configurations
/// </summary>
public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable(TableNames.Movies);

        builder.HasKey(m => m.Id);

        builder.OwnsOne(m => m.MovieDurationInMinutes);

        builder.OwnsOne(m => m.ImdbScore);

        builder.OwnsOne(m => m.Plot);

        builder.OwnsOne(m => m.Title);

        builder.Property(m => m.FilePath);

        builder.Property(m => m.OnlineOnly).IsRequired();

        builder.Property(m => m.ReleaseDate).IsRequired();

        builder.Property(m => m.ShowOnSite).IsRequired();

        builder.HasQueryFilter(m => m.IsDeleted == false);
    }
}
