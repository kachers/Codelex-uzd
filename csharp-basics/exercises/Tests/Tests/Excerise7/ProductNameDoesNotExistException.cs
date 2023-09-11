namespace Exercise7
{
    public class ProductNameDoesNotExistException : Exception
    {
        public ProductNameDoesNotExistException() : base("Product name does not exist")
        {
        }
    }
}
