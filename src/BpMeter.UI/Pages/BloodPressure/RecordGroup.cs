using BpMeter.Domain;

namespace BpMeter.UI.Pages.BloodPressure;

public class RecordGroup : List<BloodPressureReading>
{
    public string Name { get; private set; }

    public RecordGroup(string name, List<BloodPressureReading> readings) : base(readings)
    {
        Name = name;
    }
}
