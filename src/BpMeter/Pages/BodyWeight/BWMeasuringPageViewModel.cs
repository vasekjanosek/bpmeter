using BpMeter.Application.Abstractions;
using BpMeter.Domain;
using BpMeter.Mvvm;
using System.Windows.Input;

namespace BpMeter.UI.Pages.BodyWeight;

public class BWMeasuringPageViewModel : ViewModelBase
{
    private readonly IBwReadingService _bwReadingService;

    private double? _bodyWeight;
    private string? _commentary;

    public double? BodyWeight
    {
        set { SetProperty(ref _bodyWeight, value); }
        get { return _bodyWeight; }
    }

    public string? Commentary
    {
        set { SetProperty(ref _commentary, value); }
        get { return _commentary; }
    }

    public bool IsReadingFilledAndValid =>
        BodyWeight != null;

    public ICommand SubmitCommand { get; }

    public BWMeasuringPageViewModel(IBwReadingService bwReadingService)
    {
        _bwReadingService = bwReadingService;

        SubmitCommand = new Command(
            execute: async () =>
            {
                await SubmitReading();
                ClearValues();
                RefreshCanExecutes();
            },
            canExecute: () =>
            {
               return IsReadingFilledAndValid;
            });
    }

    protected override void RefreshCanExecutes()
    {
        ((Command)SubmitCommand)?.ChangeCanExecute();
    }

    private async Task SubmitReading()
    {
        if (BodyWeight == null)
        {

        }

        var dateTimeNow = DateTime.UtcNow;

        var bpReading = new BodyWeightReading()
        {
            WeightInKg = BodyWeight.Value,
            DateTime = DateTime.UtcNow,
            Commentary = Commentary
        };

        await _bwReadingService.AddNewReadingAsync(bpReading);
    }

    private void ClearValues()
    {
        BodyWeight = null;
        Commentary = Commentary;
    }
}
