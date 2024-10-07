namespace BpMeter.UI.Pages.History;

public partial class BPHistoryPage : ContentPage
{
	public BPHistoryPage(BPHistoryPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}