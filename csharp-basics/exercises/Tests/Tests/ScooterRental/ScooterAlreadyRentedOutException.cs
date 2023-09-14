namespace ScooterRental;

public class ScooterAlreadyRentedOutException : Exception
{
    public ScooterAlreadyRentedOutException() : base ("Throw scooter already rented out")
    {
    }
}