using Domain.Errors;
using Domain.ValueObjects;
using FluentValidation;

namespace Application.Casts.Commands.EditCast;

/// <summary>
/// Validates the command before reaching the handler
/// </summary>
public class EditCastCommandValidator : AbstractValidator<EditCastCommand>
{
    public EditCastCommandValidator()
    {
        RuleFor(ecc => ecc.FirstName).MaximumLength(FirstName.MaxLength).WithMessage(DomainErrors.FirstName.TooLong.Message)
            .NotEmpty().WithMessage(DomainErrors.FirstName.Empty.Message);

        RuleFor(ecc => ecc.LastName).MaximumLength(LastName.MaxLength).WithMessage(DomainErrors.LastName.TooLong.Message)
            .NotEmpty().WithMessage(DomainErrors.LastName.Empty.Message);

        RuleFor(ecc => ecc.Age).NotEqual(0).WithMessage(DomainErrors.Age.Zero.Message)
            .GreaterThan(Age.MinNumber).WithMessage(DomainErrors.Age.TooYoung.Message)
            .LessThan(Age.MaxNumber).WithMessage(DomainErrors.Age.TooOld.Message);
    }
}
