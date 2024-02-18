using Domain.Entities.Casts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

public class CastConfiguration : IEntityTypeConfiguration<Cast>
{
    public void Configure(EntityTypeBuilder<Cast> builder)
    {
        builder.ToTable(TableNames.Casts);

        builder.HasKey(_ => _.Id);

        builder.HasQueryFilter(_ => _.IsDeleted == false);
    }
}
