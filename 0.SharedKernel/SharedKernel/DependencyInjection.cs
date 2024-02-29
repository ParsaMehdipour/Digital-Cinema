using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SharedKernel.UserServices.Interfaces;
using SharedKernel.UserServices.Services;
using SharedKernel.ValidationBehaviours;
using System.Reflection;

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

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly())).AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
    }
}
