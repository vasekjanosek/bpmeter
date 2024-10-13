namespace BpMeter.UI.Pages.Settings.AddPersonalInformation;

public partial class MiddleNamePage : ContentPage
{
	public MiddleNamePage(PersonalInformationPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}