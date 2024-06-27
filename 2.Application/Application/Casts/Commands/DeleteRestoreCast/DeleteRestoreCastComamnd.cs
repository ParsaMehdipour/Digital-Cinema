using FluentResults;
using MediatR;

namespace Application.Casts.Commands.DeleteRestoreCast;

/// <summary>
/// Represents a delete or restore cast command
/// </summary>
/// <param name="Id">Cast identifier</param>
/// <param name="Delete">Whether the cast is requested to be deleted or restored</param>
public record DeleteRestoreCastCommand(Guid Id, bool Delete) : IRequest<Result>;
