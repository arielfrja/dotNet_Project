
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

    public class Ordered_Dish
    {
        public OrderedDish_Situation ODS { get; set; }
        //Ordered_Dish(int ordernumber,orderdishnumber)
        public int OrderNumber { get; set; }
        public int OrderedDish_Number { get; set; }
        public int DishNumber { get; set; }
        public int AmountSameDishes { get; set; }
        

        public override string ToString()
        {
            return "OrderNumber:" + OrderNumber.ToString() + "\n" + "DishNumber:" + DishNumber.ToString() + "\n" + "AmountameDishes:"
                + AmountSameDishes.ToString() + "\n";
        }
    }
}
