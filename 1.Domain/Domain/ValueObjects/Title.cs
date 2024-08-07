﻿using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;
public sealed class Title : ValueObject
{
    public const int MaxLength = 100;

    private Title()
    {
        
    }

    private Title(string value) => Value = value;

    public string Value { get; }

    public static Result<Title> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<Title>(DomainErrors.Title.Empty);

        if (value.Length > MaxLength)
            return Result.Failure<Title>(DomainErrors.Title.TooLong);

        return new Title(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
