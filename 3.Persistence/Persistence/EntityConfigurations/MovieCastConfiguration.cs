using Domain.Entities.MovieCasts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

/// <summary>
/// Movie cast configurations
/// </summary>
public class MovieCastConfiguration : IEntityTypeConfiguration<MovieCast>
{
    public void Configure(EntityTypeBuilder<MovieCast> builder)
    {
        builder.ToTable(TableNames.MovieCasts);

        builder.HasKey(mc => mc.Id);

        builder.Property(mc => mc.CastId).IsRequired();

        builder.Property(mc => mc.MovieId).IsRequired();

        builder.Property(mc => mc.CastType).IsRequired();

        builder.HasQueryFilter(mc => mc.IsDeleted == false);
    }
}
