using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskTracker.Application.Common.Behaviors;
using FluentValidation;


namespace TaskTracker.Application
{
    /// <summary>
    /// DI for register MediatR and ValidatorsFromAssemblies
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
