namespace Exercise7
{
    public class NegativeMoneyValueException : Exception
    {
        public NegativeMoneyValueException() : base(" Money value can't be negative")
        {
        }
    }
}
