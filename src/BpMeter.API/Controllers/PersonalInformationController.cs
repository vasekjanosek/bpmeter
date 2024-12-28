using AutoMapper;
using BpMeter.Application.Abstractions;
using BpMeter.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BpMeter.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonalInformationController : ControllerBase
{
    private readonly IPersonalInformationService _personalInfromationService;
    private readonly IMapper _mapper;

    public PersonalInformationController(IPersonalInformationService personalInfromationService, IMapper mapper)
    {
        _personalInfromationService = personalInfromationService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<PersonalInformationDto> GetPersonalInformation()
    {
        var personalInfromation = await _personalInfromationService.GetPersonalInformationAsync();

        return _mapper.Map<PersonalInformationDto>(personalInfromation);
    }

    [HttpPost]
    public async Task<CreatedResult> AddPersonalInformation([FromBody]PersonalInformationDto data)
    {
        await _personalInfromationService.AddPersonalInformationAsync(
            data.FirstName,
            data.MiddleName,
            data.LastName,
            data.BirthDate != null ? DateOnly.FromDateTime(data.BirthDate.Value) : DateOnly.MinValue,
            data.HeightInCm ?? -1);

        return Created();
    }
}
