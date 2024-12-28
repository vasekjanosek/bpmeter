using BpMeter.Domain.Abstractions;
using BpMeter.Domain;
using BpMeter.Infrastructure.Database.PostgreSQL;
using AutoMapper;
using BpMeter.Infrastructure.Database.Entites;
using Microsoft.EntityFrameworkCore;

namespace BpMeter.Infrastructure.Database.Repositories;

internal class BloodPressureRepository : Repository<BloodPressureEntity, BloodPressureReading>, IBloodPressureRepository
{
    public BloodPressureRepository(BpMeterDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public async Task<List<BloodPressureReading>> GetAllAsync()
    {
        var result = await DbContext.BloodPressures.ToListAsync();

        return Mapper.Map<List<BloodPressureReading>>(result);
    }

    public async Task<BloodPressureReading> GetAsync(Guid id)
    {
        var result = await DbContext.BloodPressures.FirstAsync(x => x.Id == id);

        return Mapper.Map<BloodPressureReading>(result);
    }
}
