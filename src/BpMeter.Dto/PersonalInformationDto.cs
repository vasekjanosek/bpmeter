using System.ComponentModel.DataAnnotations;

namespace BpMeter.Dto;

public class PersonalInformationDto
{
    [Required]
    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public DateTime? BirthDate { get; set; }

    public int? HeightInCm { get; set; }
}
