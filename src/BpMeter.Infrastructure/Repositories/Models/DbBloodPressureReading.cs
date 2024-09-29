using BpMeter.Domain.Enums;
using SQLite;

namespace BpMeter.Domain;

public class DbBloodPressureReading
{
    [PrimaryKey]
    public int Id { get; set; }

    public int Systolic { get; set; }

    public int Diastolic { get; set; }

    public int HeartRate { get; set; }

    public PartOfTheDay PartOfTheDay { get; set; }

    public PalpitationType Palpitation { get; set; }

    public DateTime DateTime {  get; set; }

    public string Commentary { get; set; }
}
