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

        if (exception is KeyNotFoundException notFoundException)
        {
            _logger.LogError(
                notFoundException,
                "Exception occurred: {Message}",
                notFoundException.Message);

            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

            jsonString = JsonSerializer.Serialize(new Result().WithError(notFoundException.Message));

            await httpContext.Response.WriteAsync(jsonString, Encoding.UTF8, cancellationToken);

            return true;
        }
        else
        {
            _logger.LogError(
                exception, "Exception occurred: {Message}", exception.Message);

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            jsonString = JsonSerializer.Serialize(new Result().WithError(exception.Message));

            await httpContext.Response.WriteAsync(jsonString, Encoding.UTF8, cancellationToken);

            return true;
        }
    }
}
