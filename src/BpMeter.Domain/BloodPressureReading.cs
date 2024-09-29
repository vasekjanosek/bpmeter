using BpMeter.Domain.Enums;

namespace BpMeter.Domain;

public class BloodPressureReading
{
    public Guid Id { get; set; }

    public int Systolic { get; set; }

    public int Diastolic { get; set; }

    public int HearthRate { get; set; }

    public PartOfTheDay PartOfTheDay { get; set; }

    public PalpitationType Palpitation { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public string Commentary { get; set; }
}
