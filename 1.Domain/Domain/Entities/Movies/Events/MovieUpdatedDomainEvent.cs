using Domain.DomainEvents;

namespace Domain.Entities.Movies.Events;

internal sealed class MovieUpdatedDomainEvent(Movie movie) : DomainEvent
{
}
