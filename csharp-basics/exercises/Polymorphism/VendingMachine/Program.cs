using System;
using System.Collections.Generic;

namespace VendingMachine
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var snickerPrice = new Money(1, 99);
            var marsPrice = new Money(1, 95);
            var twixPrice = new Money(1, 11);
            var spritePrice = new Money(2, 50);

            var sniker = new Product("Sniker", snickerPrice, 1);
            var mars = new Product("Mars", marsPrice, 1);
            var twix = new Product("Twix", twixPrice, 1);

            Product[] products = { sniker, mars, twix };

            var machine = new VendingMachine("Philips", products);


            machine.AddProduct("Sprite", spritePrice, 2);

            MainMenu(machine);
        }

        private static void BuyProduct(VendingMachine machine)
        {
            var dictionary = new Dictionary<string, Product>();
            Random random = new();

            Console.WriteLine("\nID    Name    Price  Quantity");
            foreach (var product in machine.Products)
            {
                var id = $"#{random.Next(1000, 9999)}";
                dictionary.Add(id, product);
                Console.WriteLine($"{id} {product}");
            }

            Console.WriteLine("\nEnter product ID (Format: #****)");
            var userChoice = Console.ReadLine();
            dictionary.TryGetValue(userChoice, out var chosenProduct);
            var productName = chosenProduct.Name.ToLower();
            var productPrice = chosenProduct.Price.Euros * 100 + chosenProduct.Price.Cents;
            var balance = machine.Amount.Euros*100+machine.Amount.Cents;


            if (productPrice > balance)
            {
                Console.WriteLine("Balance too low. Insert coins.");
            }
            else if (chosenProduct.Available == 0)
            {
                Console.WriteLine("Out of stock! Choose different product.");
            }
            else
            {
                Console.WriteLine($"You bought {chosenProduct.Name}");
                DeductMoney(machine, chosenProduct);
                var newAmount = chosenProduct.Available - 1;
                machine.UpdateProduct(1, productName, chosenProduct.Price, newAmount);
            }
        }

        private static void MainMenu(VendingMachine machine)
        {
            var userChoice = "10";
            while (!userChoice.Equals("0"))
            {
                var euros = machine.Amount.Euros.ToString();
                var cents = machine.Amount.Cents.ToString();
                Console.WriteLine("\n\nVending Machine: ");
                Console.WriteLine(machine.Amount.Cents < 10 ? $"Balance: ${euros}.0{cents}" : $"Balance: ${euros}.{cents}");
                Console.WriteLine("========================");
                Console.WriteLine("Options: ");
                Console.WriteLine("1. Choose product");
                Console.WriteLine("2. Insert coins");
                Console.WriteLine("3. Return money");
                Console.WriteLine("0. Exit");

                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        BuyProduct(machine);
                        break;
                    case "2":
                        ReceiveMoney(machine);
                        break;
                    case "3":
                        var balance = machine.Amount.Euros * 100 + machine.Amount.Cents;
                        if (balance < 10)
                        {
                            Console.WriteLine("Sorry, balance too low!");
                        }
                        else
                        {
                            var eurosReturned = machine.Amount.Euros;
                            var centsReturned = machine.Amount.Cents;
                            machine.ReturnMoney();
                            Console.WriteLine($"Returned ${eurosReturned}.{centsReturned}");
                        }
                        break;
                    case "0":
                        Console.WriteLine("Exiting program....");
                        break;
                }
            }
        }

        private static Money ReceiveMoney(VendingMachine machine)
        {
            var moneyReceived = 0;
            var euros = machine.Amount.Euros.ToString();
            var cents = machine.Amount.Cents.ToString();
            Console.WriteLine(machine.Amount.Cents < 10 ? $"Balance: ${euros}.0{cents}" : $"Balance: ${euros}.{cents}");
            Console.WriteLine("======================");
            Console.WriteLine("Choose coin to insert:");
            Console.WriteLine("1 - 0.10 Euros");
            Console.WriteLine("2 - 0.20 Euros");
            Console.WriteLine("3 - 0.50 Euros");
            Console.WriteLine("4 - 1.00 Euros");
            Console.WriteLine("5 - 2.00 Euros");
            var userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("0.10 Euros inserted");
                    moneyReceived += 10;
                    break;
                case "2":
                    Console.WriteLine("0.20 Euros inserted");
                    moneyReceived += 20;
                    break;
                case "3":
                    Console.WriteLine("0.50 Euros inserted");
                    moneyReceived += 50;
                    break;
                case "4":
                    Console.WriteLine("1.00 Euros inserted");
                    moneyReceived += 100;
                    break;
                case "5":
                    Console.WriteLine("2.00 Euros inserted");
                    moneyReceived += 200;
                    break;
            }

            var centsInserted = moneyReceived % 100;
            var eurosInserted = (moneyReceived - centsInserted) / 100;

            Money moneyInserted = new(eurosInserted, centsInserted);
            machine.InsertCoin(moneyInserted);
            return moneyInserted;
        }

        private static void DeductMoney(VendingMachine machine, Product product)
        {
            var productPrice = product.Price.Euros * 100 + product.Price.Cents;
            var totalBalance = machine.Amount.Euros*100 + machine.Amount.Cents;
            var totalCentsLeft = totalBalance - productPrice;
            int euros;

            if (totalCentsLeft >= 100) euros = totalCentsLeft - totalCentsLeft % 10;
            else euros = 0;
            
            machine.Amount = new Money(Math.Abs(euros), totalCentsLeft);
        }
    }
}