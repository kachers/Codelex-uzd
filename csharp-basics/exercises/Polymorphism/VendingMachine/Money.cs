using System.Diagnostics;
using System.Xml.Linq;

namespace VendingMachine
{
    public struct Money
    {
        public Money(int euros, int cents)
        {
            Euros = euros;
            Cents = cents;
        }
        public int Euros { get; set; }
        public int Cents { get; set; }
    }
}
