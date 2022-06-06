using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TaskTracker.Application.Interfaces;

namespace TaskTracker.Persistence
{
    /// <summary>
    /// DI to configure dbcontext
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
               services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<TaskTrackerDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<ITaskTrackerDbContext>(provider =>
                provider.GetService<TaskTrackerDbContext>());
            return services;
        }
    }
}
