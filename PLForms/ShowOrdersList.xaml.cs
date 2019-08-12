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
using BE;
using BL;
namespace PLForms
{
    /// <summary>
    /// Interaction logic for ShowOrdersList.xaml
    /// </summary>
    public partial class ShowOrdersList : UserControl
    {
        IBL bl = FactoryBL.GetBl();
        public ShowOrdersList()
        {
            InitializeComponent();
            List<Order> order = new List<Order>();
        }

        private void All_Orders_Checked(object sender, RoutedEventArgs e)
        {
            bl.OrderToSent();
            show.ItemsSource = bl.GetOrdersList();
        }

        private void Ordered_Orders_Checked(object sender, RoutedEventArgs e)
        {
            bl.OrderToSent();
            List<Order> order = new List<Order>();
            foreach (Order item in bl.GetOrdersList())
                if (item.OS == OrderSituation.ORDERED)
                    order.Add(item);
            show.ItemsSource = order;
        }

        private void Sent_Orders_Checked(object sender, RoutedEventArgs e)
        {
            bl.OrderToSent();
            List<Order> order = new List<Order>();
            foreach (Order item in bl.GetOrdersList())
                if (item.OS == OrderSituation.SENT)
                    order.Add(item);
            show.ItemsSource = order;
            
        }

        private void Cancel_Order_Checked(object sender, RoutedEventArgs e)
        {
            bl.OrderToSent();
            List<Order> order = new List<Order>();
            foreach (Order item in bl.GetOrdersList())
                if (item.OS == OrderSituation.CANCEL)
                    order.Add(item);
            show.ItemsSource = order;
        }
    }
}
