using Dal.Repositories;
using Dal.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dal.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDal(this IServiceCollection services)
    {
        services.AddScoped<IHardwareRepository, HardwareRepository>();
        
        return services;
    }
}