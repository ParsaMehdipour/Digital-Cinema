using Domain.Entities.States;
using Domain.ValueObjects;
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

        builder
            .Property(c => c.StateName)
            .HasConversion(x => x.Value, v => StateName.Create(v).Value)
            .HasMaxLength(StateName.MaxLength);

        builder.HasQueryFilter(s => s.IsDeleted == false);
    }
}
