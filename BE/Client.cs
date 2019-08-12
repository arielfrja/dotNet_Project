using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Client
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CurrentLocation { get; set; }
        public int CreditCardNumber { get; set; }
        public int age { get; set; }
        public override string ToString()
        {
            return "Name: " + Name
                + "\n Address: " + Address
                + "\n Current Location: " + CurrentLocation
                + "\n Credit card number: " + CreditCardNumber;
        }
    }
}
