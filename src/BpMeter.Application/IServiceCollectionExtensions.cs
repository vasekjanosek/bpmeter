using BpMeter.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace BpMeter.Application;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        services.AddTransient<IBpReadingService, BpReadingService>();
        services.AddTransient<IBwReadingService, BwReadingService>();
        services.AddTransient<IStatisticsService, StatisticsService>();

        return services;
    }
}
