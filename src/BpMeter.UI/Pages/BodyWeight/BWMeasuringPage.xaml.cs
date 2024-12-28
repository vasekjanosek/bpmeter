namespace BpMeter.UI.Pages.BodyWeight;

public partial class BWMeasuringPage : ContentPage
{
	public BWMeasuringPage(BWMeasuringPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}