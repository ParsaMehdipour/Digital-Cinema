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

        builder.ComplexProperty(m => m.MovieDurationInMinutes, mdim =>
        {
            mdim.Property(p => p.Value).HasColumnName("MovieDurationInMinutes").IsRequired();
        });

        builder.ComplexProperty(m => m.ImdbScore, ims =>
        {
            ims.Property(p => p.Value).HasColumnName("ImdbScore").IsRequired();
        });

        builder.ComplexProperty(m => m.Plot, pl =>
        {
            pl.Property(p => p.Value).HasColumnName("Plot").IsRequired();
        });

        builder.ComplexProperty(m => m.Title, t =>
        {
            t.Property(p => p.Value).HasColumnName("Title").IsRequired();
        });

        builder.Property(m => m.FilePath);

        builder.Property(m => m.OnlineOnly).IsRequired();

        builder.Property(m => m.ReleaseDate).IsRequired();

        builder.Property(m => m.ShowOnSite).IsRequired();

        builder.HasQueryFilter(m => m.IsDeleted == false);
    }
}
