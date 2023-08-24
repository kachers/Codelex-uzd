using System;
using System.Linq;

namespace VendingMachine
{
    internal class VendingMachine : IVendingMachine
    {
        public VendingMachine(string manufacturer, Product[] products)
        {
            Manufacturer = manufacturer;
            Products = products;
        }

        public string Manufacturer { get; set; }

        public bool HasProducts { get; set; }

        public Money Amount { get; set; }

        public Product[] Products { get; set; }

        public bool AddProduct(string name, Money price, int count)
        {
            var newProduct = new Product
            {
                Name = name,
                Price = price,
                Available = count
            };

            Products = Products.Concat(new[] { newProduct }).ToArray();
            return true;
        }

        public Money InsertCoin(Money amount)
        {
            var euros = Amount.Euros+ amount.Euros;
            var cents = Amount.Cents+ amount.Cents;
            if (cents >= 100)
            {
                euros += cents / 100;
                cents %= 100;
            }

            Money newAmount = new(euros, cents);
            Amount = newAmount;
            return newAmount;
        }

        public Money ReturnMoney()
        {
            var centsLeft = Amount.Cents % 10;
            var amountLeft = new Money(0, centsLeft);
            Amount = amountLeft;
            return amountLeft;
        }

        public bool UpdateProduct(int productNumber, string name, Money? price, int amount)
        {
            for (var i = 0; i < Products.Length; i++)
            {
                if (Products[i].Name.ToLower() == name)
                {
                    Products[i].Available = amount;
                }
            }

            return true;
        }
    }
}