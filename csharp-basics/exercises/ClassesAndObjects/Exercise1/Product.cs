namespace Exercise1;

internal class Product
{
    private int _amount;
    private readonly string _name;
    private double _price;

    public Product(string name, double priceAtStart, int amountAtStart)
    {
        _name = name;
        _price = priceAtStart;
        _amount = amountAtStart;
    }

    public void PrintProduct()
    {
        Console.WriteLine($"{_name}, _price {_price} EUR, _amount {_amount} units");
    }

    public void ChangeAmount(int newAmount)
    {
        _amount = newAmount;
    }

    public void ChangePrice(double newPrice)
    {
        _price = newPrice;
    }
}