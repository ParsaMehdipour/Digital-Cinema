using Domain.Entities.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Constants;

namespace Persistence.EntityConfigurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable(TableNames.Tickets);

        builder.HasKey(t => t.Id);

        builder.Property(t => t.CustomerId).IsRequired();

        builder.Property(t => t.MovieId).IsRequired();

        builder.Property(t => t.DateAndTime).IsRequired();

        builder.Property(t => t.HallId).IsRequired();

        builder.Property(t => t.Intended).IsRequired();

        builder.Property(t => t.ReferenceNumber).IsRequired();

        builder.Property(t => t.SeatNumber).IsRequired();

        builder.Property(t => t.Sold).IsRequired();

        builder.Property(t => t.Type).IsRequired();

        builder.HasQueryFilter(t => t.IsDeleted == false);
    }
}
