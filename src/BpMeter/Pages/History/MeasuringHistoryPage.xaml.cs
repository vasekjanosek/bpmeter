namespace BpMeter.UI.Pages.History;

public partial class MeasuringHistoryPage : ContentPage
{
	public MeasuringHistoryPage(MeasuringHistoryPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}