namespace BpMeter.Domain;

public class PersonalInformation : Reading
{
    public string FistName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public int HeightInCm { get; set; }
}
