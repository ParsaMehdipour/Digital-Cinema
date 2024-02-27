using Domain.Primitives;

namespace Domain.Entities.Movies.Events;

/// <summary>
/// Event specific to creating a movie
/// </summary>
/// <param name="movie"></param>
internal sealed class MovieCreatedDomainEvent(Movie movie) : IDomainEvent
{
    public Movie Movie { get; set; } = movie;
}
