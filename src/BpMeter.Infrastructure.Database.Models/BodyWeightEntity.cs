namespace BpMeter.Infrastructure.Database.Enitites;

public class BodyWeightEntity : AuditableEntity
{
    public double WeightInKg { get; set; }

    public DateTime DateTime { get; set; }

    public string? Commentary { get; set; }
}
