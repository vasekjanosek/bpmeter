using BpMeter.Domain.Abstractions;
using BpMeter.Domain;
using BpMeter.Infrastructure.Repositories.Models;
using AutoMapper;

namespace BpMeter.Infrastructure.Repositories.SqLiteDb;

internal class BodyWeightRepository : SqlLiteRepository<BodyWeightEntity, BodyWeightReading>, IBodyWeightRepository
{
    public BodyWeightRepository(SqlLiteDatabase database, IMapper mapper) : base(database, mapper)
    {
    }

    public Task<List<BodyWeightReading>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BodyWeightReading> GetAsync(int id)
    {
        throw new NotImplementedException();
    }
}
