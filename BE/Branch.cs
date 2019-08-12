using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

    public class Branch
    {
        public Branch(string name,string address, string phone,int workers, Kashrut k)
        {
            Name = name;
            Address = address;
            PhoneNumber = phone;
            WorkersAmount = workers;
            KashrutLevel = k;
        }
        public Branch()
        {
            Name = "";
            Address = "";
            PhoneNumber = "0";
            WorkersAmount = 0;
        }
        public BranchSituation BS { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkersAmount { get; set; }
        public Kashrut KashrutLevel { get; set; }
        public override string ToString()
        {
            return "Branch number: " + Number.ToString()
                + "\n Branch name: " + Name.ToString()
                + "\n Branch address: " + Address.ToString()
                + "\n Branch phone number: " + PhoneNumber.ToString()
                + "\n Workers amount: " + WorkersAmount.ToString()
               
                + "\n Kashrut level: " + KashrutLevel.ToString();
        }
    }
}
