namespace Exercise7
{
    public class ProductNameCannotBeNullOrEmptyException : Exception
    {
        public ProductNameCannotBeNullOrEmptyException() : base("Product name cant be null or empty string")
        {
        }
    }
}
