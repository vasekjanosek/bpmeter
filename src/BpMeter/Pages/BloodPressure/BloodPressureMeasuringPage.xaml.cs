using BpMeter.Pages.BloodPressure;

namespace BpMeter.UI.Pages.BloodPressure
{
    public partial class BloodPressureMeasuringPage : ContentPage
    {
        public BloodPressureMeasuringPage(BloodPressureMeasuringPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
        }
    }

}
