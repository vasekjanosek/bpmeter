using BpMeter.Domain;

namespace BpMeter.Application.Abstractions;

public interface IPersonalInformationService
{
    Task InitializeAsync();

    bool IsPersonalInformationFilled();

    Task<PersonalInformation> GetPersonalInformationAsync();

    Task AddPersonalInformationAsync(string fistName, string middleName, string lastName, DateOnly birthDate, int heightInCm);

    Task UpdatePersonalInformationAsync(string fistName, string middleName, string lastName, DateOnly birthDate, int heightInCm);

    Task DeletePersonalInformationAsync();
}
