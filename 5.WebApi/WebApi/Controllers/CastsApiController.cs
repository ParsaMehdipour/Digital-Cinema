using Application.Casts.Commands.CreateCast;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.ControllerBase;

namespace WebApi.Controllers;

public class CastsApiController : ApiControllerBase
{
    public CastsApiController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("Create")]
    [ProducesResponseType(typeof(Result<Guid>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateCastCommand request)
    {
        var result = await Mediator.Send(request, CancellationToken.None);

        if (result.IsSuccess is false)
            return BadRequest(result.Errors);

        return Ok(result);
    }
}
