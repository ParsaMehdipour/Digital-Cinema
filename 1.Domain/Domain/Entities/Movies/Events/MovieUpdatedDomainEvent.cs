using Domain.Primitives;

namespace Domain.Entities.Movies.Events;

/// <summary>
/// Event specific to updating a movie
/// </summary>
/// <param name="movie"></param>
internal sealed class MovieUpdatedDomainEvent(Movie movie) : IDomainEvent
{
    public Movie Movie { get; set; } = movie;
}
