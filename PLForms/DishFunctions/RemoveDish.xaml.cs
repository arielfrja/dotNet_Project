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
    /// Interaction logic for RemoveDish.xaml
    /// </summary>
    public partial class RemoveDish : UserControl
    {
        IBL bl = FactoryBL.GetBl();

        public RemoveDish()
        {
            InitializeComponent();
            try
            {
                List<Dish> list = (from e in bl.GetDishesList()
                                   where e.DS == DishSituation.EXIST
                                   select e).ToList();
                this.DataContext = list;
            }
            catch
            {
                MessageBox.Show("data uploading Problem (Maybe there isn't any data)", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                RemoveButton.IsEnabled = false;
            }
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            bl.RemoveDish((Dish)Dishes.SelectedItem);
            List<Dish> list = (from f in bl.GetDishesList()
                                 where f.DS == DishSituation.EXIST
                                 select f).ToList();
            this.DataContext = list;

        }
    }
}
