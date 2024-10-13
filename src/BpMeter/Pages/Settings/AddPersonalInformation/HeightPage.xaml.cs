namespace BpMeter.UI.Pages.Settings.AddPersonalInformation;

public partial class HeightPage : ContentPage
{
	public HeightPage(PersonalInformationPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}