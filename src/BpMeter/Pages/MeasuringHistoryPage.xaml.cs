namespace BpMeter.UI.Pages;

public partial class MeasuringHistoryPage : ContentPage
{
	public MeasuringHistoryPage(MeasuringHistoryPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}