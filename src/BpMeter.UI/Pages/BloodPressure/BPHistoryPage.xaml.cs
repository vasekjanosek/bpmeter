namespace BpMeter.UI.Pages.BloodPressure;

public partial class BPHistoryPage : ContentPage
{
	public BPHistoryPage(BPHistoryPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}