using Mapster;
using MapsterMapper;
using System.Reflection;

namespace BuberDinner.Api.Common.Mapping
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            TypeAdapterConfig config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}
