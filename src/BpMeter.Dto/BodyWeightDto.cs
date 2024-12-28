using System.ComponentModel.DataAnnotations;

namespace BpMeter.Dto;

public class BodyWeightDto : AuditableDto
{
    [Required]
    public double? WeightInKg { get; set; }

    [Required]
    public DateTime? DateTime { get; set; }

    public string? Commentary { get; set; }
}
