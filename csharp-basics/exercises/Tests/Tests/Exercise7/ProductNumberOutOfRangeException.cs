namespace Exercise7;

public class ProductNumberOutOfRangeException : Exception
{
    public ProductNumberOutOfRangeException() : base("Product number out of range.")
    {
    }
}