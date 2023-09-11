namespace Exercise7;

public class NoCoinsInsertedException : Exception
{
    public NoCoinsInsertedException() : base("No Coins Inserted.")
    {
    }
}