namespace ScooterRental;

public class ScooterIdDoesNotExistException : Exception
{
    public ScooterIdDoesNotExistException(): base("Scooter Id does not exist.") { }
}