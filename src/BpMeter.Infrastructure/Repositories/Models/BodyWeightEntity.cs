namespace BpMeter.Infrastructure.Repositories.Models;

internal class BodyWeightEntity : AuditableEntity
{
    public int WeightInKg { get; set; }

    public DateTime DateTime { get; set; }
}
