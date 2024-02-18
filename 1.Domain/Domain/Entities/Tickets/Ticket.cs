using Domain.Enums;
using Domain.Primitives;

namespace Domain.Entities.Tickets;
public class Ticket : Entity
{
    #region Fields

    public Guid MovieId { get; private set; }

    public Guid CustomerId { get; private set; }

    public Guid HallId { get; private set; }

    public TicketType Type { get; private set; }

    public DateTime DateAndTime { get; private set; }

    public bool Sold { get; private set; }

    public bool Intended { get; private set; }

    public int SeatNumber { get; private set; }

    public string ReferenceNumber { get; private set; } = string.Empty;

    #endregion

    #region Ctor

    private Ticket() { }

    private Ticket(Guid movieId, Guid customerId, Guid hallId, TicketType type, DateTime dateAndTime, bool sold, bool intended, int seatNumber, string referenceNumber)
    {
        SetMovieId(movieId);
        SetCustomerId(customerId);
        SetHallId(hallId);
        SetTicketType(type);
        SetDateAndTime(dateAndTime);
        SetSold(true);
        SetIntended(false);
        SetSeatNumber(seatNumber);
        SetReferenceNumber(referenceNumber);
    }

    #endregion

    #region Methods

    public Ticket Create(Guid movieId, Guid customerId, Guid hallId, TicketType type, DateTime dateAndTime, bool sold, bool intended, int seatNumber, string referenceNumber) => new(movieId,
        customerId,
        hallId,
        type,
        dateAndTime,
        sold,
        intended,
        seatNumber,
        referenceNumber);

    public void SetMovieId(Guid movieId)
    {
        if (movieId == Guid.Empty) return;

        if (MovieId.Equals(movieId)) return;

        MovieId = movieId;
    }

    public void SetCustomerId(Guid customerId)
    {
        if (customerId == Guid.Empty) return;

        if (CustomerId.Equals(customerId)) return;

        CustomerId = customerId;
    }

    public void SetHallId(Guid hallId)
    {
        if (hallId == Guid.Empty) return;

        if (hallId.Equals(hallId)) return;

        HallId = hallId;
    }

    public void SetTicketType(TicketType type)
    {
        if (Type.Equals(type)) return;

        Type = type;
    }

    public void SetDateAndTime(DateTime dateAndTime)
    {
        if (DateAndTime.Equals(dateAndTime)) return;

        DateAndTime = dateAndTime;
    }

    public void SetSold(bool sold)
    {
        if (Sold.Equals(sold)) return;

        Sold = sold;
    }

    public void SetIntended(bool intended)
    {
        if (Intended.Equals(intended)) return;

        Intended = intended;
    }

    public void SetSeatNumber(int seatNumber)
    {
        if (SeatNumber.Equals(seatNumber)) return;

        SeatNumber = seatNumber;
    }

    public void SetReferenceNumber(string refereneNumber)
    {
        if (string.IsNullOrEmpty(refereneNumber)) return;

        if (ReferenceNumber.Equals(refereneNumber)) return;

        ReferenceNumber = refereneNumber;
    }

    #endregion
}
