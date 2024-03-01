using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities.Cinemas;
public class Cinema : Entity
{
    #region Fields

    public CinemaName CinemaName { get; private set; } = null!;

    public Guid CityId { get; private set; } = Guid.Empty;

    public Guid StateId { get; private set; } = Guid.Empty;

    public Address Address { get; private set; } = null!;

    public DateTime OpeningHour { get; private set; }

    public DateTime ClosingHour { get; private set; }

    #endregion

    #region Ctor

    private Cinema() { }

    private Cinema(CinemaName cinemaName, Guid cityId, Guid stateId, Address address, DateTime oppeningHour, DateTime closingHour)
    {
        SetCinemaName(cinemaName);
        SetAddress(address);
        SetStateId(stateId);
        SetCityId(cityId);
        SetOppeningHour(oppeningHour);
        SetClosingHour(closingHour);
    }

    #endregion

    #region Methods

    public Cinema Create(CinemaName cinemaName, Guid cityId, Guid stateId, Address address, DateTime oppeningHour, DateTime closingHour) => new(cinemaName,
        cityId,
        stateId,
        address,
        oppeningHour,
        closingHour);

    public void SetCinemaName(CinemaName cinemaName)
    {
        if (CinemaName.Equals(cinemaName)) return;

        CinemaName = cinemaName;
    }

    public void SetAddress(Address address)
    {
        if (Address.Equals(address)) return;

        Address = address;
    }

    public void SetCityId(Guid cityId)
    {
        if (cityId == Guid.Empty) return;

        if (CityId.Equals(cityId)) return;

        CityId = cityId;
    }

    public void SetStateId(Guid stateId)
    {
        if (StateId == Guid.Empty) return;

        if (StateId.Equals(stateId)) return;

        StateId = stateId;
    }

    public void SetOppeningHour(DateTime oppeningHour)
    {
        if (OpeningHour.Equals(oppeningHour)) return;

        OpeningHour = oppeningHour;
    }

    public void SetClosingHour(DateTime closingHour)
    {
        if (ClosingHour.Equals(closingHour)) return;

        ClosingHour = closingHour;
    }

    #endregion
}
