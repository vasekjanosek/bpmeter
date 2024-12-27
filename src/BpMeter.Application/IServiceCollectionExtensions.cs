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
        services.AddTransient<IPersonalInformationService, PersonalInformationService>();

        return services;
    }

    public static async Task InitializeApplicationAsync(this IServiceProvider services)
    {
        var bpReadingService = services.GetRequiredService<IBpReadingService>();

        await bpReadingService.InitializeAsync();

        var bwReadingService = services.GetRequiredService<IBwReadingService>();

        await bwReadingService.InitializeAsync();

        var personalInfoService = services.GetRequiredService<IPersonalInformationService>();

        await personalInfoService.InitializeAsync();
    }
}
