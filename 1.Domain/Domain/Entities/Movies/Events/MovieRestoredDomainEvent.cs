using Domain.Primitives;

namespace Domain.Entities.Movies.Events;

/// <summary>
/// Event specific to restoring a movie
/// </summary>
/// <param name="movie"></param>
internal sealed class MovieRestoredDomainEvent(Movie movie) : IDomainEvent
{
    internal Movie Movie { get; set; } = movie;
}
