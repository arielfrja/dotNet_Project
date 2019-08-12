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
namespace PLForms.Finance
{
    /// <summary>
    /// Interaction logic for CreditCard.xaml
    /// </summary>
    public partial class ProfitsTime : UserControl
    {
        public ProfitsTime()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(FilterComboBox.SelectedItem == Hour)
            {
                TimeScreen.Children.Clear();
                TimeScreen.Children.Add(new Type_of_time(Time.HOUR));
            }
            if (FilterComboBox.SelectedItem == Mount)
            {
                TimeScreen.Children.Clear();
                TimeScreen.Children.Add(new Type_of_time(Time.MONTH));
            }
            if (FilterComboBox.SelectedItem == DayOfWeek)
            {
                TimeScreen.Children.Clear();
                TimeScreen.Children.Add(new Type_of_time(Time.DAY));
            }
        }
    }
}
