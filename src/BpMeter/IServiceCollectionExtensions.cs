using BpMeter.Pages.BloodPressure;
using BpMeter.UI.Pages.Statistics;
using BpMeter.UI.Pages.BloodPressure;
using BpMeter.UI.Pages.History;
using BpMeter.UI.Pages.BodyWeight;
using BpMeter.UI.Pages.Home;

namespace BpMeter;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterUi(this IServiceCollection services)
    {
        services.AddSingleton<BloodPressureMeasuringPageViewModel>();
        services.AddSingleton<BloodPressureMeasuringPage>();

        services.AddSingleton<BodyWeightPageViewModel>();
        services.AddSingleton<BodyWeightPage>();

        services.AddSingleton<HomePageViewModel>();
        services.AddSingleton<HomePage>();

        services.AddSingleton<MeasuringHistoryPageViewModel>();
        services.AddSingleton<MeasuringHistoryPage>();

        services.AddSingleton<StatisticsPageViewModel>();
        services.AddSingleton<StatisticsPage>();

        return services;
    }
}
