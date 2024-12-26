using SQLite;

namespace BpMeter.Infrastructure.Database.Enitites;

public abstract class AuditableEntity
{
    [PrimaryKey, AutoIncrement]
    public int? Id { get; set; }
}
