using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Constants;

namespace WebApi.Controllers.ControllerBase;
[ApiController]
[Route(template: Routes.ApiController)]
public class ApiControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
{
    public ApiControllerBase(IMediator mediator) => Mediator = mediator;

    protected IMediator Mediator { get; }
}