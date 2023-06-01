using AutoMapper;
using DogsHouse.Core.Dtos;
using DogsHouse.Core.Models;

namespace DogsHouse.API.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Dog,DogDto>().ReverseMap();
        CreateMap<CreateDogDto, Dog>();
    }
}