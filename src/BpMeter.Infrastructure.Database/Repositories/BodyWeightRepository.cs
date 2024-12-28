using AutoMapper;
using BpMeter.Domain;
using BpMeter.Domain.Abstractions;
using BpMeter.Infrastructure.Database.Entites;
using BpMeter.Infrastructure.Database.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace BpMeter.Infrastructure.Database.Repositories;

internal class BodyWeightRepository : Repository<BodyWeightEntity, BodyWeightReading>, IBodyWeightRepository
{
    public BodyWeightRepository(BpMeterDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public async Task<List<BodyWeightReading>> GetAllAsync()
    {
        var result = await DbContext.BodyWeights.ToListAsync();

        return Mapper.Map<List<BodyWeightReading>>(result);
    }

    public async Task<BodyWeightReading> GetAsync(Guid id)
    {
        var result = await DbContext.BodyWeights.FirstAsync(x => x.Id == id);

        return Mapper.Map<BodyWeightReading>(result);
    }

    public async Task<BodyWeightReading> GetNewestAsync()
    {
        var result = await DbContext.BodyWeights.OrderByDescending(x => x.DateTime).FirstAsync();

        return Mapper.Map<BodyWeightReading>(result);
    }
}
