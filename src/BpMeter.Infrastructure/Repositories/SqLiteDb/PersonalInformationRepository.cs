using BpMeter.Domain.Abstractions;
using BpMeter.Domain;
using BpMeter.Infrastructure.Repositories.Models;
using AutoMapper;

namespace BpMeter.Infrastructure.Repositories.SqLiteDb;

internal class PersonalInformationRepository : SqlLiteRepository<PersonalInformationEntity, PersonalInformation>, IPersonalInformationRepository
{
    public PersonalInformationRepository(SqlLiteDatabase database, IMapper mapper) : base(database, mapper)
    {
    }

    public Task<List<PersonalInformation>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PersonalInformation> GetAsync(int id)
    {
        throw new NotImplementedException();
    }
}
