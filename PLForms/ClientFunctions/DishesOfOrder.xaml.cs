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
using System.Windows.Shapes;
using BL;
using BE;
namespace PLForms.ClientFunctions
{
    /// <summary>
    /// Interaction logic for DishesOfOrder.xaml
    /// </summary>
    public partial class DishesOfOrder : Window
    {
        IBL bl = FactoryBL.GetBl();
        List<Ordered_Dish> odl;
        public DishesOfOrder(int OrderId)
        {
            InitializeComponent();
            bl.ODchange_to_finish();
            odl = new List<Ordered_Dish>();
            odl=bl.Ordered_Dishes_Of_Order(OrderId);
            ordered_DishDataGrid.DataContext = odl;
        }

      
    }
}
