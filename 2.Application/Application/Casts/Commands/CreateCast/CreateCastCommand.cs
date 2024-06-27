using Domain.Enums;
using FluentResults;
using MediatR;

namespace Application.Casts.Commands.CreateCast;

/// <summary>
/// Represents the create cast command
/// </summary>
public record CreateCastCommand(
    string FirstName,
    string LastName,
    CastType CastType,
    Gender Gender,
    bool IsAlive,
    int Age) : IRequest<Result<Guid>>;
