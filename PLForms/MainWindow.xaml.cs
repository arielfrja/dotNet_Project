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
namespace PLForms
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl = FactoryBL.GetBl();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void LaChefEnter_Click(object sender, RoutedEventArgs e)
        {
            (new StaffConfigure()).Show();
            this.Close();
        }

        private void LaClientEnter_Click(object sender, RoutedEventArgs e)
        {
            (new Client_Main()).Show();
            this.Close();
        }
    }
}
