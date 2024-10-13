namespace BpMeter.Infrastructure.Repositories.Models;

internal class BodyWeightEntity : AuditableEntity
{
    public double WeightInKg { get; set; }

    public DateTime DateTime { get; set; }

    public string Commentary { get; set; }
}
