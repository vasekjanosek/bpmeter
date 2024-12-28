namespace BpMeter.Infrastructure.Database.Entites;

public class BodyWeightEntity : AuditableEntity
{
    public double WeightInKg { get; set; }

    public DateTime DateTime { get; set; }

    public string? Commentary { get; set; }
}
