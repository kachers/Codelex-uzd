using System;

namespace VendingMachine
{
    public struct Product
    {
        public Product(string name, Money price,int available)
        {
            Name = name;
            Available = available;
            Price = price;
        }
        public int Available { get; set; }

        public Money Price { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            double price = Price.Euros + ((double)Price.Cents / 100);
            return string.Format("{0, -6}: {1, 1:C2}  Quant: {2, 1}", Name, price, Available);
        }
    }
}
