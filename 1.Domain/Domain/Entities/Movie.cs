using Domain.DomainEvents;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Movie : AggregateRoot, IAuditableEntity
{
    #region Fields

    public Title Title { get; private set; } = null!;
    public Score ImdbScore { get; private set; } = null!;
    public Plot Plot { get; private set; } = null!;
    public MovieDurationInMinutes MovieDurationInMinutes { get; private set; } = null!;
    public Guid GenreId { get; private set; }
    public DateTime ReleaseDate { get; private set; }

    //AuditableEntity
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }

    #endregion

    #region Ctor

    private Movie(Guid id, Title title, Score score, Plot plot, MovieDurationInMinutes movieDurationInMinutes, Guid genreId, DateTime releaseDate) : base(id)
    {
        SetTitle(title);
        SetScore(score);
        SetPlot(plot);
        SetMovieDurationInMinutes(movieDurationInMinutes);
        SetGenreId(genreId);
        SetReleaseDate(releaseDate);
    }

    private Movie()
    {

    }

    #endregion

    #region Methods

    public Movie Create(Guid id, Title title, Score score, Plot plot, MovieDurationInMinutes movieDurationInMinutes, Guid genreId, DateTime releaseDate)
    {
        var movie = new Movie(id, title, score, plot, movieDurationInMinutes, genreId, releaseDate);

        movie.RaiseDomainEvent(new MovieCreatedDomainEvent(Guid.NewGuid(), movie.Id));

        return movie;
    }

    public void SetTitle(Title title) => Title = title;

    public void SetScore(Score imdbScore) => ImdbScore = imdbScore;

    public void SetGenreId(Guid genreId) => GenreId = genreId;

    public void SetPlot(Plot plot) => Plot = plot;

    public void SetMovieDurationInMinutes(MovieDurationInMinutes movieDurationInMinutes) => MovieDurationInMinutes = movieDurationInMinutes;

    public void SetReleaseDate(DateTime releaseDate) => ReleaseDate = releaseDate;

    #endregion
}
