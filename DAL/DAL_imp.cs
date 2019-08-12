using BE;
using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    class DAL_imp : Idal
    {
        static int CurrentDishID = 1;
        static int CurrentBranchNumber = 1;
        static int CurrentOrdernNumber = 1;
        static int CurrentOrdernDishNumber = 1;
        public void AddUser(User u)
        {
            if(u.US==UserSituation.CLOSED)
                u.US=UserSituation.EXIST;
            else
            {
                DS.DataSource.User_List.Add(u);
            }
            
        }
        public void RemoveUser(User u)
        {
            User U = getUser(u.Username);
            U.US = UserSituation.CLOSED;
        }
        public void AddDish(Dish D)
        {
            if (D.DS == DishSituation.REMOVED)
                D.DS = DishSituation.EXIST;
            else
            {
                D.DishID = CurrentDishID;
                CurrentDishID++;
                DataSource.DishesList.Add(D);
            }
            
        }

        public void RemoveDish(Dish D)
        {
            Dish d = getDish(D.DishID);
            d.DS = DishSituation.REMOVED;
        }

        public void UpdateDishDetails(Dish D)//change the Boolean to exeption
        {
            Dish d=getDish(D.DishID);
            d=D;

        }

        public void AddBranch(Branch B)
        {
            if (B.BS == BranchSituation.CLOSED)
                B.BS = BranchSituation.EXIST;
            else
            {
                B.Number = CurrentBranchNumber;
                CurrentBranchNumber++;
                DataSource.BranchesList.Add(B);
            }

        }

        public void RemoveBranch(Branch B)
        {
            Branch b = getBranch(B.Number);
            b.BS = BranchSituation.CLOSED;
        }
            
        public void UpdateBranchDetails(Branch B)
        {
            Branch b = getBranch(B.Number);
            b = B;
        }

        public void AddOrder(Order O)
        {
            O.orderID = CurrentOrdernNumber;
            O.date = DateTime.Now;
            CurrentOrdernNumber++;
            DataSource.OrdersList.Add(O);
        }

        public void RemoveOrder(Order O)
        {
            Order o = getOrder(O.orderID);
            o.OS = OrderSituation.CANCEL;
        }

        public void UpdateOrderDetails(Order O)
        {
            Order o = getOrder(O.orderID);
            o = O;
        }
          

        public void AddOrdered_Dish(Ordered_Dish OD)
        {
            OD.OrderedDish_Number = CurrentOrdernDishNumber;
            CurrentOrdernDishNumber++;
 
            DataSource.Ordered_DishesList.Add(OD);
        }

        public void RemoveOrdered_Dish(Ordered_Dish OD)
        {
            Ordered_Dish od = get_OrderedDish(OD.OrderedDish_Number);
            od.ODS = OrderedDish_Situation.CANCELED;
        }

        public void UpdateOrdered_DishDetails(Ordered_Dish OD)
        {
            Ordered_Dish od = get_OrderedDish(OD.OrderedDish_Number);
            od = OD;
        }

        public List<Dish> GetDishesList()
        {
            return DataSource.DishesList;
        }

        public List<Order> GetOrdersList()
        {
            return DataSource.OrdersList;
        }
        public List<Branch> GetBranchesList()
        {
            return DataSource.BranchesList;
        }

        public List<User> GetUsersList()
        {
            return DataSource.User_List;
        }
        public Dish getDish(int id)
        {
            var x = from e in DataSource.DishesList
                    where e.DishID == id
                    select e;
            return x.FirstOrDefault();
        }
        public Branch getBranch(int num)
        {
            var x = from e in DataSource.BranchesList
                    where e.Number == num
                    select e;
            return x.FirstOrDefault();
        }
        public Order getOrder(int orderId)
        {
         
            return DataSource.OrdersList.Find(x => x.orderID == orderId);
        }
        public Ordered_Dish get_OrderedDish(int num)
        {
            var x = from e in DataSource.Ordered_DishesList
                    where e.OrderedDish_Number == num
                    select e;
            return x.FirstOrDefault();

        }
        public User getUser(string username)
        {
            var x = from e in DataSource.User_List
                    where e.Username == username
                    select e;
            return x.FirstOrDefault();

        }
       
        public List<Ordered_Dish> GetOrderedDishes_list()
        {
            return DataSource.Ordered_DishesList;
        }


        public void SendOrder(Order O)
        {
            Order o = getOrder(O.orderID);
            o.OS = OrderSituation.SENT;
        }


        public void ODchange_to_finish(Ordered_Dish od)
        {
            od.ODS = OrderedDish_Situation.FINISH;
        }

        public void OrderToSent(Order o)
        {
            o.OS= OrderSituation.SENT;
        }
    }
}