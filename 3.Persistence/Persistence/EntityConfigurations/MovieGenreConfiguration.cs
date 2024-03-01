using Domain.Entities.MovieGenres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

/// <summary>
/// Movie genre configurations
/// </summary>
public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
{
    public void Configure(EntityTypeBuilder<MovieGenre> builder)
    {
        builder.ToTable(TableNames.MovieGenres);

        builder.HasKey(mg => mg.Id);

        builder.Property(mg => mg.MovieId).IsRequired();

        builder.Property(mg => mg.GenreId).IsRequired();

        builder.HasQueryFilter(mg => mg.IsDeleted == false);
    }
}
