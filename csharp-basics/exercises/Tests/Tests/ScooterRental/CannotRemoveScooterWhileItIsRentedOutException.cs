namespace ScooterRental;

public class CannotRemoveScooterWhileItIsRentedOutException :Exception
{
    public CannotRemoveScooterWhileItIsRentedOutException() : base("Cannot remove scooter while its rented out.")
    {
    }
}