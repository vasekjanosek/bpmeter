using SQLite;
using System.ComponentModel.DataAnnotations;

namespace BpMeter.Infrastructure.Database.Enitites;

public abstract class AuditableEntity
{
    [PrimaryKey, AutoIncrement]
    public int SqlId { get; set; }

    [Key]
    public Guid Id { get; set; }
}
