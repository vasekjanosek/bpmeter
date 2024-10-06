using SQLite;

namespace BpMeter.Infrastructure.Repositories.Models;

internal abstract class AuditableEntity
{
    [PrimaryKey]
    public int? Id { get; set; }
}
