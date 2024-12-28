using System.ComponentModel.DataAnnotations;

namespace BpMeter.Dto;

public class AuditableDto
{
    [Required]
    public Guid? Id { get; set; }
}
