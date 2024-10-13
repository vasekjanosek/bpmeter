using SQLite;

namespace BpMeter.Infrastructure.Repositories.Models;

internal abstract class AuditableEntity
{
    [PrimaryKey, AutoIncrement]
    public int? Id { get; set; }
}
