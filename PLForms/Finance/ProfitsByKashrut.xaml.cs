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
    /// Interaction logic for ProfitsByKashrut.xaml
    /// </summary>
    public partial class ProfitsByKashrut : UserControl
    {
        IBL bl = FactoryBL.GetBl();
     
        public ProfitsByKashrut()
        {
            InitializeComponent();
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterComboBox.SelectedItem == AddressFilter)
            {
                Profits_Screen.Children.Clear();
                Profits_Screen.Children.Add(new PLForms.Finance.ProfitsAddress());
            }
            if (FilterComboBox.SelectedItem == BranchFilter)
            {
                Profits_Screen.Children.Clear();
                Profits_Screen.Children.Add(new PLForms.Finance.ProfitsBranch());
            }
            if (FilterComboBox.SelectedItem == Time)
            {
                Profits_Screen.Children.Clear();
                Profits_Screen.Children.Add(new PLForms.Finance.ProfitsTime());
            }
            if (FilterComboBox.SelectedItem == KashrutFilter)
            {
                Profits_Screen.Children.Clear();
                Profits_Screen.Children.Add(new PLForms.Finance.ProfitsKashrut());
            }
            
            
            
                
        }

    }
}
