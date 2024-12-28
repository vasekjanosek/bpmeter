namespace BpMeter.UI.Pages.Settings.AddPersonalInformation;

public partial class LastNamePage : ContentPage
{
	public LastNamePage(PersonalInformationPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}