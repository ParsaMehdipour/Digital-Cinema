using Domain.Errors;
using Domain.ValueObjects;
using FluentValidation;

namespace Application.Casts.Commands.CreateCast;

/// <summary>
/// Validates the command before reaching the handler
/// </summary>
public class CreateCastCommandValidator : AbstractValidator<CreateCastCommand>
{
    public CreateCastCommandValidator()
    {
        Include(new FirstNameValidator());
    }
}

/// <summary>
/// Validator for first name
/// </summary>
internal class FirstNameValidator : AbstractValidator<CreateCastCommand>
{
    public FirstNameValidator()
    {
        RuleFor(fn => fn.FirstName)
            .MaximumLength(FirstName.MaxLength).WithName(nameof(FirstName)).WithMessage(DomainErrors.FirstName.TooLong.Message)
            .NotEmpty().WithMessage(DomainErrors.FirstName.Empty);
    }
}

/// <summary>
/// Validator for last name
/// </summary>
internal class LastNameValidator : AbstractValidator<CreateCastCommand>
{
    public LastNameValidator()
    {
        RuleFor(ln => ln.LastName)
            .MaximumLength(LastName.MaxLength).WithName(nameof(LastName)).WithMessage(DomainErrors.LastName.TooLong.Message)
            .NotEmpty().WithMessage(DomainErrors.LastName.Empty);
    }
}