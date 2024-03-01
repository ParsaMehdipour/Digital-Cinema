using Domain.Entities.MoviePlays;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

/// <summary>
/// Mvoie play configurations
/// </summary>
public class MoviePlayConfiguration : IEntityTypeConfiguration<MoviePlay>
{
    public void Configure(EntityTypeBuilder<MoviePlay> builder)
    {
        builder.ToTable(TableNames.MoviePlays);

        builder.HasKey(mp => mp.Id);

        builder.Property(mp => mp.MovieId).IsRequired();

        builder.Property(mp => mp.HallId).IsRequired();

        builder.HasQueryFilter(mp => mp.IsDeleted == false);
    }
}
