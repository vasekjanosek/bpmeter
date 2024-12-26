namespace BpMeter.Infrastructure.Database.Enitites;

public class PersonalInformationEntity : AuditableEntity
{
    public string FistName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public int HeightInCm { get; set; }
}
