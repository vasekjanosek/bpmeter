using BpMeter.Application.Abstractions;
using BpMeter.UI.Pages.BloodPressure;
using BpMeter.UI.Pages.BodyWeight;
using BpMeter.UI.Pages.Home;
using BpMeter.UI.Pages.Settings;
using BpMeter.UI.Pages.Settings.AddPersonalInformation;

namespace BpMeter.UI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(BPMeasuringPage), typeof(BPMeasuringPage));
        Routing.RegisterRoute(nameof(BPHistoryPage), typeof(BPHistoryPage));
        Routing.RegisterRoute(nameof(BPStatisticsPage), typeof(BPStatisticsPage));

        Routing.RegisterRoute(nameof(BWMeasuringPage), typeof(BWMeasuringPage));

        Routing.RegisterRoute(nameof(PersonalInformationPage), typeof(PersonalInformationPage));
        Routing.RegisterRoute(nameof(AddNewPersonalInformationPage), typeof(AddNewPersonalInformationPage));
        Routing.RegisterRoute(nameof(BirthDatePage), typeof(BirthDatePage));
        Routing.RegisterRoute(nameof(FirstNamePage), typeof(FirstNamePage));
        Routing.RegisterRoute(nameof(HeightPage), typeof(HeightPage));
        Routing.RegisterRoute(nameof(LastNamePage), typeof(LastNamePage));
        Routing.RegisterRoute(nameof(MiddleNamePage), typeof(MiddleNamePage));

        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
    }
}
