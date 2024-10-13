using BpMeter.Pages.BloodPressure;

namespace BpMeter.UI.Pages.BloodPressure
{
    public partial class BPMeasuringPage : ContentPage
    {
        public BPMeasuringPage(BPMeasuringPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
        }
    }

}
