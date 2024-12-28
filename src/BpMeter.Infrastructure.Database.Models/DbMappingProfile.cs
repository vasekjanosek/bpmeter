using AutoMapper;
using BpMeter.Domain;

namespace BpMeter.Infrastructure.Database.Entites;

public class DbMappingProfile : Profile
{
    public DbMappingProfile()
    {
        CreateMap<BloodPressureEntity, BloodPressureReading>().ReverseMap();
        CreateMap<BodyWeightEntity, BodyWeightReading> ().ReverseMap();
        CreateMap<PersonalInformationEntity, PersonalInformation>().ReverseMap();
    }
}
