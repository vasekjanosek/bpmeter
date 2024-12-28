namespace BpMeter.UI.Pages.Settings.AddPersonalInformation;

public partial class AddNewPersonalInformationPage : ContentPage
{
	public AddNewPersonalInformationPage(PersonalInformationPageViewModel viewModel)
	{
		InitializeComponent();
		viewModel.ClearValues();
		BindingContext = viewModel;
	}
}