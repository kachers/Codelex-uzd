namespace Exercise7;

public class AvailableCannotBeNegativeException : Exception
{
    public AvailableCannotBeNegativeException() : base("Available quantity cannot be negative")
    {
    }
}