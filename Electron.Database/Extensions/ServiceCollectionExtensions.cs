using Electron.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Electron.Database.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersonContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PersonDbContext>((opts) =>
            {
                opts.UseNpgsql(connectionString);
            });

            return services;
        }
    }
}
