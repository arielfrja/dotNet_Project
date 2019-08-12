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
    /// Interaction logic for AddDish.xaml
    /// </summary>
    public partial class AddDish : UserControl
    {
        IBL bl = FactoryBL.GetBl();
        Dish dish = new Dish();
        int hours = 0;
        int minutes = 0;
        public AddDish()
        {
            InitializeComponent();
            this.DataContext = dish;
            this.kashrutLevelTextBox.ItemsSource = Enum.GetValues(typeof(Kashrut));
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dish.DishName == "" || dish.DishPrice == 0
                    || dish.DishSize == 0)
                    throw new Exception("Fill the fields Please");
                dish.PreparingTime = new TimeSpan(hours, minutes, 0);
                dish.DS = DishSituation.EXIST;
                bl.AddDish(dish);
                dishMessage.Visibility = Visibility.Visible;
                dish = new Dish();
                this.DataContext = dish;
                this.kashrutLevelTextBox.ItemsSource = Enum.GetValues(typeof(Kashrut));
                dishNameTextBox.Text = dish.DishName;
                dishPriceTextBox.Text = dish.DishPrice.ToString();
                dishSizeTextBox.Text = dish.DishSize.ToString();


            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void hoursDown_Click(object sender, RoutedEventArgs e)
        {
            if (hours == 0)
                hours = 2;
            else
                hours--;
            Hours.Text = hours.ToString();
            dishMessage.Visibility = Visibility.Hidden;

        }

        private void hoursUp_Click(object sender, RoutedEventArgs e)
        {

            if (hours == 2)
                hours = 0;
            else
                hours++;
            Hours.Text = hours.ToString();
            dishMessage.Visibility = Visibility.Hidden;

        }
        private void minutesDown_Click(object sender, RoutedEventArgs e)
        {


            if (minutes == 0)
                minutes = 59;
            else
                minutes--;
            Minutes.Text = minutes.ToString();
            dishMessage.Visibility = Visibility.Hidden;

        }

        private void minutesup_Click(object sender, RoutedEventArgs e)
        {

            if (minutes == 59)
                minutes = 0;
            else
                minutes++;
            Minutes.Text = minutes.ToString();
            dishMessage.Visibility = Visibility.Hidden;

        }

        private void dishSizeTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            dishMessage.Visibility = Visibility.Hidden;
        }

        private void dishPriceTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            dishMessage.Visibility = Visibility.Hidden;
        }

        private void dishNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            dishMessage.Visibility = Visibility.Hidden;
        }

    }
}
