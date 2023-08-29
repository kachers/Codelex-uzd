namespace Exercise7;

internal class SavingsAccount
{
    private double _balance;
    public double AnnualInterestRate;

    public SavingsAccount(double startBal)
    {
        this._balance = startBal;
    }

    public void Withdraw(double amount)
    {
        _balance -= amount;
    }

    public void Deposit(double amount)
    {
        _balance += amount;
    }

    public void AddMonthlyInterest()
    {
        var monthlyInterestRate = _balance * AnnualInterestRate / 12;
        _balance += monthlyInterestRate;
    }

    public double GetBalance()
    {
        return _balance;
    }

    public double GetMonthlyInterestAmount()
    {
        var monthlyInterestRate = _balance * AnnualInterestRate / 12;
        return monthlyInterestRate;
    }
}