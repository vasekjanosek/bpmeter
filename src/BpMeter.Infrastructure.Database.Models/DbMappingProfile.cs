using AutoMapper;
using BpMeter.Domain;
using BpMeter.Infrastructure.Database.Enitites;

namespace BpMeter.Infrastructure.Repositories.Models;

internal class DbMappingProfile : Profile
{
    public DbMappingProfile()
    {
        CreateMap<BloodPressureEntity, BloodPressureReading>().ReverseMap();
        CreateMap<BodyWeightEntity, BodyWeightReading> ().ReverseMap();
        CreateMap<PersonalInformationEntity, PersonalInformation>().ReverseMap();
    }
}
