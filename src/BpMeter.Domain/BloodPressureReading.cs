using BpMeter.Domain.Enums;

namespace BpMeter.Domain;

public class BloodPressureReading : Reading
{
    public int Systolic { get; set; }

    public int Diastolic { get; set; }

    public int HeartRate { get; set; }

    public PartOfTheDay PartOfTheDay { get; set; }

    public PalpitationType Palpitation { get; set; }

    public DateTime DateTime {  get; set; }

    public string Commentary { get; set; }
}
