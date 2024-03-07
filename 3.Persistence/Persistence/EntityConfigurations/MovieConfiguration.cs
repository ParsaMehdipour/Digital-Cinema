using Domain.Entities.Movies;
using Domain.ValueObjects;
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

        builder
            .Property(c => c.MovieDurationInMinutes)
            .HasConversion(x => x.Value, v => MovieDurationInMinutes.Create(v).Value);

        builder
            .Property(c => c.ImdbScore)
            .HasConversion(x => x.Value, v => Score.Create(v).Value);

        builder
            .Property(c => c.Plot)
            .HasConversion(x => x.Value, v => Plot.Create(v).Value)
            .HasMaxLength(Plot.MaxLength);

        builder
            .Property(c => c.Title)
            .HasConversion(x => x.Value, v => Title.Create(v).Value)
            .HasMaxLength(Title.MaxLength);

        builder.Property(m => m.FilePath);

        builder.Property(m => m.OnlineOnly).IsRequired();

        builder.Property(m => m.ReleaseDate).IsRequired();

        builder.Property(m => m.ShowOnSite).IsRequired();

        builder.HasQueryFilter(m => m.IsDeleted == false);
    }
}
