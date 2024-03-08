using Application.ValidationBehaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;
public static class DependencyInjection
{
    /// <summary>
    /// Set's Application's dependency injections
    /// </summary>
    /// <param name="services"></param>
    public static void AddApplication(this IServiceCollection services) => services.Setup();

    /// <summary>
    /// Set's Application's service dependency injections
    /// </summary>
    /// <param name="services"></param>
    public static void Setup(this IServiceCollection services)
    {
        //Base repositories -> Postgres
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly())).AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
    }
}
