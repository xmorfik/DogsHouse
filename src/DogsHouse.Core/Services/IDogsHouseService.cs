using DogsHouse.Core.Models;
using DogsHouse.Core.Pagination;
using DogsHouse.Core.Parameters;

namespace DogsHouse.Core.Services;

public interface IDogsHouseService
{
    public Task<Dog> Create(Dog dog);

    public Task<IEnumerable<Dog>> GetDogs(Page? page, DogParameter dogParameter);

    public string Ping();
}
