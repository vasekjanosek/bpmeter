using BpMeter.Application.Abstractions;
using BpMeter.Domain;
using BpMeter.Domain.Enums;
using BpMeter.Extensions;
using BpMeter.Mvvm;
using System.Windows.Input;

namespace BpMeter.UI.Pages;

public class MainPageViewModel : ViewModelBase
{
    private readonly IBpReadingService _bpReadingService;

    private int? _systolic;
    private int? _diastolic;
    private int? _heartRate;
    private PartOfTheDay _partOfTheDay;
    private PalpitationType _palpitationType;
    private string? _commentary;

    public int? Systolic
    {
        set { SetProperty(ref _systolic, value); }
        get { return _systolic; }
    }

    public int? Diastolic
    {
        set { SetProperty(ref _diastolic, value); }
        get { return _diastolic; }
    }

    public int? HeartRate
    {
        set { SetProperty(ref _heartRate, value); }
        get { return _heartRate; }
    }

    public PartOfTheDay SelectedPartOfTheDay
    {
        set { SetProperty(ref _partOfTheDay, value); }
        get { return _partOfTheDay; }
    }

    public List<string> AllPartsOfTheDay { get; } = Enum.GetNames(typeof(PartOfTheDay)).Select(b => string.Join(" ", b.SplitCamelCase())).ToList();

    public PalpitationType SelectedPalpitation
    {
        set { SetProperty(ref _palpitationType, value); }
        get { return _palpitationType; }
    }

    public List<string> AllPalpitationTypes { get; } = Enum.GetNames(typeof(PalpitationType)).Select(b => string.Join(" ", b.SplitCamelCase())).ToList();

    public string? Commentary
    {
        set { SetProperty(ref _commentary, value); }
        get { return _commentary; }
    }

    public bool IsReadingFilledAndValid => 
        Systolic != null && IsIntValid(Systolic.Value) 
        && Diastolic != null && IsIntValid(Diastolic.Value) 
        && HeartRate != null && IsIntValid(HeartRate.Value);

    public ICommand SubmitReadingCommand { get; }

    public MainPageViewModel(IBpReadingService bpReadingService)
    {
        _bpReadingService = bpReadingService;

        SelectedPartOfTheDay = PartOfTheDay.Unspecified;
        SelectedPalpitation = PalpitationType.Normal;

        SubmitReadingCommand = new Command(
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
        ((Command)SubmitReadingCommand)?.ChangeCanExecute();
    }

    private async Task SubmitReading()
    {
        if (Systolic == null || Diastolic == null || HeartRate == null)
        {

        }

        var dateTimeNow = DateTime.UtcNow;

        var bpReading = new BloodPressureReading()
        {
            Systolic = Systolic.Value,
            Diastolic = Diastolic.Value,
            HeartRate = HeartRate.Value,
            PartOfTheDay = SelectedPartOfTheDay,
            Palpitation = SelectedPalpitation,
            DateTime = DateTime.UtcNow,
            Commentary = Commentary
        };

        await _bpReadingService.AddNewReadingAsync(bpReading);
    }

    private void ClearValues()
    {
        Systolic = null;
        Diastolic = null;
        HeartRate = null;
        SelectedPartOfTheDay = PartOfTheDay.Unspecified;
        SelectedPalpitation = PalpitationType.Normal;
        Commentary = Commentary;
    }

    private bool IsIntValid(int value)
    {
        int length = value.ToString().Length;
        return 2 <= length && length <= 3;
    }
}
