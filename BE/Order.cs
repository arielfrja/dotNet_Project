using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

    public class Order
    {
        
        public int orderID { get; set; }
        public DateTime date { get; set; }
        public int BranchNumber { get; set; }
        public Kashrut kashrutLevel { get; set; }
        public Client client { get; set; }
        public OrderSituation OS { get; set; }
        public override string ToString()
        {
            return "order ID: " + orderID.ToString()
                + "\n Order date: " + date.ToString()
                + "\n Branch number" + BranchNumber.ToString()
                + "\n Kashrut Level:" + kashrutLevel.ToString()
                + client.ToString();

        }
    }
}
