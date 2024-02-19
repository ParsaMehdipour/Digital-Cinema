using Domain.DomainEvents.Commands;

namespace Domain.Entities.Movies.Events;
internal sealed class MovieDeletedDomainEvent(Movie movie) : CreateDomainEventCommand
{
}
