namespace BpMeter.UI.Pages.Statistics;

public partial class StatisticsPage : ContentPage
{
	public StatisticsPage(StatisticsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}