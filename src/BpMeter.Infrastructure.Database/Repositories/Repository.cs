using AutoMapper;
using BpMeter.Domain;
using BpMeter.Domain.Abstractions;
using BpMeter.Infrastructure.Database.Entites;
using BpMeter.Infrastructure.Database.PostgreSQL;

namespace BpMeter.Infrastructure.Database.Repositories;

internal class Repository<T, S> : IRepository<S>
    where T : AuditableEntity
    where S : Reading
{
    protected readonly IMapper Mapper;
    protected readonly BpMeterDbContext DbContext;

    public Repository(BpMeterDbContext dbContext, IMapper mapper)
    {
        Mapper = mapper;
        DbContext = dbContext;
    }

    public virtual async Task DeleteAsync(S reading)
    {
        await DeleteInternalAsync(reading);
    }

    public virtual async Task<S> InsertAsync(S reading)
    {
        return await InsertInternalAsync(reading);
    }

    public virtual async Task<S> UpdateAsync(S reading)
    {
        return await UpdateInternalAsync(reading);
    }

    private async Task DeleteInternalAsync(S reading)
    {
        var entity = Mapper.Map<T>(reading);
        DbContext.Remove(entity);

        await DbContext.SaveChangesAsync();
    }

    private async Task<S> InsertInternalAsync(S reading)
    {
        var entity = Mapper.Map<T>(reading);
        var result = DbContext.Update(entity);

        await DbContext.SaveChangesAsync();

        return Mapper.Map<S>(result.Entity);
    }

    private async Task<S> UpdateInternalAsync(S reading)
    {
        var entity = Mapper.Map<T>(reading);
        var result = DbContext.Update(entity);

        await DbContext.SaveChangesAsync();

        return Mapper.Map<S>(result.Entity);
    }
}
