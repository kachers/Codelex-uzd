namespace Exercise7;

internal class SavingsAccount
{
    private double balance;
    public double annualInterestRate;

    public SavingsAccount(double startBal)
    {
        this.balance = startBal;
    }

    public void Withdraw(double amount)
    {
        balance -= amount;
    }

    public void Deposit(double amount)
    {
        balance += amount;
    }

    public void AddMonthlyInterest()
    {
        var monthlyInterestRate = balance * annualInterestRate / 12;
        balance += monthlyInterestRate;
    }

    public double GetBalance()
    {
        return balance;
    }

    public double GetMonthlyInterestAmount()
    {
        var monthlyInterestRate = balance * annualInterestRate / 12;
        return monthlyInterestRate;
    }
}