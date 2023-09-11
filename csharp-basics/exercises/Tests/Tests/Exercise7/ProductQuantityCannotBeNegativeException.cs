namespace Exercise7;

public class ProductQuantityCannotBeNegativeException : Exception
{
    public ProductQuantityCannotBeNegativeException() : base("Product quantity cannot be negative.") { }
}