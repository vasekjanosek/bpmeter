using AutoMapper;
using BpMeter.Domain;
using BpMeter.Domain.Abstractions;
using BpMeter.Domain.Exceptions;
using BpMeter.Infrastructure.Database.Entites;
using BpMeter.Infrastructure.Database.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace BpMeter.Infrastructure.Database.Repositories;

internal class PersonalInformationRepository : Repository<PersonalInformationEntity, PersonalInformation>, IPersonalInformationRepository
{
    public PersonalInformationRepository(BpMeterDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public override async Task<PersonalInformation> InsertAsync(PersonalInformation reading)
    {
        if (await DbContext.PersonalInformation.AnyAsync())
        {
            var entity = await DbContext.PersonalInformation.FindAsync();
            throw new EntityAlreadyExistsException("Personal information already exists!", entity!.Id);
        }

        return await base.InsertAsync(reading);
    }

    public async Task<PersonalInformation> GetAsync()
    {
        var result = await DbContext.PersonalInformation.FirstAsync();

        return Mapper.Map<PersonalInformation>(result);
    }
}
