using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        services.AddValidatorsFromAssembly(assembly);
    }
}
