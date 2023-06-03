using DogsHouse.Core.Interfaces;
using DogsHouse.Core.Models;
using DogsHouse.Core.Pagination;
using DogsHouse.Core.Parameters;
using DogsHouse.Core.Repositories;
using DogsHouse.Core.Services;
using System.Reflection;

namespace DogsHouse.BL.Services;

public class DogsHouseService : IDogsHouseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDogRepository _dogRepository;
    public DogsHouseService(
        IUnitOfWork unitOfWork,
        IDogRepository dogRepository)
    {
        _unitOfWork = unitOfWork;
        _dogRepository = dogRepository;
    }

    public async Task<Dog> Create(Dog dog)
    {
        _dogRepository.Create(dog);
        await _unitOfWork.SaveChangesAsync();

        return dog;
    }

    public Task<IEnumerable<Dog>> GetDogs(Page? page, DogParameter dogParameter)
    {
        return _dogRepository.GetDogs(page, dogParameter);
    }

    public string Ping()
    {
        return this.GetType().Name + ". Version : " + Assembly.GetExecutingAssembly().GetName().Version;
    }
}
