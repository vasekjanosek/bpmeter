using BpMeter.Application.Abstractions;
using BpMeter.Domain;
using BpMeter.Domain.Abstractions;

namespace BpMeter.Application;

public class PersonalInformationService : IPersonalInformationService
{
    private readonly IPersonalInformationRepository _personalInformationRepository;

    private PersonalInformation? _personalInformation;

    public PersonalInformationService(IPersonalInformationRepository personalInformationRepository)
    {
        _personalInformationRepository = personalInformationRepository;
    }

    public async Task InitializeAsync()
    {
        _personalInformation = await GetPersonalInformationAsync();
    }

    public async Task AddPersonalInformationAsync(string firstName, string middleName, string lastName, DateOnly birthDate, int heightInCm)
    {
        var info = new PersonalInformation()
        {
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
            BirthDate = birthDate.ToDateTime(TimeOnly.MinValue),
            HeightInCm = heightInCm
        };

        _personalInformation = await _personalInformationRepository.InsertAsync(info);
    }

    public async Task DeletePersonalInformationAsync()
    {
        var info = await GetPersonalInformationAsync();
        await _personalInformationRepository.DeleteAsync(info);
        _personalInformation = null;
    }

    public async Task<PersonalInformation> GetPersonalInformationAsync()
    {
        if (_personalInformation == null)
        {
            _personalInformation = await _personalInformationRepository.GetAsync();
        }

        return _personalInformation;
    }

    public bool IsPersonalInformationFilled()
    {
        return _personalInformation != null; ;
    }

    public async Task UpdatePersonalInformationAsync(string firstName, string middleName, string lastName, DateOnly birthDate, int heightInCm)
    {
        var info = await GetPersonalInformationAsync();
        info.FirstName = firstName;
        info.MiddleName = middleName;
        info.LastName = lastName;
        info.BirthDate = birthDate.ToDateTime(TimeOnly.MinValue);
        info.HeightInCm = heightInCm;

        _personalInformation = await _personalInformationRepository.UpdateAsync(info);
    }
}
