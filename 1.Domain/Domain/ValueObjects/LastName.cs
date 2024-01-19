using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class LastName : ValueObject
{
    private const int MaxLength = 50;

    private LastName(string value) => Value = value;

    public string Value { get; }

    public static Result<LastName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<LastName>(DomainErrors.LastName.Empty);

        if (value.Length > MaxLength)
            return Result.Failure<LastName>(DomainErrors.LastName.TooLong);

        return new LastName(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
