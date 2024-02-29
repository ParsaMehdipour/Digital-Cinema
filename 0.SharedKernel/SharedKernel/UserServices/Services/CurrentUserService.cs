using Microsoft.AspNetCore.Http;
using SharedKernel.UserServices.Interfaces;
using System.Security.Claims;

namespace SharedKernel.UserServices.Services;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public Guid UserId => Guid.Parse(httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)!.Value ?? string.Empty);

    public string UserIpAddress => httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
}
