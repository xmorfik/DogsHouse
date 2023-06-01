using DogsHouse.Core.Enums;

namespace DogsHouse.Core.Parameters;

public class DogParameter
{
    public bool IsDecreasing { get; set; }

    public DogAttribute? DogAttribute { get; set; }
}
