using DogsHouse.Core.Enums;
using DogsHouse.Core.Exceptions;
using DogsHouse.Core.Models;
using DogsHouse.Core.Pagination;
using DogsHouse.Core.Parameters;
using DogsHouse.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DogsHouse.Data.Repositories;

public class DogRepository : IDogRepository
{
    private readonly ApplicationDbContext _dbContext;
    public DogRepository(
        ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Dog Create(Dog dog)
    {
        if(_dbContext.Dogs.Any(x => x.Name ==  dog.Name))
        {
            throw new DogNameException(dog.Name);
        }

        _dbContext.Dogs.Add(dog);

        return dog;
    }

    public async Task<IEnumerable<Dog>> GetDogs(Page? page, DogParameter dogParameter)
    {
        IQueryable<Dog> querry = _dbContext.Dogs;

        if (dogParameter.DogAttribute.HasValue)
        {
            switch (dogParameter.DogAttribute)
            {
                case DogAttribute.Name:
                    if (dogParameter.IsDecreasing)
                    {
                        querry = querry.OrderByDescending(x => x.Name);
                        break;
                    }
                    querry = querry.OrderBy(x => x.Name);
                    break;

                case DogAttribute.Colour:
                    if (dogParameter.IsDecreasing)
                    {
                        querry = querry.OrderByDescending(x => x.Colour);
                        break;
                    }
                    querry = querry.OrderBy(x => x.Colour);
                    break;

                case DogAttribute.TailLength:
                    if (dogParameter.IsDecreasing)
                    {
                        querry = querry.OrderByDescending(x => x.TailLength);
                        break;
                    }
                    querry = querry.OrderBy(x => x.TailLength);
                    break;

                case DogAttribute.Weight:
                    if (dogParameter.IsDecreasing)
                    {
                        querry = querry.OrderByDescending(x => x.Weight);
                        break;
                    }
                    querry = querry.OrderBy(x => x.Weight);
                    break;

                default:
                    if (dogParameter.IsDecreasing)
                    {
                        querry = querry.OrderByDescending(x => x.Id);
                        break;
                    }
                    querry = querry.OrderBy(x=> x.Id);
                    break;
            }
        }
        else
        {
            if (dogParameter.IsDecreasing)
            {
                querry = querry.OrderByDescending(x => x.Id);
            }
            else
            {
                querry = querry.OrderBy(x => x.Id);
            }
        }

        if (page != null)
        {
            querry = querry.Skip((page.PageNumber - 1) * page.PageSize).Take(page.PageSize);
        }

        var result = await querry.ToArrayAsync();

        return result;
    }
}
