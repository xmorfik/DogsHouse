using DogsHouse.Core.Models;
using DogsHouse.Core.Pagination;
using DogsHouse.Core.Parameters;

namespace DogsHouse.Core.Repositories;

public interface IDogRepository
{
    public Dog Create(Dog dog);

    public Task<IEnumerable<Dog>> GetDogs(Page? page, DogParameter dogParameter);
}