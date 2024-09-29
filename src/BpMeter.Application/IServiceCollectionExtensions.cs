using BpMeter.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace BpMeter.Application;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        services.AddTransient<IBpReadingService, BpReadingService>();
        services.AddSingleton<IStatisticsService, StatisticsService>();

        return services;
    }
}
