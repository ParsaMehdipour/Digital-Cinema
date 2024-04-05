using Domain.Enums;
using FluentResults;
using MediatR;

namespace Application.Casts.Commands.EditCast;

public record EditCastCommand(
    Guid Id,
    string FirstName,
    string LastName,
    CastType CastType,
    Gender Gender,
    bool IsAlive,
    int? Age) : IRequest<Result>;
