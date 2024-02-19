using Domain.DomainEvents.Commands;

namespace Domain.Entities.Movies.Events;

internal sealed class MovieUpdatedDomainEvent(Movie movie) : CreateDomainEventCommand
{
}
