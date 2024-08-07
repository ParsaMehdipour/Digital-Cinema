﻿using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class Plot : ValueObject
{
    public const int MaxLength = 250;

    private Plot()
    {

    }

    private Plot(string value) => Value = value;

    public string Value { get; }


    public static Result<Plot> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<Plot>(DomainErrors.Plot.Empty);

        if (value.Length > MaxLength)
            return Result.Failure<Plot>(DomainErrors.Plot.TooLong);

        return new Plot(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
