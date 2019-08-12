using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
namespace BL
{
    public class BL_imp : IBL
    {
        Idal dal;
        //
        //בכל פונקציות ההוספה מתבצעת בדיקה האם כבר קיים ערך כמו הערך שאותו אנו מעוניינם להוסיף, ורק אם הוא איננו קיים הוא מתווסף
        //

        //
        // בכל פונקציות ההסרה/עדכון אנו בודקים אם הערך אותו אנו מעוניינים למחוק/לעדכן קיים
        //

        // בפונקציות ההוספה/עדכון/הסרה, הפונקציה קוראת לשכתבת הנתונים, מטפלת בערך, ומחזירה לשכבת הנתונים את הנתונים החדשים

        public BL_imp()
        {
            dal = FactoryDal.getDal();
        }
        public void AddUser(User U)
        {

            if (SearchAtUsersList(U))
            {
                throw new Exception("The user is already exist");
            }
            else
                dal.AddUser(U);
        }
        public void RemoveUser(BE.User U)
        {
            if (!SearchAtUsersList(U))
                throw new Exception("The di is not exist");
            else
                dal.RemoveUser(U);


        }
        public void AddDish(Dish D)
        {

            if (SearchAtDishesList(D))
            {
                throw new Exception("The dish is already exist");
            }

            else
                dal.AddDish(D);



        }
        public void RemoveDish(Dish D)
        {

            if (!SearchAtDishesList(D))
                throw new Exception("The dish is not exist");
            else
                dal.RemoveDish(D);


        }
        public void UpdateDishDetails(Dish D)
        {

            if (!SearchAtDishesList(D))
                throw new Exception("The dish is not exsist");
            else
                dal.UpdateDishDetails(D);


        }
        public void AddBranch(Branch B)
        {

            if (SearchAtBranchesList(B))
                throw new Exception("The branch is already exist");
            if (SearchAtBranchesListByAddress(B))
                throw new Exception("there is branch in this address yet");
            if (SearchAtBranchesListByTelephone(B))
                throw new Exception("There branch with this telephone yet");
            else
                dal.AddBranch(B);

        }
        public void RemoveBranch(Branch B)
        {
            try
            {
                if (!SearchAtBranchesList(B))
                    throw new Exception("The branch is not exsist");
                else
                    dal.RemoveBranch(B);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void UpdateBranchDetails(Branch B)
        {
            try
            {
                if (!SearchAtBranchesList(B))
                    throw new Exception("The branch is not exist");
                else
                    dal.UpdateBranchDetails(B);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void AddOrder(Order O)
        {

            if (SearchAtOrderesList(O))
            {
                throw new Exception("The order is already exist");
            }

            else
                dal.AddOrder(O);


        }
        public void RemoveOrder(Order O)
        {

            if (!SearchAtOrderesList(O))
                throw new Exception("The order is not exist");
            foreach (Ordered_Dish item in Ordered_Dishes_Of_Order(O.orderID))
                dal.RemoveOrdered_Dish(item);

            dal.RemoveOrder(O);

        }
        public void UpdateOrderDetails(Order O)
        {

            if (!SearchAtOrderesList(O))
                throw new Exception("The order is not exsist");
            if (MaxPrice(O))
                throw new Exception("The order's prise is too big");
            if (O.client.age < 18)
                throw new Exception("the age isn't legal");
            dal.UpdateOrderDetails(O);


        }
        public void AddOrdered_Dish(Ordered_Dish OD)
        {

            if (SearchAtOrderedDish_List(OD))
                throw new Exception("The ordered dish is already exist");
            dal.AddOrdered_Dish(OD);


        }
        public void RemoveOrdered_Dish(Ordered_Dish OD)
        {
            try
            {
                if (!SearchAtOrderedDish_List(OD))
                    throw new Exception("The ordered dish is not exsist");
                else
                    dal.RemoveOrdered_Dish(OD);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void UpdateOrdered_DishDetails(Ordered_Dish OD)
        {

            try
            {
                if (!SearchAtOrderedDish_List(OD))
                    throw new Exception("The oredered dish is not exsist");
                if (dal.getOrder(OD.OrderNumber).kashrutLevel > dal.getDish(OD.DishNumber).KashrutLevel)
                    throw new Exception("The dish's Kashrut and the order's Kashrut are not the same");
                dal.UpdateOrdered_DishDetails(OD);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        //
        //בכל פונקציות קבלת הרשימות, הפונקציה פונה לשכבת הנתונים ומבקשת את הרשימה הנתונה
        //

        public List<Dish> GetDishesList()
        {
            return dal.GetDishesList();
        }
        public List<Order> GetOrdersList()
        {
            return dal.GetOrdersList();
        }
        public List<Branch> GetBranchesList()
        {
            return dal.GetBranchesList();
        }
        public List<BE.User> GetUserList()
        {
            return dal.GetUsersList();
        }
        public float PriceCalculating(Order o)// הפונקציה עוברת רק על המנות המוזמנות שמספר ההזמנה שלהם זה כמו מספר ההזמנה המבוקשת, ומוסיפה את המחיר של המנה כפול מספר הפעמים שהיא הוזמנה
        {
            List<Ordered_Dish> l = dal.GetOrderedDishes_list();
            var v = from item in l
                    where item.OrderNumber == o.orderID && item.ODS!=OrderedDish_Situation.CANCELED
                    select item.AmountSameDishes *
                    dal.getDish(item.DishNumber).DishPrice;
            return v.Sum();
        }


        //
        //  בכל פונקציות הרווחים הפונקציה מבצעת חלוקה לקבוצות של ההזמנות לפי ההגדרה של הפונקציה (שזה גם המפתח) ובכל קבוצה משאירה רק את את הסכום של הרווחים
        //

        public IEnumerable<IGrouping<Kashrut, float>> BenefitByDishKashrutLevel()
        {
            var v = from item in dal.GetOrderedDishes_list()
                    group dal.getDish(item.DishNumber).DishPrice * item.AmountSameDishes
                    by dal.getDish(item.DishNumber).KashrutLevel into g
                    group g.Sum() by g.Key;
            return v;
        }
        public IEnumerable<IGrouping<DayOfWeek, float>> BenefitByDay()
        {
            var v = from item in dal.GetOrderedDishes_list()
                    group dal.getDish(item.DishNumber).DishPrice * item.AmountSameDishes
                    by dal.getOrder(item.OrderNumber).date.DayOfWeek into g
                    group g.Sum() by g.Key;
            return v;
        }
        public IEnumerable<IGrouping<int, float>> BenefitByHour()
        {
            var v = from item in dal.GetOrderedDishes_list()
                    group dal.getDish(item.DishNumber).DishPrice * item.AmountSameDishes
                    by dal.getOrder(item.OrderNumber).date.Hour into g
                    group g.Sum() by g.Key;
            return v;
        }
        public IEnumerable<IGrouping<int, float>> BenefitByMonth()
        {
            var v = from item in dal.GetOrderedDishes_list()
                    group dal.getDish(item.DishNumber).DishPrice * item.AmountSameDishes
                    by dal.getOrder(item.OrderNumber).date.Month into g
                    group g.Sum() by g.Key;
            return v;
        }
        public IEnumerable<IGrouping<string, float>> BenefitByAddress()
        {
            var v = from item in dal.GetOrderedDishes_list()

                    group dal.getDish(item.DishNumber).DishPrice * item.AmountSameDishes
                    by dal.getOrder(item.OrderNumber).client.Address into g
                    group g.Sum() by g.Key;
            return v;
        }
        public IEnumerable<IGrouping<string, float>> BenefitByBranch()
        {
            var v = from item in dal.GetOrderedDishes_list()
                    group dal.getDish(item.DishNumber).DishPrice * item.AmountSameDishes
                    by dal.getBranch((dal.getOrder(item.OrderNumber).BranchNumber)).Name into g
                    group g.Sum() by g.Key;
            return v;
        }
        public IEnumerable<IGrouping<int, float>> BenefitByCreditCard()
        {
            var v = from item in dal.GetOrderedDishes_list()
                    group dal.getDish(item.DishNumber).DishPrice * item.AmountSameDishes
                    by dal.getOrder(item.OrderNumber).client.CreditCardNumber into g
                    group g.Sum() by g.Key;
            return v;
        }



        public bool SearchAtDishesList(Dish D)
        {
            List<Dish> Dishes = GetDishesList();
            List<bool> Checker = (from Dish item in Dishes
                                  where item.DishID == D.DishID &&
                                  D.DS == DishSituation.EXIST
                                  select true).ToList();
            if (Checker.Count != 0)
                return true;
            return false;
        }
        public bool SearchAtUsersList(User U)
        {
            User u = GetUserList().Find(x => x.Username == U.Username);
            if (u != null)
                return true;
            return false;
        }
        public bool SearchAtBranchesList(Branch B)
        {
            List<bool> Checker = (from Branch item in GetBranchesList()
                                  where item.Number == B.Number
                                  && B.BS == BranchSituation.EXIST
                                  select true).ToList();
            if (Checker.Count != 0)
                return true;
            return false;

        }
        public bool SearchAtOrderesList(Order O)
        {
            List<Order> Orderes = GetOrdersList();
            List<bool> Checker = (from Order item in Orderes
                                  where item.orderID == O.orderID
                                  && O.OS == OrderSituation.ORDERED
                                  select true).ToList();
            if (Checker.Count != 0)
                return true;
            return false;

        }
        public bool SearchAtOrderedDish_List(Ordered_Dish OD)
        {
            List<Ordered_Dish> Ordered_Dishes = dal.GetOrderedDishes_list();
            List<bool> Checker = (from Ordered_Dish item in Ordered_Dishes
                                  where item.OrderedDish_Number == OD.OrderedDish_Number
                                  select true).ToList();
            if (Checker.Count != 0)
                return true;
            return false;
        }
        public List<Order> getOrdersByPredicate(Func<Order, bool> predicate = null)
        {
            if (predicate == null)
                return dal.GetOrdersList();
            var t = (from x in dal.GetOrdersList()
                     where predicate(x)
                     select x).ToList();
            return t;
        }
        public bool MaxPrice(Order o)
        {
            if (PriceCalculating(o) > 1000)
                return false;
            return true;
        }
        public List<Kashrut> GetKashrutsAsList()
        {
            List<Kashrut> list = new List<Kashrut>();
            list.Add(Kashrut.LOW);
            list.Add(Kashrut.MEDIUM);
            list.Add(Kashrut.HIGH);
            return list;
        }
        public Dish GetDish(int number)
        {
            return dal.getDish(number);
        }
        List<Ordered_Dish> GetOrderedDishes_list()
        {
            return dal.GetOrderedDishes_list();
        }


        public List<Ordered_Dish> Ordered_Dishes_Of_Order(int orderID)
        {
            List<Ordered_Dish> list = new List<Ordered_Dish>();
            foreach (Ordered_Dish OD in GetOrderedDishes_list())
            {
                if (OD.OrderNumber == orderID)
                    list.Add(OD);
            }
            return list;
        }
        public Order GetOrder(int number)
        {
            return dal.getOrder(number);
        }

        public void ODchange_to_finish()
        {
            foreach (Ordered_Dish od in dal.GetOrderedDishes_list())
            {
                if (od.ODS == OrderedDish_Situation.IN_PROGRESS)
                    if (DateTime.Now - dal.getOrder(od.OrderNumber).date > dal.getDish(od.DishNumber).PreparingTime)
                        dal.ODchange_to_finish(od);
            }
        }


        public void OrderToSent()
        {
            ODchange_to_finish();
            bool flag = true;
            foreach (Order o in dal.GetOrdersList())
            {
                if (o.OS != OrderSituation.CANCEL)
                {
                    foreach (Ordered_Dish od in Ordered_Dishes_Of_Order(o.orderID))
                        if (od.ODS == OrderedDish_Situation.IN_PROGRESS)
                            flag = false;
                    if (flag == true)
                        dal.OrderToSent(o);
                }
            }
        }


        List<Ordered_Dish> IBL.GetOrderedDishes_list()
        {
            return dal.GetOrderedDishes_list();
        }


        public bool SearchAtBranchesListByTelephone(Branch B)
        {
            Branch b = GetBranchesList().Find(x => x.PhoneNumber == B.PhoneNumber && x.BS == BranchSituation.EXIST);
            if (b != null)
                return true;
            return false;
        }

        public bool SearchAtBranchesListByAddress(Branch B)
        {
            Branch b = GetBranchesList().Find(x => x.Address == B.Address && x.BS == BranchSituation.EXIST);
            if (b != null)
                return true;
            return false;
        }


        public User GetUser(string username)
        {
            foreach (User u in GetUserList())
            {
                if (u.Username == username)
                    return u;
            }
            return null;
        }


        public Branch GetBranch(int BranchNumber)
        {
            return dal.getBranch(BranchNumber);
        }
    }
}
