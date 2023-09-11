namespace ScooterRental;

public class InvalidIdException : Exception
{
    public InvalidIdException() : base("Id can't be empty or null")
    {
    }
}