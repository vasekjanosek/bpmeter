using BpMeter.Domain.Abstractions;
using BpMeter.Infrastructure.Repositories.FileRepository;
using Microsoft.Extensions.DependencyInjection;

namespace BpMeter.Infrastructure;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IBloodPressureReadingRepository, CsvBpReadingRepository>();

        return services;
    }
}
