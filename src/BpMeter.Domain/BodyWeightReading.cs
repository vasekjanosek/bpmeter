namespace BpMeter.Domain;

public class BodyWeightReading : Reading
{
    public double WeightInKg { get; set; }

    public DateTime DateTime { get; set; }

    public string Commentary { get; set; }
}
