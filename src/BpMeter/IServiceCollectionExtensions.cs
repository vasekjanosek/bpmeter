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
        services.AddSingleton<HomePageViewModel>();
        services.AddSingleton<HomePage>();

        services.AddSingleton<BPMeasuringPageViewModel>();
        services.AddSingleton<BPMeasuringPage>();

        services.AddSingleton<BPHistoryPageViewModel>();
        services.AddSingleton<BPHistoryPage>();

        services.AddSingleton<BPStatisticsPageViewModel>();
        services.AddSingleton<BPStatisticsPage>();

        services.AddSingleton<BodyWeightPageViewModel>();
        services.AddSingleton<BodyWeightPage>();

        return services;
    }
}
