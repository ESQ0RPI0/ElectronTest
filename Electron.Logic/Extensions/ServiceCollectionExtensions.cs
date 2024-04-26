using Electron.Logic.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Electron.Logic.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection InitLogic(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();

            //для создания "слабой" связи между контроллером, сервисами + встроенный EventSource 
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            return services;
        }
    }
}
