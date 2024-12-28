namespace BpMeter.UI.Pages.Statistics;

public partial class BWStatisticsPage : ContentPage
{
    public BWStatisticsPage(BWStatisticsPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}