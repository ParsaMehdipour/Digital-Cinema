using Domain.DomainEvents.Commands;

namespace Domain.Entities.Movies.Events;

internal sealed class MovieCreatedDomainEvent(Movie movie) : CreateDomainEventCommand
{
}
