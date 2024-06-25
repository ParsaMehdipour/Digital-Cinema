using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public class CityName : ValueObject
{
    public const int MaxLength = 100;

    private CityName()
    {

    }

    private CityName(string value) => Value = value;

    public string Value { get; }

    public static Result<CityName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<CityName>(DomainErrors.CityName.Empty);

        if (value.Length > MaxLength)
            return Result.Failure<CityName>(DomainErrors.CityName.TooLong);

        return new CityName(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
