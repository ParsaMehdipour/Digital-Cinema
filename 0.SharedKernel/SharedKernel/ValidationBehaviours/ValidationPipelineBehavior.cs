using FluentResults;
using FluentValidation;
using MediatR;

namespace SharedKernel.ValidationBehaviours;

public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
    where TResponse : ResultBase<TResponse>, new()
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(v => v.Errors.Any())
                .SelectMany(v => v.Errors)
                .ToList();

            TResponse result = new();

            foreach (var failure in failures)
                result.Reasons.Add(new Error(failure.ErrorMessage));

            if (result.Errors.Any())
                return result;
        }

        return await next();
    }
}