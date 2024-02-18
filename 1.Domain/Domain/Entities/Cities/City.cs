using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities.Cities;
public class City : Entity
{
    #region Fields

    public CityName CityName { get; private set; } = null!;

    #endregion

    #region Ctor

    private City(CityName cityName) => SetCityName(cityName);

    #endregion

    #region Methods

    public City Create(CityName cityName) => new(cityName);

    public void SetCityName(CityName cityName)
    {
        if (CityName.Equals(cityName)) return;

        CityName = cityName;
    }

    #endregion
}
