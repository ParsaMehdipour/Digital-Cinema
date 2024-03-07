using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;
public sealed class CinemaName : ValueObject
{
    public const int MaxLength = 200;

    private CinemaName(string value) => Value = value;

    public string Value { get; }

    public static Result<CinemaName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<CinemaName>(DomainErrors.CinemaName.Empty);

        if (value.Length > MaxLength)
            return Result.Failure<CinemaName>(DomainErrors.CinemaName.TooLong);

        return new CinemaName(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
