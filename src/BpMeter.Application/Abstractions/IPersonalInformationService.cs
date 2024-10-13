using BpMeter.Domain;

namespace BpMeter.Application.Abstractions;

public interface IPersonalInformationService
{
    Task<bool> IsPersonalInformationFilled();

    Task<PersonalInformation> GetPersonalInformation();

    Task AddPersonalInformation(string fistName, string middleName, string lastName, DateOnly birthDate, int heightInCm);

    Task UpdatePersonalInformation(string fistName, string middleName, string lastName, DateOnly birthDate, int heightInCm);

    Task DeletePersonalInformation();
}
