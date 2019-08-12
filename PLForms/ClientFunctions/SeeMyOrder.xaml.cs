using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using BE;
namespace PLForms.ClientFunctions
{

    /// <summary>
    /// Interaction logic for SeeMyBranches.xaml
    /// </summary>
    public partial class SeeMyOrders : UserControl
    {
        IBL bl = FactoryBL.GetBl();
       
        List<Order> OrdersByTheSameClient;
        List<int> cc;
        

        public SeeMyOrders()
        {
            InitializeComponent();
            
            OrdersByTheSameClient = new List<Order>();
           
            cc=new List<int>();
            foreach (Order o in bl.GetOrdersList())
                if(!cc.Contains(o.client.CreditCardNumber) && o.OS!=OrderSituation.CANCEL)
                    cc.Add(o.client.CreditCardNumber);
            SelectedCreditCard_ComboBox.DataContext = cc;

            
        }

        private void SelectedCreditCard_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            bl.OrderToSent();
            OrdersByTheSameClient = new List<Order>();
            
            try
            {
                detailsForTheClientDataGrid.DataContext = (from o in bl.GetOrdersList()
                                                           where o.OS != OrderSituation.CANCEL && o.client.CreditCardNumber == (int)SelectedCreditCard_ComboBox.SelectedItem
                                                           select o).ToList();
                if (((List<Order>)detailsForTheClientDataGrid.DataContext).Count == 0)
                    throw new Exception("This credit card number never used");
                Refresh.IsEnabled = true;
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (new DetailsForClient(((Order)(detailsForTheClientDataGrid.SelectedItem)).orderID)).ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            (new DishesOfOrder(((Order)(detailsForTheClientDataGrid.SelectedItem)).orderID)).ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.OrderToSent();
                if(((Order)(detailsForTheClientDataGrid.SelectedItem)).OS==OrderSituation.SENT)
                    throw new Exception("The order is already send");
                foreach (Ordered_Dish od in bl.GetOrderedDishes_list())
                    if (od.OrderNumber == ((Order)(detailsForTheClientDataGrid.SelectedItem)).orderID)
                        bl.RemoveOrdered_Dish(od);
                bl.RemoveOrder(((Order)(detailsForTheClientDataGrid.SelectedItem)));
                detailsForTheClientDataGrid.DataContext = (from o in bl.GetOrdersList()
                                                           where o.OS != OrderSituation.CANCEL && o.client.CreditCardNumber == (int)SelectedCreditCard_ComboBox.SelectedItem
                                                           select o).ToList();
                cc=new List<int>();
                foreach (Order o in bl.GetOrdersList())
                    if (!cc.Contains(o.client.CreditCardNumber) && o.OS != OrderSituation.CANCEL)
                        cc.Add(o.client.CreditCardNumber);
                SelectedCreditCard_ComboBox.DataContext = cc;
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RefreshClick(object sender, RoutedEventArgs e)
        {
            bl.OrderToSent();
            detailsForTheClientDataGrid.DataContext = (from o in bl.GetOrdersList()
                                                       where o.OS != OrderSituation.CANCEL && o.client.CreditCardNumber == (int)SelectedCreditCard_ComboBox.SelectedItem
                                                       select o).ToList();
        }
         
                
        

       
    }
}
