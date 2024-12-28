using AutoMapper;
using BpMeter.Domain;
using BpMeter.Dto;

namespace BpMeter.API.MappingProfiles;

public class DtoMappingProfile : Profile
{
    public DtoMappingProfile()
    {
        CreateMap<BloodPressureReading, BloodPressureDto>().ReverseMap();
        CreateMap<BodyWeightReading, BodyWeightDto>().ReverseMap();
        CreateMap<PersonalInformation, PersonalInformationDto>().ReverseMap();
    }
}
