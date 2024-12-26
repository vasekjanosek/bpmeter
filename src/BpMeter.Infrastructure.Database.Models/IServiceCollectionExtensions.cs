using BpMeter.Infrastructure.Repositories.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BpMeter.Infrastructure.Database.Enitites;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterDatabaseEntities(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DbMappingProfile));

        return services;
    }
}
