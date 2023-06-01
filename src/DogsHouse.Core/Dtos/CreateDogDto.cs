using System.ComponentModel.DataAnnotations;

namespace DogsHouse.Core.Dtos;

public class CreateDogDto
{
    public string Name { get; set; }

    public string Colour { get; set; }

    [Range(Constants.MinTailLength,Constants.MaxTailLength)]
    public int TailLength { get; set; }

    [Range(Constants.MinWeight, Constants.MaxWeight)]
    public int Weight { get; set; }
}
