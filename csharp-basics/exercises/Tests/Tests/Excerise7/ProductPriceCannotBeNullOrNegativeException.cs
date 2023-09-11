namespace Exercise7;

public class ProductPriceCannotBeNullOrNegativeException : Exception
{
    public ProductPriceCannotBeNullOrNegativeException() : base("Product price cannot be negative")
    {
    }
}