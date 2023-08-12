namespace Exercise7;

internal class Program
{
    private static void Main(string[] args)
    {
        var startingBalance = ReadDoubleInput("How much money is in the account?:");
        var annualInterestRate = ReadDoubleInput("Enter the annual interest rate:");
        var monthsPassed = (int)ReadDoubleInput("How long has the account been opened?");
        var acc1 = new SavingsAccount(startingBalance);
        acc1.annualInterestRate = annualInterestRate;

        double totalDeposits = 0;
        double totalWithdrawals = 0;
        double totalInterestAdded = 0;

        for (var i = 1; i <= monthsPassed; i++)
        {
            var depositedAmount = ReadDoubleInput($"Enter amount deposited for month: {i}:");
            acc1.Deposit(depositedAmount);
            totalDeposits += depositedAmount;

            var withdrawAmount = ReadDoubleInput($"Enter amount withdrawn for month: {i}:");
            acc1.Withdraw(withdrawAmount);
            totalWithdrawals -= withdrawAmount;

            totalInterestAdded += acc1.GetMonthlyInterestAmount();
            acc1.AddMonthlyInterest();

            if (i == monthsPassed)
                Console.WriteLine($"\nTotal deposited: {totalDeposits:C2}\n" +
                                  $"Total withdrawn: {Math.Abs(totalWithdrawals):C2}\n" +
                                  $"Interest earned: {totalInterestAdded:C2}\n" +
                                  $"Ending balance: {acc1.GetBalance():C2}");
        }
    }

    private static double ReadDoubleInput(string prompt)
    {
        double value;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out value)) return value;
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}