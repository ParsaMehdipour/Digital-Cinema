using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;
public class CityName : ValueObject
{
    private const int MaxLength = 100;

    private CityName(string value) => Value = value;

    public string Value { get; }

    public Result<CityName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<CityName>(DomainErrors.CityName.Empty);

        if (value.Length > MaxLength)
            return Result.Failure<CityName>(DomainErrors.CityName.TooLong);

        return new CityName(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
