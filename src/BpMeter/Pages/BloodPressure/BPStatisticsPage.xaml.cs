namespace BpMeter.UI.Pages.BloodPressure;

public partial class BPStatisticsPage : ContentPage
{
	public BPStatisticsPage(BPStatisticsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}