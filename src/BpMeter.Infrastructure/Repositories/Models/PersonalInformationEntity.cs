namespace BpMeter.Infrastructure.Repositories.Models;

internal class PersonalInformationEntity : AuditableEntity
{
    public string FistName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public int HeightInCm { get; set; }
}
