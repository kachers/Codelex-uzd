namespace Exercise1;

internal class Product
{
    private int amount;
    private string name;
    private double price;

    public Product(string name, double priceAtStart, int amountAtStart)
    {
        this.name = name;
        this.price = priceAtStart;
        this.amount = amountAtStart;
    }

    public void PrintProduct()
    {
        Console.WriteLine($"{name}, price {price} EUR, amount {amount} units");
    }

    public void ChangeAmount(int newAmount)
    {
        amount = newAmount;
    }

    public void ChangePrice(double newPrice)
    {
        price = newPrice;
    }
}