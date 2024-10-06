namespace BpMeter.Domain.Abstractions;

public interface IPersonalInformationRepository : IRepository<PersonalInformation>
{
    Task<List<PersonalInformation>> GetAllAsync();

    Task<PersonalInformation> GetAsync(int id);
}
