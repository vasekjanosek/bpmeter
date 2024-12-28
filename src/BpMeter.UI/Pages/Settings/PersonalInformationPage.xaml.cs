namespace BpMeter.UI.Pages.Settings;

public partial class PersonalInformationPage : ContentPage
{
	public PersonalInformationPage(PersonalInformationPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}