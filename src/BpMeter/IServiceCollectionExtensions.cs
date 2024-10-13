using BpMeter.Pages.BloodPressure;
using BpMeter.UI.Pages.BloodPressure;
using BpMeter.UI.Pages.BodyWeight;
using BpMeter.UI.Pages.Home;
using BpMeter.UI.Pages.Settings;
using BpMeter.UI.Pages.Settings.AddPersonalInformation;

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

        services.AddSingleton<BWMeasuringPageViewModel>();
        services.AddSingleton<BWMeasuringPage>();

        services.AddSingleton<PersonalInformationPageViewModel>();
        services.AddSingleton<PersonalInformationPage>();
        services.AddSingleton<AddNewPersonalInformationPage>();
        services.AddSingleton<BirthDatePage>();
        services.AddSingleton<FirstNamePage>();
        services.AddSingleton<HeightPage>();
        services.AddSingleton<LastNamePage>();
        services.AddSingleton<MiddleNamePage>();

        return services;
    }
}
