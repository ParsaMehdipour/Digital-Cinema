﻿namespace Application.ValidationBehaviours;

/// <summary>
/// Represents a validation exception
/// </summary>
public class ValidationException : Exception
{
    public ValidationException(string message) : base(message) { }
}
