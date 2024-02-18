using Domain.DomainEvents;

namespace Domain.Entities.Movies.Events;
internal sealed class MovieRestoredDomainEvent(Movie movie) : DomainEvent
{
}
