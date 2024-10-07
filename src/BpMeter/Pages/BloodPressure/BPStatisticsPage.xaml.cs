namespace BpMeter.UI.Pages.Statistics;

public partial class BPStatisticsPage : ContentPage
{
	public BPStatisticsPage(BPStatisticsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}