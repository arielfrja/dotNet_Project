using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

    public class Dish
    {
        public Dish(string dishname,int dishsize,int dishprize,Kashrut k,TimeSpan t)
        {
            DishName = dishname;
            DishPrice = dishprize;
            DishSize = dishsize;
            KashrutLevel = k;
            PreparingTime = t;
        }
         public Dish()
        {
            DishName ="";
            DishPrice = 0;
            DishSize = 0;
         }

        public int DishID { get; set; }
        public string DishName { get; set; }
        public int DishSize { get; set; }
        public float DishPrice { get; set; }
        public Kashrut KashrutLevel { get; set; }
        public DishSituation DS { get; set; }
        public TimeSpan PreparingTime { get; set; }
        public override string ToString()
        {
            return "Dish ID: " + DishID.ToString()
              + "\n Dish name: " + DishName
              + "\n Dish size: " + DishSize.ToString()
              + "\n Dish price: " + DishPrice.ToString()
              + "\n Kashrut level: " + KashrutLevel.ToString()
              + "\n Preparing time: " + PreparingTime.Hours.ToString() + ":" + PreparingTime.Minutes.ToString();
        }
    }
}
