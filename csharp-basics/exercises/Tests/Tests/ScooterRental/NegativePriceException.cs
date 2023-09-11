namespace ScooterRental;

public class NegativePriceException : Exception
{
    public NegativePriceException() : base("Price must be positive.")
    {
    }

}