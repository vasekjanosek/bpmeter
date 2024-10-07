namespace BpMeter.Domain;

public class BodyWeightReading : Reading
{
    public int WeightInKg { get; set; }

    public DateTime DateTime { get; set; }
}
