using AutoMapper;
using BpMeter.Application.Abstractions;
using BpMeter.Domain;
using BpMeter.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BpMeter.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BodyWeightController : ControllerBase
{
    private readonly IBwReadingService _bwReadingService;
    private readonly IMapper _mapper;

    public BodyWeightController(IBwReadingService bwReadingService, IMapper mapper)
    {
        _bwReadingService = bwReadingService;
        _mapper = mapper;
    }

    [HttpGet()]
    public async Task<IEnumerable<BodyWeightDto>> GetAllReadings()
    {
        var allReadings = await _bwReadingService.GetAllReadingsAsync();

        return _mapper.Map<IEnumerable<BodyWeightDto>>(allReadings);
    }

    [HttpPost]
    public async Task<CreatedResult> AddReading([FromBody] BodyWeightDto data)
    {
        var reading = _mapper.Map<BodyWeightReading>(data);

        await _bwReadingService.AddNewReadingAsync(reading);

        return Created();
    }
}
