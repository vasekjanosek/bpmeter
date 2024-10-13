using BpMeter.Domain.Abstractions;
using BpMeter.Domain;
using BpMeter.Infrastructure.Repositories.Models;
using AutoMapper;
using BpMeter.Domain.Exceptions;

namespace BpMeter.Infrastructure.Repositories.SqLiteDb;

internal class PersonalInformationRepository : SqlLiteRepository<PersonalInformationEntity, PersonalInformation>, IPersonalInformationRepository
{
    public PersonalInformationRepository(SqlLiteDatabase database, IMapper mapper) : base(database, mapper)
    {
    }

    public async Task<PersonalInformation> GetAsync()
    {
        var connection = await Database.CreateOrGetConnectionAsync();
        List<PersonalInformationEntity> result;

        try
        {
            result = await connection.QueryAsync<PersonalInformationEntity>($"select * from {nameof(PersonalInformationEntity)}");
        }
        catch (Exception ex)
        {
            throw new EntityNotFoundException($"Entity {nameof(PersonalInformation)} was not found.", -1);
        }

        var reading = Mapper.Map<PersonalInformation>(result[0]);

        return reading;
    }

    public async Task<bool> IsPersonalInformationFilled()
    {
        var connection = await Database.CreateOrGetConnectionAsync();

        List<int> result;
        try
        {
            result = await connection.QueryAsync<int>($"select count(*) from {nameof(PersonalInformationEntity)}");
        }
        catch (Exception)
        {
            throw new EntityNotFoundException($"Entity {nameof(PersonalInformation)} was not found.", -1);
        }

        return result[0] > 0;
    }
}
