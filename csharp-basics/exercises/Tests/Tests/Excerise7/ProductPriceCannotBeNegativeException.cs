namespace ScooterRental;

public class ProductPriceCannotBeNegativeException : Exception
{
    public ProductPriceCannotBeNegativeException() : base("Product price cannot be negative.")
    {
    }
}