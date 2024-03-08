using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SharedKernel.Logging;
using SharedKernel.UserServices.Interfaces;
using SharedKernel.UserServices.Services;

namespace SharedKernel;
public static class DependencyInjection
{
    /// <summary>
    /// Set's shared kernel's dependency injections
    /// </summary>
    /// <param name="services"></param>
    public static void AddSharedKernel(this IServiceCollection services) => services.Setup();

    /// <summary>
    /// Set's shared kernel service dependency injections
    /// </summary>
    /// <param name="services"></param>
    internal static void Setup(this IServiceCollection services)
    {
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        //Logger
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}
