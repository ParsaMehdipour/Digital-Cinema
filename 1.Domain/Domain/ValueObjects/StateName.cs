using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;
public class StateName : ValueObject
{
    public const int MaxLength = 100;

    private StateName()
    {

    }

    private StateName(string value) => Value = value;

    public string Value { get; }

    public static Result<StateName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<StateName>(DomainErrors.StateName.Empty);

        if (value.Length > MaxLength)
            return Result.Failure<StateName>(DomainErrors.StateName.TooLong);

        return new StateName(value);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
