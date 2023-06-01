namespace DogsHouse.Core.Exceptions;

public class DogNameException : Exception
{
    public DogNameException(string dogName)
        : base($"Dog name: {dogName} already exists.")
    {
    }
}
