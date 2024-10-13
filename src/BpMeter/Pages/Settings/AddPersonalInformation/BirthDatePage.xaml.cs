namespace BpMeter.UI.Pages.Settings.AddPersonalInformation;

public partial class BirthDatePage : ContentPage
{
	public BirthDatePage(PersonalInformationPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}