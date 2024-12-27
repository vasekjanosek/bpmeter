using System.ComponentModel.DataAnnotations;

namespace BpMeter.Dto;

public class BloodPressureDto : AuditableDto
{
    [Required]
    public int? Systolic { get; set; }

    [Required]
    public int? Diastolic { get; set; }

    [Required]
    public int? HeartRate { get; set; }

    public PalpitationTypeDto? Palpitation { get; set; }

    [Required]
    public DateTime? DateTime { get; set; }

    public string? Commentary { get; set; }
}
