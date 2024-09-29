using BpMeter.Application.Abstractions;
using BpMeter.Domain;
using BpMeter.Domain.Enums;
using BpMeter.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BpMeter.UI.Pages;

public class MeasuringHistoryPageViewModel : ViewModelBase
{
    private readonly IBpReadingService _bpReadingService;

    private bool _isRefreshRunning;

    public ObservableCollection<BloodPressureReading> History { get; } = new ObservableCollection<BloodPressureReading>();

    public ICommand RefreshCommand { get; }

    public bool IsRefreshRunning
    {
        set { SetProperty(ref _isRefreshRunning, value); }
        get { return _isRefreshRunning; }
    }

    public MeasuringHistoryPageViewModel(IBpReadingService bpReadingService)
    {
        _bpReadingService = bpReadingService;

        RefreshCommand = new Command(
            execute: async () =>
            {
                await GetMeasuringHistoryAsync();
                RefreshCanExecutes();
            },
            canExecute: () =>
            {
                return !IsRefreshRunning;
            });

        Task.Run(GetMeasuringHistoryAsync);
    }

    protected override void RefreshCanExecutes()
    {
        ((Command)RefreshCommand).ChangeCanExecute();
    }

    private async Task GetMeasuringHistoryAsync()
    {
        IsRefreshRunning = true;

        var history = await _bpReadingService.GetAllReadingAsync();

        try
        {
            History.Clear();
            foreach (var entry in history)
            {
                History.Add(entry);
            }
        }
        catch (Exception ex)
        {
        }

        IsRefreshRunning = false;
    }

}
