using System.ComponentModel.DataAnnotations;

namespace BpMeter.Infrastructure.Database.Entites;

public abstract class AuditableEntity
{
    [Key]
    public Guid Id { get; set; }
}
