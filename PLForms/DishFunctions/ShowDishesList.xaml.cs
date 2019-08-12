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

namespace PLForms.DishFunctions
{
    /// <summary>
    /// Interaction logic for ShoeDishesList.xaml
    /// </summary>
    public partial class ShowDishesList : UserControl
    {
        IBL bl = FactoryBL.GetBl();
        List<Dish> MyDishes = new List<Dish>();
        public ShowDishesList()
        {
            try
            {
                InitializeComponent();
                if(bl.GetDishesList().Count==0)
                {
                    throw new Exception();
                }
                MyDishes = new List<Dish>();
            }
            catch
            {
                MessageBox.Show("data uploading Problem (Maybe there isn't any data)", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                All_Dishes.IsEnabled = false;
                Exist_Dishes.IsEnabled = false;
                Close_Dishes.IsEnabled = false;
            }
        }

        private void All_Dishes_Checked(object sender, RoutedEventArgs e)
        {
            show.ItemsSource = bl.GetDishesList();
        }

        private void Exist_Dishes_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Dish> MyDishes = new List<Dish>();
                foreach (Dish item in bl.GetDishesList())
                    if (item.DS == DishSituation.EXIST)
                        MyDishes.Add(item);
                if (MyDishes.Count == 0)
                    throw new Exception();
                show.ItemsSource = MyDishes;
            }
            catch
            {
                MessageBox.Show("there isn't any exist dish", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                Exist_Dishes.IsEnabled = false;
            }
        }

        private void Close_Dishes_Checked(object sender, RoutedEventArgs e)
        {
            List<Dish> MyDishes = new List<Dish>();
            foreach (Dish item in bl.GetDishesList())
                if (item.DS == DishSituation.REMOVED)
                    MyDishes.Add(item);
            show.ItemsSource = MyDishes;

        }
    }
}
