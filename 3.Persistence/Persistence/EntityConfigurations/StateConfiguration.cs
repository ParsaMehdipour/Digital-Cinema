using Domain.Entities.States;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable(TableNames.States);

        builder.HasKey(s => s.Id);

        builder.OwnsOne(s => s.StateName);

        builder.HasQueryFilter(s => s.IsDeleted == false);
    }
}
