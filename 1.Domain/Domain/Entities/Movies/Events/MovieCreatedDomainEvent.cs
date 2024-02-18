using Domain.DomainEvents;

namespace Domain.Entities.Movies.Events;

internal sealed class MovieCreatedDomainEvent(Movie movie) : DomainEvent
{
}
