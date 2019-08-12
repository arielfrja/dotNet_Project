using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows;
using BE;
using System.Xml;
namespace DAL
{
    class Dal_XML_imp : Idal
    {
        XElement BranchesRoot;
        XElement ClientsRoot;
        XElement DishesRoot;
        XElement OrdersRoot;
        XElement OrderedDishes_Root;
        XElement UsersRoot;
        XElement ConfigRoot;
        XmlWriter XW;
        string BranchesPath = @"..\..\XmlDataSource\Branches.xml";
        string ClientsPath = @"..\..\XmlDataSource\Clients.xml";
        string DishesPath = @"..\..\XmlDataSource\Dishes.xml";
        string OrdersPath = @"..\..\XmlDataSource\Orders.xml";
        string OrderedDishes_Path = @"..\..\XmlDataSource\OrderedDishes.xml";
        string UsersPath = @"..\..\XmlDataSource\Users.xml";
        string ConfigPath = @"..\..\XmlDataSource\Config.xml";
        public Dal_XML_imp()
        {
            if (!File.Exists(BranchesPath))
                CreateBranchesData();
            else
                LoadBranchesData();

            if (!File.Exists(ClientsPath))
                CreateClientsData();
            else
                LoadClientsData();

            if (!File.Exists(DishesPath))
                CreateDishesData();
            else
                LoadDishesData();

            if (!File.Exists(OrdersPath))
                CreateOrdersData();
            else
                LoadOrdersData();
            if (!File.Exists(OrderedDishes_Path))
                Create_OrderedDish_Data();
            else
                Load_OrderedDish_Data();
            if (!File.Exists(UsersPath))
                CreateUsersData();
            else
                LoadUsersData();
            if (!File.Exists(ConfigPath))
                CreateConfig();
            else
                LoadConfig();
        }

        private void LoadConfig()
        {
            try
            {
                ConfigRoot = XElement.Load(ConfigPath);
            }
            catch
            {
                throw new Exception("Config upload problem");
            }
        }

        private void CreateConfig()
        {
            XElement BranchCounter;
            XElement DishCounter;
            XElement OrderCounter;
            XElement OrderedDishes_Counter;
            BranchCounter = new XElement("BranchCounter", (GetBranchesList().Count) + 1);
            DishCounter = new XElement("DishCounter", (GetDishesList().Count) + 1);
            OrderCounter = new XElement("OrderCounter", (GetOrdersList().Count) + 1);
            OrderedDishes_Counter = new XElement("OrderedDishes_Counter", (GetOrderedDishes_list().Count) + 1);
            ConfigRoot = new XElement("Config", BranchCounter, DishCounter, OrderCounter, OrderedDishes_Counter);
            ConfigRoot.Save(ConfigPath);
        }

        private void LoadUsersData()
        {
            try
            {
                UsersRoot = XElement.Load(UsersPath);
            }
            catch
            {
                throw new Exception("users' data upload problem");
            }
        }

        private void CreateUsersData()
        {
            UsersRoot = new XElement("Users");
            UsersRoot.Save(UsersPath);
        }

        private void Load_OrderedDish_Data()
        {
            try
            {
                OrderedDishes_Root = XElement.Load(OrderedDishes_Path);
            }
            catch
            {
                throw new Exception("Ordered dishes' data upload problem");
            }
        }

        private void Create_OrderedDish_Data()
        {
            OrderedDishes_Root = new XElement("Ordered_Dishes");
            OrderedDishes_Root.Save(OrderedDishes_Path);
        }

        private void LoadOrdersData()
        {
            try
            {
                OrdersRoot = XElement.Load(OrdersPath);
            }
            catch
            {
                throw new Exception("Orders' data upload problem");
            }
        }

        private void CreateOrdersData()
        {
            OrdersRoot = new XElement("Orders");
            OrdersRoot.Save(OrdersPath);
        }

        private void LoadDishesData()
        {
            try
            {
                DishesRoot = XElement.Load(DishesPath);
            }
            catch
            {
                throw new Exception("Dishes' data upload problem");
            }
        }

        private void CreateDishesData()
        {
            DishesRoot = new XElement("Dishes");
            DishesRoot.Save(DishesPath);
        }

        private void LoadClientsData()
        {
            try
            {
                ClientsRoot = XElement.Load(ClientsPath);
            }
            catch
            {
                throw new Exception("Clients' data upload problem");
            }
        }

        private void CreateClientsData()
        {
            ClientsRoot = new XElement("Clients");
            ClientsRoot.Save(ClientsPath);
        }

        private void LoadBranchesData()
        {
            {
                try
                {
                    BranchesRoot = XElement.Load(BranchesPath);
                }
                catch
                {
                    throw new Exception("Branches' data upload problem");
                }
            }
        }

        private void CreateBranchesData()
        {
            BranchesRoot = new XElement("Branches");
            BranchesRoot.Save(BranchesPath);
        }


        #region DishFunctions

        public void AddDish(Dish D)
        {
            int ID = int.Parse(ConfigRoot.Element("DishCounter").Value);
            XElement dish = new XElement("Dish",
                                            new XElement("ID", ID),
                                            new XElement("Name", D.DishName),
                                            new XElement("Price", D.DishPrice),
                                            new XElement("Size", D.DishSize),
                                            new XElement("DishSituation", D.DS),
                                            new XElement("KashrutLevel", D.KashrutLevel),
                                            new XElement("PreparingTime", D.PreparingTime.ToString())
            );
            ConfigRoot.Element("DishCounter").Value = (ID + 1).ToString();
            DishesRoot.Add(dish);
            DishesRoot.Save(DishesPath);
            ConfigRoot.Save(ConfigPath);

        }

        public void RemoveDish(Dish D)
        {
            XElement DishElement;

            DishElement = (from d in DishesRoot.Elements()
                           where Convert.ToInt32(d.Element("ID").Value) == D.DishID && d.Element("DishSituation").Value == DishSituation.EXIST.ToString()
                           select d).FirstOrDefault();
            DishElement.Element("DishSituation").Value = DishSituation.REMOVED.ToString();
            DishesRoot.Save(DishesPath);
        }

        public void UpdateDishDetails(Dish D)
        {
            XElement DishElement = (from d in DishesRoot.Elements()
                                    where Convert.ToInt32(d.Element("ID").Value) == D.DishID
                                    select d).FirstOrDefault();
            DishElement.Element("Name").Value = D.DishName;
            DishElement.Element("Price").Value = D.DishPrice.ToString();
            DishElement.Element("Size").Value = D.DishSize.ToString();
            DishElement.Element("DishSituation").Value = D.DS.ToString();
            DishElement.Element("KashrutLevel").Value = D.KashrutLevel.ToString();
            DishElement.Element("PreparingTime").Value = D.PreparingTime.ToString();
            DishesRoot.Save(DishesPath);
        }

        public Dish getDish(int id)
        {
            Dish D = new Dish();
            XElement DishElement = (from d in DishesRoot.Elements()
                                    where Convert.ToInt32(d.Element("ID").Value) == id && d.Element("DishSituation").Value == DishSituation.EXIST.ToString()
                                    select d).First();
            D.DishID = id;
            D.DishName = DishElement.Element("Name").Value;
            D.DishPrice = float.Parse(DishElement.Element("Price").Value);
            D.DishSize = int.Parse(DishElement.Element("Size").Value);
            D.DS = (DishSituation)Enum.Parse(typeof(DishSituation), (DishElement.Element("DishSituation").Value));
            D.KashrutLevel = (Kashrut)Enum.Parse(typeof(Kashrut), (DishElement.Element("KashrutLevel").Value));
            D.PreparingTime = TimeSpan.Parse(DishElement.Element("PreparingTime").Value);
            return D;
        }

        #endregion

        #region BranchFunctions

        public void AddBranch(Branch B)
        {
            int Number = int.Parse(ConfigRoot.Element("BranchCounter").Value);
            XElement branch = new XElement("Branch",
                              new XElement("Address", B.Address),
                              new XElement("BranchSituation", B.BS),
                              new XElement("KashrutLevel", B.KashrutLevel),
                              new XElement("Name", B.Name),
                              new XElement("PhoneNumber", B.PhoneNumber),
                              new XElement("WorkersAmount", B.WorkersAmount),
                              new XElement("Number", Number)
                              );
            ConfigRoot.Element("BranchCounter").Value = (Number + 1).ToString();
            BranchesRoot.Add(branch);
            BranchesRoot.Save(BranchesPath);
            ConfigRoot.Save(ConfigPath);
        }

        public void RemoveBranch(Branch B)
        {
            XElement BranchElement;

            BranchElement = (from b in BranchesRoot.Elements()
                             where Convert.ToInt32(b.Element("Number").Value) == B.Number && b.Element("BranchSituation").Value == BranchSituation.EXIST.ToString()
                             select b).FirstOrDefault();
            BranchElement.Element("BranchSituation").Value = BranchSituation.CLOSED.ToString();
            BranchesRoot.Save(BranchesPath);
        }

        public void UpdateBranchDetails(Branch B)
        {
            XElement BranchElement = (from b in BranchesRoot.Elements()
                                      where int.Parse(b.Element("Number").Value) == B.Number && b.Element("BranchSituation").Value == BranchSituation.EXIST.ToString()
                                      select b).FirstOrDefault();
            BranchElement.Element("Address").Value = B.Address;
            BranchElement.Element("KashrutLevel").Value = B.KashrutLevel.ToString();
            BranchElement.Element("Name").Value = B.Name;
            BranchElement.Element("PhoneNumber").Value = B.PhoneNumber;
            BranchElement.Element("WorkersAmount").Value = B.WorkersAmount.ToString();
            BranchesRoot.Save(BranchesPath);
        }

        public Branch getBranch(int num)
        {
            Branch branch = new Branch();
            XElement BranchElement = (from b in BranchesRoot.Elements()
                                      where Convert.ToInt32(b.Element("Number").Value) == num
                                      select b).FirstOrDefault();
            branch.Address = BranchElement.Element("Address").Value;
            branch.BS = (BranchSituation)Enum.Parse(typeof(BranchSituation), BranchElement.Element("BranchSituation").Value);
            branch.KashrutLevel = (Kashrut)Enum.Parse(typeof(Kashrut), BranchElement.Element("KashrutLevel").Value);
            branch.Name = BranchElement.Element("Name").Value;
            branch.Number = int.Parse(BranchElement.Element("Number").Value);
            branch.PhoneNumber = BranchElement.Element("PhoneNumber").Value;
            branch.WorkersAmount = int.Parse(BranchElement.Element("WorkersAmount").Value);
            return branch;
        }

        #endregion

        #region OrdersFunctions

        public void AddOrder(Order O)
        {
            int ID = int.Parse(ConfigRoot.Element("OrderCounter").Value);
            O.orderID = ID;
            XElement order = new XElement("Order",
                             new XElement("BranchNumber", O.BranchNumber),
                             new XElement("Date", DateTime.Now),
                             new XElement("KashrutLevel", O.kashrutLevel),
                             new XElement("OrderSituation", OrderSituation.ORDERED),
                             new XElement("OrderID", ID),
                             Client_To_XElemnt(O.client)
                             );
            ConfigRoot.Element("OrderCounter").Value = (ID + 1).ToString();
            OrdersRoot.Add(order);
            OrdersRoot.Save(OrdersPath);
            ConfigRoot.Save(ConfigPath);
        }

        public void RemoveOrder(Order O)
        {
            XElement OrderElement;

            OrderElement = (from o in OrdersRoot.Elements()
                            where Convert.ToInt32(o.Element("OrderID").Value) == O.orderID && o.Element("OrderSituation").Value == OrderSituation.ORDERED.ToString()
                            select o).FirstOrDefault();
            OrderElement.Element("OrderSituation").Value = OrderSituation.CANCEL.ToString();
            OrdersRoot.Save(OrdersPath);
        }

        public void SendOrder(Order O)
        {
            XElement OrderElement;

            OrderElement = (from o in OrdersRoot.Elements()
                            where Convert.ToInt32(o.Element("OrderID").Value) == O.orderID && o.Element("OrderSituation").Value == OrderSituation.ORDERED.ToString()
                            select o).FirstOrDefault();
            OrderElement.Element("OrderSituation").Value = OrderSituation.SENT.ToString();
            OrdersRoot.Save(OrdersPath);
        }

        public void UpdateOrderDetails(Order O)
        {
            XElement OrderElement = (from o in OrdersRoot.Elements()
                                     where int.Parse(o.Element("OrderID").Value) == O.orderID && o.Element("OrderSituation").Value == OrderSituation.ORDERED.ToString()
                                     select o).FirstOrDefault();
            OrderElement.Element("BranchNumber").Value = O.BranchNumber.ToString();
            OrderElement.Element("Date").Value = O.date.ToString();
            OrderElement.Element("KashrutLevel").Value = O.kashrutLevel.ToString();
            OrdersRoot.Save(OrdersPath);
        }

        public Order getOrder(int orderId)
        {
            Order O = new Order();
            XElement OrderElement = (from o in OrdersRoot.Elements()
                                     where int.Parse(o.Element("OrderID").Value) == orderId
                                     select o).First();
            O.BranchNumber = int.Parse(OrderElement.Element("BranchNumber").Value);
            O.date = DateTime.Parse(OrderElement.Element("Date").Value);
            O.kashrutLevel = (Kashrut)Enum.Parse(typeof(Kashrut), (OrderElement.Element("KashrutLevel").Value));
            O.orderID = int.Parse(OrderElement.Element("OrderID").Value);
            O.OS = (OrderSituation)Enum.Parse(typeof(OrderSituation), (OrderElement.Element("OrderSituation").Value));
            O.client = XElement_To_Client(OrderElement.Element("Client"));
            return O;
        }

        #endregion

        #region OrderedDish_Functions

        public void AddOrdered_Dish(Ordered_Dish OD)
        {
            int OrderedDishNumber = int.Parse(ConfigRoot.Element("OrderedDishes_Counter").Value);
            XElement Ordered_Dish = new XElement("Ordered_Dish",
                            new XElement("OrderedDish_Number", OrderedDishNumber),
                            new XElement("AmountSameDishes", OD.AmountSameDishes),
                            new XElement("DishNumber", OD.DishNumber),
                            new XElement("OrderNumber", OD.OrderNumber),
                            new XElement("OrderedDish_Situation", OrderedDish_Situation.IN_PROGRESS)
            );
            ConfigRoot.Element("OrderedDishes_Counter").Value = (OrderedDishNumber + 1).ToString();
            OrderedDishes_Root.Add(Ordered_Dish);
            OrderedDishes_Root.Save(OrderedDishes_Path);
            ConfigRoot.Save(ConfigPath);
        }

        public void RemoveOrdered_Dish(Ordered_Dish OD)
        {
            XElement OrderedDish_Element;

            OrderedDish_Element = (from od in OrderedDishes_Root.Elements()
                                   where Convert.ToInt32(od.Element("OrderedDish_Number").Value) == OD.OrderedDish_Number && od.Element("OrderedDish_Situation").Value == OrderedDish_Situation.IN_PROGRESS.ToString()
                                   select od).FirstOrDefault();
            OrderedDish_Element.Element("OrderedDish_Situation").Value = OrderedDish_Situation.CANCELED.ToString();
            OrderedDishes_Root.Save(OrderedDishes_Path);
        }

        public void UpdateOrdered_DishDetails(Ordered_Dish OD)
        {
            XElement OrderedDish_Element = (from od in OrderedDishes_Root.Elements()
                                            where Convert.ToInt32(od.Element("OrderedDish_Number").Value) == OD.OrderedDish_Number && od.Element("OrderedDish_Situation").Value == OrderedDish_Situation.IN_PROGRESS.ToString()
                                            select od).FirstOrDefault();
            OrderedDish_Element.Element("AmountSameDishes").Value = OD.AmountSameDishes.ToString();
            OrderedDish_Element.Element("DishNumber").Value = OD.DishNumber.ToString();
            OrderedDish_Element.Element("OrderNumber").Value = OD.OrderNumber.ToString();
            OrderedDishes_Root.Save(OrderedDishes_Path);
        }

        public Ordered_Dish get_OrderedDish(int num)
        {
            Ordered_Dish od = new Ordered_Dish();
            XElement OrderedDish_Element = (from OD in OrderedDishes_Root.Elements()
                                            where Convert.ToInt32(OD.Element("OrderedDish_Number").Value) == num
                                            select OD).First();
            od.AmountSameDishes = int.Parse(OrderedDish_Element.Element("AmountSameDishes").Value);
            od.DishNumber = int.Parse(OrderedDish_Element.Element("DishNumber").Value);
            od.ODS = (OrderedDish_Situation)Enum.Parse(typeof(OrderedDish_Situation), (OrderedDish_Element.Element("OrderedDish_Situation").Value));
            od.OrderedDish_Number = int.Parse(OrderedDish_Element.Element("OrderedDish_Number").Value);
            od.OrderNumber = int.Parse(OrderedDish_Element.Element("OrderNumber").Value);
            return od;
        }

        #endregion

        #region UserFunctions
        public void AddUser(User u)
        {
            XElement user = new XElement("User",
                            new XElement("Password", u.Password),
                            new XElement("Username", u.Username),
                            new XElement("userSituation", u.US)
                            );
            UsersRoot.Add(user);
            UsersRoot.Save(UsersPath);
        }

        public void RemoveUser(User u)
        {
            XElement user;
            user = (from U in UsersRoot.Elements()
                    where U.Element("Username").Value == u.Username
                    select U).FirstOrDefault();
            user.Element("userSituation").Value = UserSituation.CLOSED.ToString();
            UsersRoot.Save(UsersPath);
        }

        public User getUser(string username)
        {
            User U = new User();
            XElement user = (from u in UsersRoot.Elements()
                             where u.Element("Username").Value == username
                             select u).First();
            U.Username = user.Element("Username").Value;
            U.Password = user.Element("Password").Value;
            U.US = (UserSituation)Enum.Parse(typeof(UserSituation), (user.Element("userSituation").Value));
            return U;
        }

        #endregion

        #region GetLists

        public List<Dish> GetDishesList()
        {
            List<Dish> list = new List<Dish>();
            foreach (XElement DishElement in DishesRoot.Elements())
            {
                list.Add(getDish(int.Parse(DishElement.Element("ID").Value)));
            }
            return list;
        }

        public List<Order> GetOrdersList()
        {
            List<Order> list = new List<Order>();
            foreach (XElement OrderElement in OrdersRoot.Elements())
            {
                list.Add(getOrder(int.Parse(OrderElement.Element("OrderID").Value)));
            }
            return list;
        }

        public List<Branch> GetBranchesList()
        {
            List<Branch> list = new List<Branch>();
            foreach (XElement BranchElement in BranchesRoot.Elements())
            {
                list.Add(getBranch(int.Parse(BranchElement.Element("Number").Value)));
            }
            return list;
        }

        public List<User> GetUsersList()
        {
            List<User> list = new List<User>();
            foreach (XElement UserElement in UsersRoot.Elements())
            {
                list.Add(getUser(UserElement.Element("Username").Value));
            }
            return list;
        }

        public List<Ordered_Dish> GetOrderedDishes_list()
        {
            List<Ordered_Dish> list = new List<Ordered_Dish>();
            foreach (XElement OrderedDish_Element in OrderedDishes_Root.Elements())
            {
                list.Add(get_OrderedDish(int.Parse(OrderedDish_Element.Element("OrderedDish_Number").Value)));
            }
            return list;
        }

        #endregion


        XElement Client_To_XElemnt(Client client)
        {
            return new XElement("Client",
                   new XElement("Address", client.Address),
                   new XElement("Age", client.age),
                   new XElement("CreditCardNumber", client.CreditCardNumber),
                   new XElement("CurrentLocation", client.CurrentLocation),
                   new XElement("Name", client.Name)
                   );
        }

        Client XElement_To_Client(XElement xelement)
        {
            Client client = new Client();
            client.Address = xelement.Element("Address").Value;
            client.age = int.Parse(xelement.Element("Age").Value);
            client.CreditCardNumber = int.Parse(xelement.Element("CreditCardNumber").Value);
            client.CurrentLocation = xelement.Element("CurrentLocation").Value;
            client.Name = xelement.Element("Name").Value;
            return client;
        }






        public void ODchange_to_finish(Ordered_Dish od)
        {
            foreach (XElement OD in OrderedDishes_Root.Elements())
            {
                if (OD.Element("OrderedDish_Number").Value == od.OrderedDish_Number.ToString())
                    OD.Element("OrderedDish_Situation").Value = OrderedDish_Situation.FINISH.ToString();
            }
            OrderedDishes_Root.Save(OrderedDishes_Path);
        }

        public void OrderToSent(Order o)
        {
            foreach (XElement O in OrdersRoot.Elements())
            {
                if (O.Element("OrderID").Value == o.orderID.ToString())
                    O.Element("OrderSituation").Value = OrderSituation.SENT.ToString();
            }
            OrdersRoot.Save(OrdersPath);
        }
    }
}
