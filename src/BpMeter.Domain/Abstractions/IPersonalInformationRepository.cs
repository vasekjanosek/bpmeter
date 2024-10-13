namespace BpMeter.Domain.Abstractions;

public interface IPersonalInformationRepository : IRepository<PersonalInformation>
{
    Task<PersonalInformation> GetAsync();

    Task<bool> IsPersonalInformationFilled();
}
