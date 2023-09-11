namespace Exercise7;

public class ProductNumberCannotBeNegativeException : Exception
{
    public ProductNumberCannotBeNegativeException() : base("Product number cannot be negative") { }
}