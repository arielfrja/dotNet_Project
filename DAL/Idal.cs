using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    public interface Idal
    {
        void AddDish(BE.Dish D);
        void RemoveDish(BE.Dish D);
        void UpdateDishDetails(BE.Dish D);
        void AddBranch(BE.Branch B);
        void RemoveBranch(BE.Branch B);
        void UpdateBranchDetails(BE.Branch B);
        void AddOrder(BE.Order O);
        void RemoveOrder(BE.Order O);
        void SendOrder(BE.Order O);
        void UpdateOrderDetails(BE.Order O);
        void AddOrdered_Dish(BE.Ordered_Dish OD);
        void RemoveOrdered_Dish(BE.Ordered_Dish OD);
        void UpdateOrdered_DishDetails(BE.Ordered_Dish OD);
        List<BE.Dish> GetDishesList();
        List<BE.Order> GetOrdersList();
        List<BE.Branch> GetBranchesList();
        List<BE.User> GetUsersList();
        List<Ordered_Dish> GetOrderedDishes_list();
        Dish getDish(int id);
        Branch getBranch(int num);
        Ordered_Dish get_OrderedDish(int num);
        Order getOrder(int orderId);
        User getUser(string username);
        void AddUser(User u);
        void RemoveUser(User u);
        void ODchange_to_finish(Ordered_Dish od);
        void OrderToSent(Order o);

    }
}
