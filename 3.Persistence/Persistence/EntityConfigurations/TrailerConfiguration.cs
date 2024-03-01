using Domain.Entities.Trailers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

/// <summary>
/// Trailer configurations
/// </summary>
public class TrailerConfiguration : IEntityTypeConfiguration<Trailer>
{
    public void Configure(EntityTypeBuilder<Trailer> builder)
    {
        builder.ToTable(TableNames.Trailers);

        builder.HasKey(t => t.Id);

        builder.OwnsOne(t => t.TrailerDurationInMinutes);

        builder.Property(t => t.MovieId).IsRequired();

        builder.Property(t => t.FilePath).IsRequired();

        builder.Property(t => t.ReleaseDate);

        builder.Property(t => t.ShowOnSite).IsRequired();

        builder.HasQueryFilter(t => t.IsDeleted == false);
    }
}
