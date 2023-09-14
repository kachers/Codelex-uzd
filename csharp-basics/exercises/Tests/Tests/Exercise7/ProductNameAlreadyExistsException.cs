namespace Exercise7;

public class ProductNameAlreadyExistsException : Exception
{
    public ProductNameAlreadyExistsException () : base("Product name already exists.") { }
}