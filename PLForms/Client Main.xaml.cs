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
using PLForms.ClientFunctions;
using BL;
namespace PLForms
{
    /// <summary>
    /// Interaction logic for Client_Fuctions.xaml
    /// </summary>
    public partial class Client_Main : Window
    {
        IBL bl = FactoryBL.GetBl();
        public Client_Main()
        {
            InitializeComponent();
        }

        private void SeeMyButton_Click(object sender, RoutedEventArgs e)
        {
            Functions.Children.Clear();
            Functions.Children.Add(new SeeMyOrders());
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (bl.GetBranchesList().Count == 0)
                    throw new Exception("There isn't any branch to order from");
                if(bl.GetDishesList().Count == 0)
                    throw new Exception("There isn't any dish to order");
                    Functions.Children.Clear();
                Functions.Children.Add(new MakeOrder());
            }
            catch(Exception f)
            {
                MessageBox.Show(f.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SeeMyOrders_Click(object sender, RoutedEventArgs e)
        {
            Functions.Children.Clear();
            Functions.Children.Add(new SeeMyOrders());

        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            Functions.Children.Clear();
            Functions.Children.Add(new MakeOrder());
        }

        private void ExitToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).Show();
            this.Close();
        }


    }
}
