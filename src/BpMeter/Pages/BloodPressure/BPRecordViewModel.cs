using BpMeter.Domain;
using BpMeter.Domain.Enums;
using BpMeter.Mvvm;

namespace BpMeter.UI.Pages.BloodPressure;

public class BPRecordViewModel : ViewModelBase
{
    private bool _showDetails;

    public int Systolic { get; set; }

    public int Diastolic { get; set; }

    public int HeartRate { get; set; }

    public PartOfTheDay PartOfTheDay { get; set; }

    public PalpitationType Palpitation { get; set; }

    public DateTime DateTime { get; set; }

    public string Commentary { get; set; }

    public bool ShowDetails
    {
        set { SetProperty(ref _showDetails, value); }
        get { return _showDetails; }
    }

    public BPRecordViewModel(BloodPressureReading reading)
    {
        Systolic = reading.Systolic;
        Diastolic = reading.Diastolic;
        HeartRate = reading.HeartRate;
        PartOfTheDay = reading.PartOfTheDay;
        Palpitation = reading.Palpitation;
        DateTime = reading.DateTime;
        Commentary = reading.Commentary;
    }
}
