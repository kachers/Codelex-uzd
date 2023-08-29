namespace Account;

internal class Account
{
    private readonly string _owner;
    private double _balance;

    public Account(string name, double startBalance)
    {
        _owner = name;
        _balance = startBalance;
    }

    public void Withdrawal(double amount)
    {
        _balance -= amount;
    }

    public void Deposit(double amount)
    {
        _balance += amount;
    }

    public double Balance()
    {
        return _balance;
    }

    public override string ToString()
    {
        return $"{_owner}: {_balance:C}";
    }
}