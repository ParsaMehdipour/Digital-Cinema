using Domain.Primitives;

namespace Domain.Entities.Halls;
public class Hall : Entity
{
    #region Fields

    public Guid CinemaId { get; private set; }

    public int Capacity { get; private set; }

    #endregion

    #region Ctor

    private Hall() { }

    private Hall(Guid cinemaId, int capacity)
    {
        SetCinemaId(cinemaId);
        SetCapacity(capacity);
    }

    #endregion

    #region Methods

    public Hall Create(Guid cinemaId, int capacity) => new(cinemaId, capacity);

    public void SetCinemaId(Guid cinemaId)
    {
        if (cinemaId == Guid.Empty) return;

        if (CinemaId.Equals(cinemaId)) return;

        CinemaId = cinemaId;
    }

    public void SetCapacity(int capacity)
    {
        if (Capacity.Equals(capacity)) return;

        Capacity = capacity;
    }

    #endregion
}
