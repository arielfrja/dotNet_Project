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
namespace PLForms.DishFunctions
{
    /// <summary>
    /// Interaction logic for UpdateDish.xaml
    /// </summary>
    public partial class UpdateDish : UserControl
    {
        int DishNumber;
        IBL bl = FactoryBL.GetBl();
        Dish dish;
        int hours;
        int minutes;

        public UpdateDish()
        {
            InitializeComponent();
            this.DataContext = dish;
            this.kashrutLevelComboBox.ItemsSource = Enum.GetValues(typeof(Kashrut));
            dishNameTextBox.IsEnabled = false;
            dishPriceTextBox.IsEnabled = false;
            dishSizeTextBox.IsEnabled = false;
            kashrutLevelComboBox.IsEnabled = false;
            hoursDown.IsEnabled = false;
            hoursUp.IsEnabled = false;
            minutesDown.IsEnabled = false;
            minutesUp.IsEnabled = false;

        }

        private void Enable_Button_Click(object sender, RoutedEventArgs e)
        {


            bool Enable = false;
            int.TryParse(NumberEnter.Text, out DishNumber);
            foreach (Dish d in bl.GetDishesList())
            {
                if (d.DishID == DishNumber && d.DS == DishSituation.EXIST)
                {
                    dish = d;
                    Enable = true;
                }
            }
            if (Enable == true)
            {
                dishNameTextBox.IsEnabled = true;
                dishPriceTextBox.IsEnabled = true;
                dishSizeTextBox.IsEnabled = true;
                kashrutLevelComboBox.IsEnabled = true;
                hoursDown.IsEnabled = true;
                hoursUp.IsEnabled = true;
                minutesDown.IsEnabled = true;
                minutesUp.IsEnabled = true;
                this.DataContext = dish;
                hours = dish.PreparingTime.Hours;
                minutes = dish.PreparingTime.Minutes;
                Hours.Text = hours.ToString();
                Minutes.Text = minutes.ToString();
            }
            else
                MessageBox.Show("There isn't branch with this number!", "Access problem", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dishNameTextBox.Text == "" || dishPriceTextBox.Text == "" || Hours.Text == "00" && Minutes.Text == "00")
                    throw new Exception("Fill the fields Please");
                if (Hours.Text == "00")
                    hours = 0;
                if (Minutes.Text == "00")
                    minutes = 0;
                ((Dish)DataContext).PreparingTime = new TimeSpan(hours, minutes, 0);
                bl.UpdateDishDetails((Dish)DataContext);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error); ;
            }
        }

        private void hoursDown_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (hours <= 0)
                    throw new Exception("You can't reduce more");
                hours--;
                Hours.Text = hours.ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void hoursUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (hours >= 2)
                    throw new Exception("To long preparation");
                hours++;
                Hours.Text = hours.ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void minutesDown_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (minutes <= 0)
                    throw new Exception("You can't reduce more");
                minutes--;
                Minutes.Text = minutes.ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void minutesUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (minutes >= 59)
                    throw new Exception("Max 59 minutes in a hour");
                minutes++;
                Minutes.Text = minutes.ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
}
