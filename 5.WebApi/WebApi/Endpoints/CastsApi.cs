using Application.Casts.Commands.CreateCast;
using Application.Casts.Commands.DeleteRestoreCast;
using Application.Casts.Commands.EditCast;
using Application.Casts.Queries.GetCast;
using Application.Casts.Queries.GetCasts;
using Application.Casts.Queries.GetCasts.Criteria;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Pagination;

namespace WebApi.Endpoints;

/// <summary>
/// Represents casts api endpoints
/// </summary>
public static class CastsApi
{
    /// <summary>
    /// Maps casts endpoints
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapCastsApi(this IEndpointRouteBuilder app)
    {
        // Create the api group
        var api = app.MapGroup("api/casts");

        // Routes for querying casts
        api.MapGet("/", GetAllCastsWithSearch);
        api.MapGet("{castId:guid}", GetCastAsync);

        // Routes for managing casts
        api.MapPost("/", CreateCastAsync);
        api.MapPut("/", EditCastAsync);
        api.MapDelete("/", DeleteCastAsync);

        return app;
    }

    /// <summary>
    /// Gets all casts with search
    /// </summary>
    /// <param name="mediator">Mediator</param>
    /// <param name="parameters">Parameters</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the paged result of get casts dto
    /// </returns>
    public static async Task<Results<Ok<Result<PagedResult<GetCastsDto>>>, BadRequest<Result>>> GetAllCastsWithSearch(
        [FromServices] IMediator mediator,
        [AsParameters] CastsQueryStringParameters parameters)
    {
        var result = await mediator.Send(new GetCastsQuery(parameters));

        return TypedResults.Ok(result);
    }

    /// <summary>
    /// Gets a cast with the given identifier
    /// </summary>
    /// <param name="mediator">Mediator</param>
    /// <param name="castId">Cast identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the cast with the same identifier
    /// </returns>
    public static async Task<Results<Ok<Result<GetCastDto>>, NotFound, BadRequest<Result>>> GetCastAsync(
        [FromServices] IMediator mediator,
        Guid castId)
    {
        var result = await mediator.Send(new GetCastQuery(castId));

        return TypedResults.Ok(result);
    }

    /// <summary>
    /// Creates a cast
    /// </summary>
    /// <param name="mediator">Mediator</param>
    /// <param name="command">Command</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the id of the created cast
    /// </returns>
    public static async Task<Results<Ok<Result<Guid>>, BadRequest<Result<Guid>>>> CreateCastAsync(
        [FromServices] IMediator mediator,
        CreateCastCommand command)
    {
        var result = await mediator.Send(command);

        if (result.IsFailed)
            return TypedResults.BadRequest(result);

        return TypedResults.Ok(result);
    }

    /// <summary>
    /// Edits a cast
    /// </summary>
    /// <param name="mediator">Mediator</param>
    /// <param name="command">Command</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// </returns>
    public static async Task<Results<Ok<Result>, BadRequest<Result>>> EditCastAsync(
        [FromServices] IMediator mediator,
        EditCastCommand command)
    {
        var result = await mediator.Send(command);

        if (result.IsFailed)
            return TypedResults.BadRequest(result);

        return TypedResults.Ok(result);
    }


    /// <summary>
    /// Deletes a cast
    /// </summary>
    /// <param name="mediator">Mediator</param>
    /// <param name="castId">Cast identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operations
    /// </returns>
    public static async Task<Results<Ok<Result>, BadRequest<Result>>> DeleteCastAsync(
        [FromServices] IMediator mediator,
        Guid castId)
    {
        var result = await mediator.Send(new DeleteRestoreCastCommand(Id: castId, Delete: true));

        if (result.IsFailed)
            return TypedResults.BadRequest(result);

        return TypedResults.Ok(result);
    }
}
