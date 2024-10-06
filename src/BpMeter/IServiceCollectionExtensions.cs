using BpMeter.UI.Pages;
using BpMeter.UI.Pages.History;

namespace BpMeter;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterUi(this IServiceCollection services)
    {
        services.AddSingleton<MainPageViewModel>();
        services.AddSingleton<MainPage>();

        services.AddSingleton<MeasuringHistoryPageViewModel>();
        services.AddSingleton<MeasuringHistoryPage>();

        return services;
    }
}
