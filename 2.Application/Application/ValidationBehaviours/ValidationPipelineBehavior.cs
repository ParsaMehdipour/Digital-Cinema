using FluentValidation;
using MediatR;

namespace Application.ValidationBehaviours;

/// <summary>
/// Validation behavior pipeline
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IRequest<TResponse>
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

            string message = string.Empty;

            foreach (var failiure in failures)
                message += failiure + "; ";

            if (failures.Any())
                throw new ValidationException(message);
        }

        return await next();
    }
}