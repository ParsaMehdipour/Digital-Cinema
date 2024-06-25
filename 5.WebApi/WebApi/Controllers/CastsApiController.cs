using Application.Casts.Commands.CreateCast;
using Application.Casts.Commands.EditCast;
using Application.Casts.Queries.GetCast;
using Application.Casts.Queries.GetCasts;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Pagination;
using WebApi.Controllers.ControllerBase;

namespace WebApi.Controllers;

/// <summary>
/// Represents a casts api controller
/// </summary>
public class CastsApiController : ApiControllerBase
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mediator"></param>
    public CastsApiController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// Api endpoint to create a cast
    /// </summary>
    /// <param name="request">Request</param>
    /// <returns></returns>
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

    /// <summary>
    /// Api endpoint to edit a cast
    /// </summary>
    /// <param name="request">Request</param>
    /// <returns></returns>
    [HttpPut("Edit")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Edit(EditCastCommand request)
    {
        var result = await Mediator.Send(request, CancellationToken.None);

        if (result.IsSuccess is false)
            return BadRequest(result.Errors);

        return Ok(result);
    }

    /// <summary>
    /// Api endpoint to get cast with pagination
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(Result<PagedResult<GetCastCastDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetCastsQuery query)
    {
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    /// <summary>
    /// Api endpoint to get a cast by identifier
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById/{id}")]
    [ProducesResponseType(typeof(Result<GetCastCastDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await Mediator.Send(new GetCastQuery(Id: id), CancellationToken.None);

        if (result.IsSuccess is false)
            return BadRequest(result.Errors);

        return Ok(result);
    }
}
