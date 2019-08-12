using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public interface IBL
    {
        /// <summary>
        /// הוספת משתמש
        /// </summary>
        /// <param name="U"></param>
        void AddUser(BE.User U);
        void RemoveUser(BE.User U);
        /// <summary>
        /// הוספת מנה
        /// </summary>
        /// <param name="D"></param>
        void AddDish(BE.Dish D);// 
        /// <summary>
        /// הסרת מנה
        /// </summary>
        /// <param name="D"></param>
        void RemoveDish(BE.Dish D);// 
        /// <summary>
        /// עדכון פרטי מנה
        /// </summary>
        /// <param name="D"></param>
        void UpdateDishDetails(BE.Dish D);// 
        /// <summary>
        /// הוספת סניף
        /// </summary>
        /// <param name="B"></param>
        void AddBranch(BE.Branch B);// 
        /// <summary>
        /// הסרת סניף
        /// </summary>
        /// <param name="B"></param>
        void RemoveBranch(BE.Branch B);// 
        /// <summary>
        /// עדכון פרטי סניף
        /// </summary>
        /// <param name="B"></param>
        void UpdateBranchDetails(BE.Branch B);// 
        /// <summary>
        /// הוספת הזמנה
        /// </summary>
        /// <param name="O"></param>
        void AddOrder(BE.Order O);// 
        /// <summary>
        /// הסרת הזמנה
        /// </summary>
        /// <param name="O"></param>
        void RemoveOrder(BE.Order O);// 
        /// <summary>
        /// עדכון פרטי הזמנה
        /// </summary>
        /// <param name="O"></param>
        void UpdateOrderDetails(BE.Order O);// 
        /// <summary>
        ///  הוספת מנה מוזמנת
        /// </summary>
        /// <param name="OD"></param>
        void AddOrdered_Dish(BE.Ordered_Dish OD);//
        /// <summary>
        /// הסרת מנה מוזמנת
        /// </summary>
        /// <param name="OD"></param>
        void RemoveOrdered_Dish(BE.Ordered_Dish OD);// 
        /// <summary>
        /// עדכון פרטי מנה מוזמנת
        /// </summary>
        /// <param name="OD"></param>
        void UpdateOrdered_DishDetails(BE.Ordered_Dish OD);// 
        /// <summary>
        /// קבלת כל המנות כרשימה
        /// </summary>
        /// <returns>List<BE.Dish></returns>
        List<BE.Dish> GetDishesList();// 
        /// <summary>
        /// קבלת כל ההזמנות כרשימה
        /// </summary>
        /// <returns>List<BE.Order></returns>
        List<BE.Order> GetOrdersList();// 
        /// <summary>
        /// קבלת כל הסניפים כרשימה
        /// </summary>
        /// <returns>List<BE.Branch></returns>
        List<BE.Branch> GetBranchesList();// 
        /// <summary>
        ///  קבלת כל המשתמשים כרשימה
        /// </summary>
        /// <returns>List<BE.User></returns>
        List<BE.User> GetUserList();//

        /// <summary>
        /// חישוב מחיר של הזמנה
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        float PriceCalculating(Order o);//
        /// <summary>
        /// רווחים עפ"י רמת הכשרות
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<Kashrut, float>> BenefitByDishKashrutLevel();// 
        /// <summary>
        ///  רווחים עפ"י חודש
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGrouping<int, float>> BenefitByMonth();//
        /// <summary>
        /// רווחים עפ"י שעה ביום
        /// </summary>
        /// <returns>IEnumerable<IGrouping<int, float>></returns>
         IEnumerable<IGrouping<int, float>> BenefitByHour();// 
        /// <summary>
         /// רווחים לפי יום בשבוע
        /// </summary>
         /// <returns>IEnumerable<IGrouping<int, float>></returns>
        IEnumerable<IGrouping<DayOfWeek, float>> BenefitByDay();// 
        /// <summary>
        /// רווחים לפי כתובת
        /// </summary>
        /// <returns>IEnumerable<IGrouping<DayOfWeek, float>></returns>
        IEnumerable<IGrouping<string, float>> BenefitByAddress();// 
        /// <summary>
        /// רווחים לפי סניף
        /// </summary>
        /// <returns>IEnumerable<IGrouping<string, float>></returns>
        IEnumerable<IGrouping<string, float>> BenefitByBranch();// 
        /// <summary>
        /// בודק אם מחיר הזמנה עולה על המחיר המקסימאלי
        /// </summary>
        /// <param name="o"></param>
        /// <returns>Boolean</returns>
        IEnumerable<IGrouping<int, float>> BenefitByCreditCard();//
        bool MaxPrice(Order o); // 
        /// <summary>
        /// מחזיר את רמות הכשרות השונות כרשימה
        /// </summary>
        /// <returns></returns>
        List<Kashrut> GetKashrutsAsList();//
        /// <summary>
        /// חיפוש ברשימת המנות
        /// </summary>
        /// <param name="D"></param>
        /// <returns></returns>
        bool SearchAtDishesList(Dish D);// 
        /// <summary>
        /// חיפוש ברשימת הסניפים עפ"י מספר טלפון
        /// </summary>
        /// <param name="B"></param>
        /// <returns></returns>
        bool SearchAtBranchesListByTelephone(Branch B);// 
        /// <summary>
        /// חיפוש ברשימת הסניפים עפ"י כתובת
        /// </summary>
        /// <param name="B"></param>
        /// <returns></returns>
        bool SearchAtBranchesListByAddress(Branch B);// 
        /// <summary>
        /// חיפוש ברשימת הסניפים עפ"י מספר סניף
        /// </summary>
        /// <param name="B"></param>
        /// <returns></returns>
        bool SearchAtBranchesList(Branch B);// 
        /// <summary>
        /// חיפוש ברשימת ההזמנות
        /// </summary>
        /// <param name="O"></param>
        /// <returns></returns>
        bool SearchAtOrderesList(Order O);// 
        /// <summary>
        /// חיפוש ברשימת המנות המוזמנות
        /// </summary>
        /// <param name="O"></param>
        /// <returns></returns>
        bool SearchAtOrderedDish_List(Ordered_Dish O);// 
        /// <summary>
        /// חיפוש ברשימת המשתמשים
        /// </summary>
        /// <param name="U"></param>
        /// <returns></returns>
        bool SearchAtUsersList(User U); // 
        /// <summary>
        ///  החזרת הזמנה עפ"י תנאי
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<Order> getOrdersByPredicate//
            (Func<Order, bool> predicate = null);
        /// <summary>
        ///  החזרת מנה מהרשימה עפ"י מספר שניתן
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        Dish GetDish(int number); //
        /// <summary>
        /// החזרת כל המנות המוזמנות השייכות להזמנה מסויימת
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        List<Ordered_Dish> Ordered_Dishes_Of_Order(int orderID);// 
        /// <summary>
        ///  החזרת הזמנה עפ"י מספר שניתן
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        Order GetOrder(int number); //

        /// <summary>
        ///  משנה את הסטטוס של כל המנות המוזמנות שנגמרה הכנתן ל'גמור'
        /// </summary>
        void ODchange_to_finish(); //

        /// <summary>
        ///  משנה את הסטוטס של כל ההזמנות שצריעות להישלח ל'נשלח'
        /// </summary>
        void OrderToSent(); //

        /// <summary>
        ///  מחזיר את רשימת המונת המוזמנות
        /// </summary>
        /// <returns>List<Ordered_Dish></returns>
        List<Ordered_Dish> GetOrderedDishes_list(); //
        /// <summary>
        /// מחזיר משתמש עפ"י שם משתמש
        /// </summary>
        /// <param name="user name"></param>
        /// <returns></returns>
        User GetUser(string username);
        /// <summary>
        /// מחזיר סניף לפי מספר
        /// </summary>
        /// <param name="BranchNumber"></param>
        /// <returns></returns>
        Branch GetBranch(int BranchNumber);
    }
}
