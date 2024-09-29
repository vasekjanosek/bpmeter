using AutoMapper;
using BpMeter.Domain;

namespace BpMeter.Infrastructure.Repositories.Models;

internal class DbMappingProfile : Profile
{
    public DbMappingProfile()
    {
        CreateMap<DbBloodPressureReading, BloodPressureReading>().ReverseMap();
    }
}
