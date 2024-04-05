using Domain.Errors;
using Domain.ValueObjects;
using FluentValidation;

namespace Application.Casts.Commands.EditCast;

public class EditCastCommandValidator : AbstractValidator<EditCastCommand>
{
    public EditCastCommandValidator()
    {
        RuleFor(ecc => ecc.FirstName).MaximumLength(FirstName.MaxLength).WithMessage(DomainErrors.FirstName.TooLong)
            .NotEmpty().WithMessage(DomainErrors.FirstName.Empty);

        RuleFor(ecc => ecc.LastName).MaximumLength(LastName.MaxLength).WithMessage(DomainErrors.LastName.TooLong)
            .NotEmpty().WithMessage(DomainErrors.LastName.Empty);

        RuleFor(ecc => ecc.Age).NotEqual(0).WithMessage(DomainErrors.Age.Zero)
            .GreaterThan(Age.MinNumber).WithMessage(DomainErrors.Age.TooYoung)
            .LessThan(Age.MaxNumber).WithMessage(DomainErrors.Age.TooOld);
    }
}
