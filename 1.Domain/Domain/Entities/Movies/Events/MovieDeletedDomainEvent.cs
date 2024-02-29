using Domain.Primitives;

namespace Domain.Entities.Movies.Events;

/// <summary>
/// Event specific to deleting a movie
/// </summary>
/// <param name="movie"></param>
internal sealed class MovieDeletedDomainEvent(Movie movie) : IDomainEvent
{
    internal Movie Movie { get; set; } = movie;
}
