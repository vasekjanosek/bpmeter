using BpMeter.Mvvm;
using System.Windows.Input;

namespace BpMeter.UI.Pages.Settings;

public class SettingsPageViewModel : ViewModelBase
{
    public ICommand TapCommand { get; set; }

    public SettingsPageViewModel()
    {
        TapCommand = new Command(
            execute: async (page) =>
            {
                await Tap((string)page);
            });
    }

    public async Task Tap(string page)
    {
        await Shell.Current.GoToAsync(page);
    }
}
