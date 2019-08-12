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
using BE;
using BL;
namespace PLForms
{
    /// <summary>
    /// Interaction logic for DetailsForClient.xaml
    /// </summary>
    public partial class DetailsForClient : Window
    {
        Client client;
        IBL bl = FactoryBL.GetBl();
        public DetailsForClient(int OrderId)
        {
            InitializeComponent();
            client = new Client();
            client = bl.GetOrder(OrderId).client;
            grid1.DataContext = client;

        }

       
    }
}
