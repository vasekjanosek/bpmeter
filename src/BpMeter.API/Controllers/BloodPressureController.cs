using AutoMapper;
using BpMeter.Application.Abstractions;
using BpMeter.Domain;
using BpMeter.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BpMeter.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BloodPressureController : ControllerBase
{
    private readonly IBpReadingService _bpReadingService;
    private readonly IMapper _mapper;

    public BloodPressureController(IBpReadingService bpReadingService, IMapper mapper)
    {
        _bpReadingService = bpReadingService;
        _mapper = mapper;
    }

    [HttpGet()]
    public async Task<IEnumerable<BloodPressureDto>> GetAllReadings()
    {
        var allReadings = await _bpReadingService.GetAllReadingsAsync();

        return _mapper.Map<IEnumerable<BloodPressureDto>>(allReadings);
    }

    [HttpPost]
    public async Task<CreatedResult> AddReading([FromBody] BloodPressureDto data)
    {
        var reading = _mapper.Map<BloodPressureReading>(data);

        await _bpReadingService.AddNewReadingAsync(reading);

        return Created();
    }
}
