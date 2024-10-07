namespace BpMeter.UI.Pages.BodyWeight;

public partial class BodyWeightPage : ContentPage
{
	public BodyWeightPage(BodyWeightPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}