using BpMeter.Application.Abstractions;
using BpMeter.Mvvm;
using BpMeter.UI.Pages.Settings;
using BpMeter.UI.Pages.Settings.AddPersonalInformation;
using System.Windows.Input;

namespace BpMeter.UI.Pages.Home;

public class HomePageViewModel : ViewModelBase
{
    private readonly IPersonalInformationService _personalInformationService;

    public ICommand TapCommand { get; set; }

    public HomePageViewModel(IPersonalInformationService personalInformationService)
    {
        _personalInformationService = personalInformationService;
        TapCommand = new Command(
            execute: async (page) =>
            {
                await Tap((string)page);
            });
    }

    public async Task Tap(string page)
    {
        if (page.Equals(nameof(PersonalInformationPage)))
        {
            if (!_personalInformationService.IsPersonalInformationFilled())
            {
                page = nameof(AddNewPersonalInformationPage);
            }
        }

        await Shell.Current.GoToAsync(page);
    }
}
