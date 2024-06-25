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

        builder.ComplexProperty(s => s.StateName, sn =>
        {
            sn.Property(p => p.Value).HasColumnName("StateName").IsRequired();
        });

        builder.HasQueryFilter(s => s.IsDeleted == false);
    }
}
