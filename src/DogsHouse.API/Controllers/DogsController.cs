using AutoMapper;
using DogsHouse.Core.Dtos;
using DogsHouse.Core.Models;
using DogsHouse.Core.Pagination;
using DogsHouse.Core.Parameters;
using DogsHouse.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DogsHouse.API.Controllers;

[ApiController]
public class DogsController : ControllerBase
{
    private readonly IDogsHouseService _dogsHouseService;
    private readonly IMapper _mapper;

    public DogsController(
        IDogsHouseService dogsHouseService,
        IMapper mapper)
    {
        _dogsHouseService = dogsHouseService;
        _mapper = mapper;
}

    [HttpGet]
    [Route("/dogs")]
    public async Task<IEnumerable<DogDto>> GetDogs([FromQuery] Page? page, [FromQuery] DogParameter? dogParameter)
    {
        var result = await _dogsHouseService.GetDogs(page ?? new Page(), dogParameter ?? new DogParameter());
        var response = _mapper.Map<IEnumerable<DogDto>>(result);

        return response;
    }

    [HttpPost]
    [Route("/dog")]
    public async Task<Dog> CreateDog([FromBody] CreateDogDto createDogDto)
    {
        var dog = _mapper.Map<Dog>(createDogDto);
        await _dogsHouseService.Create(dog);

        return dog;
    }

    [HttpGet]
    [Route("/ping")]
    public async Task<IActionResult> Ping()
    {
        return Ok(_dogsHouseService.Ping());
    }
}
