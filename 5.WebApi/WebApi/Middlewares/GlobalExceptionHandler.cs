using Application.ValidationBehaviours;
using Domain.Exceptions;
using FluentResults;
using Microsoft.AspNetCore.Diagnostics;
using System.Text;
using System.Text.Json;

namespace WebApi.Middlewares;

internal sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        string jsonString;

        if (exception is DomainException or ValidationException)
        {
            _logger.LogError(
                exception,
                "Exception occurred: {Message}",
                exception.Message);

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            httpContext.Response.ContentType = "application/json";

            jsonString = JsonSerializer.Serialize(new Result().WithError(exception.Message));

            await httpContext.Response.WriteAsync(jsonString, Encoding.UTF8, cancellationToken);

            return true;
        }
        else
        {
            _logger.LogError(
                exception,
                "Exception occurred: {Message}",
                exception.Message);

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "application/json";

            jsonString = JsonSerializer.Serialize(new Result().WithError(exception.Message));

            await httpContext.Response.WriteAsync(jsonString, Encoding.UTF8, cancellationToken);

            return true;
        }
    }
}
