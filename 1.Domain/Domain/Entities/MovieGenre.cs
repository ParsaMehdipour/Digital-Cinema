using Domain.Primitives;

namespace Domain.Entities;

public class MovieGenre : Entity
{
    #region Fields

    public Guid GenreId { get; private set; }

    public Guid MovieId { get; private set; }

    #endregion

    #region Ctor

    private MovieGenre() { }

    private MovieGenre(Guid genreId, Guid movieId)
    {
        SetGenreId(genreId);
        SetMovieId(movieId);
    }

    #endregion

    #region Methods

    public MovieGenre Create(Guid genreId, Guid movieId) => new(genreId, movieId);

    public void SetGenreId(Guid genreId)
    {
        if (genreId == Guid.Empty) return;
        if (GenreId == genreId) return;

        GenreId = genreId;
    }

    public void SetMovieId(Guid movieId)
    {
        if (movieId == Guid.Empty) return;
        if (MovieId == movieId) return;

        MovieId = movieId;
    }

    #endregion
}
