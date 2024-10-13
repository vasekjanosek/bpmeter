using BpMeter.Application.Abstractions;
using BpMeter.Domain;
using BpMeter.Domain.Abstractions;

namespace BpMeter.Application;

public class PersonalInformationService : IPersonalInformationService
{
    private readonly IPersonalInformationRepository _personalInformationRepository;

    public PersonalInformationService(IPersonalInformationRepository personalInformationRepository)
    {
        _personalInformationRepository = personalInformationRepository;
    }

    public async Task AddPersonalInformation(string fistName, string middleName, string lastName, DateOnly birthDate, int heightInCm)
    {
        var info = new PersonalInformation()
        {
            FistName = fistName,
            MiddleName = middleName,
            LastName = lastName,
            BirthDate = birthDate,
            HeightInCm = heightInCm
        };

        await _personalInformationRepository.InsertAsync(info);
    }

    public async Task DeletePersonalInformation()
    {
        var info = await GetPersonalInformation();
        await _personalInformationRepository.DeleteAsync(info);
    }

    public async Task<PersonalInformation> GetPersonalInformation()
    {
        return await _personalInformationRepository.GetAsync();
    }

    public async Task<bool> IsPersonalInformationFilled()
    {
        return await _personalInformationRepository.IsPersonalInformationFilled();
    }

    public async Task UpdatePersonalInformation(string fistName, string middleName, string lastName, DateOnly birthDate, int heightInCm)
    {
        var info = await GetPersonalInformation();
        info.FistName = fistName;
        info.MiddleName = middleName;
        info.LastName = lastName;
        info.BirthDate = birthDate;
        info.HeightInCm = heightInCm;

        await _personalInformationRepository.UpdateAsync(info);
    }
}
