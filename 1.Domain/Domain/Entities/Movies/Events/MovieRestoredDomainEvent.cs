using Domain.DomainEvents.Commands;

namespace Domain.Entities.Movies.Events;
internal sealed class MovieRestoredDomainEvent(Movie movie) : CreateDomainEventCommand
{
}
