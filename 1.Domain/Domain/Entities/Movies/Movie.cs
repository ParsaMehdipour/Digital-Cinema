using Domain.Entities.Movies.Events;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities.Movies;

public class Movie : AggregateRoot
{
    #region Fields

    public Title Title { get; private set; } = null!;
    public Score ImdbScore { get; private set; } = null!;
    public Plot Plot { get; private set; } = null!;
    public MovieDurationInMinutes MovieDurationInMinutes { get; private set; } = null!;
    public DateTime ReleaseDate { get; private set; }
    public string FilePath { get; private set; } = string.Empty;
    public bool ShowOnSite { get; private set; }
    public bool OnlineOnly { get; private set; }

    #endregion

    #region Ctor

    private Movie(Guid id, Title title, Score score, Plot plot, MovieDurationInMinutes movieDurationInMinutes, DateTime releaseDate, bool showOnSite, bool onlineOnly) : base(id)
    {
        SetTitle(title);
        SetScore(score);
        SetPlot(plot);
        SetMovieDurationInMinutes(movieDurationInMinutes);
        SetReleaseDate(releaseDate);
        SetShowOnSite(showOnSite);
        SetOnlineOnly(onlineOnly);
    }

    private Movie()
    {

    }

    #endregion

    #region Methods

    public Movie Create(Guid id, Title title, Score score, Plot plot, MovieDurationInMinutes movieDurationInMinutes, DateTime releaseDate, bool showOnSite, bool onlineOnly)
    {
        var movie = new Movie(id, title, score, plot, movieDurationInMinutes, releaseDate, showOnSite, onlineOnly);

        movie.RaiseDomainEvent(new MovieCreatedDomainEvent(this));

        return movie;
    }

    public void SetTitle(Title title)
    {
        if (Title.Equals(title)) return;

        if (Title != null && Title.Equals(title) is false)
            RaiseDomainEvent(new MovieUpdatedDomainEvent(this));

        Title = title;
    }

    public void SetScore(Score imdbScore)
    {
        if (ImdbScore.Equals(imdbScore)) return;

        if (ImdbScore != imdbScore && ImdbScore.Equals(imdbScore) is false)
            RaiseDomainEvent(new MovieUpdatedDomainEvent(this));

        ImdbScore = imdbScore;
    }

    public void SetPlot(Plot plot)
    {
        if (Plot.Equals(plot)) return;

        if (Plot != null && Plot.Equals(plot) is false)
            RaiseDomainEvent(new MovieUpdatedDomainEvent(this));

        Plot = plot;
    }

    public void SetMovieDurationInMinutes(MovieDurationInMinutes movieDurationInMinutes)
    {
        if (MovieDurationInMinutes.Equals(movieDurationInMinutes)) return;

        if (MovieDurationInMinutes != null && MovieDurationInMinutes.Equals(movieDurationInMinutes) is false)
            RaiseDomainEvent(new MovieUpdatedDomainEvent(this));

        MovieDurationInMinutes = movieDurationInMinutes;
    }

    public void SetReleaseDate(DateTime releaseDate)
    {
        if (releaseDate.Equals(releaseDate)) return;

        if (ReleaseDate != default && ReleaseDate.Equals(releaseDate) is false)
            RaiseDomainEvent(new MovieUpdatedDomainEvent(this));

        ReleaseDate = releaseDate;
    }

    public void SetShowOnSite(bool showOnSite)
    {
        if (ShowOnSite.Equals(showOnSite)) return;

        if (ShowOnSite != default && ShowOnSite.Equals(showOnSite) is false)
            RaiseDomainEvent(new MovieUpdatedDomainEvent(this));

        ShowOnSite = showOnSite;
    }

    public void SetOnlineOnly(bool onlineOnly)
    {
        if (OnlineOnly.Equals(onlineOnly)) return;

        if (OnlineOnly != default && OnlineOnly.Equals(onlineOnly) is false)
            RaiseDomainEvent(new MovieUpdatedDomainEvent(this));

        OnlineOnly = onlineOnly;
    }

    public void SetFilePath(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath)) return;

        if (FilePath.Equals(filePath)) return;

        FilePath = filePath;
    }

    #endregion
}
