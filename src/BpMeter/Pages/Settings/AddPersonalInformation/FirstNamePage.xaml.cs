namespace BpMeter.UI.Pages.Settings.AddPersonalInformation;

public partial class FirstNamePage : ContentPage
{
	public FirstNamePage(PersonalInformationPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}