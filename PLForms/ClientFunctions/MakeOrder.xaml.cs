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
using System.Collections.ObjectModel;
using BE;
using BL;
namespace PLForms.ClientFunctions
{
    /// <summary>
    /// Interaction logic for MakeOrder.xaml
    /// </summary>
    public partial class MakeOrder : UserControl
    {
        IBL bl = FactoryBL.GetBl();
        Client client;
        ObservableCollection<Ordered_Dish> SelectedDishes = new ObservableCollection<Ordered_Dish>();
        float CurrentDishPrice = 0;
        float TotalPrice = 0;
        Window parentWindow;
        public MakeOrder()
        {
            parentWindow = Window.GetWindow(this);
            InitializeComponent();
            this.kashrutLevelComboBox.ItemsSource = Enum.GetValues(typeof(Kashrut));
            DishesMenu.DataContext = (from Dish d in bl.GetDishesList()
                                      where d.DS == DishSituation.EXIST
                                      select d).ToList();
            OrderedDishes.DataContext = SelectedDishes;
            Branches.DataContext = (from Branch b in bl.GetBranchesList()
                                    where b.BS == BranchSituation.EXIST
                                    select b).ToList();
        }



        private void ClientDetailAdding(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (char c in ageTextBox.Text)
                {
                    if (c < '0' || c > '9')
                    {
                        throw new Exception("Insert your age Correctly!");
                    }
                }
                foreach (char c in creditCardNumberTextBox.Text)
                {
                    if (c < '0' || c > '9')
                    {
                        throw new Exception("Insert your Credit card number Correctly!");
                    }
                }
                if (int.Parse(ageTextBox.Text) < 18)
                    throw new Exception("You must to be 18 years old to order!");
                if (MessageBox.Show("Are you sure that you want to use this details?", "Are You sure", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    client = new Client();
                    client.Address = addressTextBox.Text;
                    client.age = int.Parse(ageTextBox.Text);
                    client.CreditCardNumber = int.Parse(creditCardNumberTextBox.Text);
                    client.CurrentLocation = currentLocationTextBox.Text;
                    client.Name = nameTextBox.Text;
                    addressTextBox.IsEnabled = false;
                    ageTextBox.IsEnabled = false;
                    creditCardNumberTextBox.IsEnabled = false;
                    currentLocationTextBox.IsEnabled = false;
                    nameTextBox.IsEnabled = false;
                    ClientDetailsAdding.IsEnabled = false;
                    kashrutLevelComboBox.IsEnabled = true;
                }

            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                foreach (char c in AmountTextBox.Text)
                {
                    if (c < '0' || c > '9')
                        throw new Exception("Write number!!");
                }
                if (DishesMenu.SelectedIndex == -1)
                    throw new Exception("You have to select a dish!");
                if (AmountTextBox.Text == "")
                {
                    PriceShow.Content = "0 ₪";
                    CurrentDishPrice = 0;
                    return;
                }
                if (TotalPrice + (float.Parse(AmountTextBox.Text) * ((Dish)DishesMenu.SelectedItem).DishPrice) > 1000)
                {
                    string helper = AmountTextBox.Text.Remove(AmountTextBox.Text.Length - 1, 1);
                    AmountTextBox.Text = helper;
                    throw new Exception("You cannot Order by more than 1000 ₪!");
                }
                CurrentDishPrice = (float.Parse(AmountTextBox.Text) * ((Dish)DishesMenu.SelectedItem).DishPrice);
                PriceShow.Content = CurrentDishPrice.ToString() + "₪";
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DishesMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string helper;
            if (AmountTextBox.Text != "")
                try
                {
                    foreach (char c in AmountTextBox.Text)
                    {
                        if (c < '0' || c > '9')
                            throw new Exception("Write number in amount!!");
                    }
                    for (int i = 0; i < AmountTextBox.Text.Length; i++)
                    {
                        if (AmountTextBox.Text[0] == '0')
                            AmountTextBox.Text.Remove(0, 1);
                    }
                    if (TotalPrice + (float.Parse(AmountTextBox.Text) * ((Dish)DishesMenu.SelectedItem).DishPrice) > 1000)
                    {
                        helper = AmountTextBox.Text.Remove(AmountTextBox.Text.Length - 1, 1);
                        AmountTextBox.Text = helper;
                        throw new Exception("You cannot Order by more than 1000 ₪!");
                    }
                    if (AmountTextBox.Text != "")
                    {
                        CurrentDishPrice = (float.Parse(AmountTextBox.Text) * ((Dish)DishesMenu.SelectedItem).DishPrice);
                        PriceShow.Content = CurrentDishPrice.ToString() + "₪";
                    }
                    else
                        PriceShow.Content = "0 ₪";
                }
                catch (Exception f)
                {
                    MessageBox.Show(f.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
        }

        private void AddDishClick(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (char c in AmountTextBox.Text)
                {
                    if (c < '0' || c > '9')
                        throw new Exception("You have to right the amount correctly");
                }
                if (DishesMenu.SelectedIndex == -1)
                    throw new Exception("You have to select dish");
                if (TotalPrice + (float.Parse(AmountTextBox.Text) * ((Dish)DishesMenu.SelectedItem).DishPrice) > 1000)
                    throw new Exception("You cannot Order by more than 1000 ₪!");
                CurrentDishPrice += (CurrentDishPrice == 0 ? float.Parse(AmountTextBox.Text) * ((Dish)DishesMenu.SelectedItem).DishPrice : 0);
                TotalPrice += CurrentDishPrice;
                CurrentDishPrice = 0;
                Ordered_Dish OD = new Ordered_Dish();
                OD.AmountSameDishes = int.Parse(AmountTextBox.Text);
                AmountTextBox.Clear();
                OD.DishNumber = ((Dish)DishesMenu.SelectedItem).DishID;
                OD.ODS = OrderedDish_Situation.IN_PROGRESS;
                OrderedDishes.IsEnabled = true;
                RemoveDish.IsEnabled = true;
                ContinueToBranch.IsEnabled = true;
                SelectedDishes.Add(OD);
                TotalPriceShow.Content = TotalPrice.ToString() + "₪";
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void kashrutLevelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KashrutAdding.IsEnabled = true;
            DishesMenu.DataContext = (from Dish d in bl.GetDishesList()
                                      where d.DS == DishSituation.EXIST && ((Kashrut)kashrutLevelComboBox.SelectedItem) == d.KashrutLevel
                                      select d).ToList();
            Branches.DataContext = (from Branch b in bl.GetBranchesList()
                                    where b.BS == BranchSituation.EXIST && ((Kashrut)kashrutLevelComboBox.SelectedItem) == b.KashrutLevel
                                    select b).ToList();
        }

        private void KashrutAddingClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((List<Dish>)(DishesMenu.DataContext)).Count == 0)
                    throw new Exception("There isn't any dish with this Kashrut");
                if (((List<Branch>)(Branches.DataContext)).Count == 0)
                    throw new Exception("There isn't any branch with this Kashrut");
                if (MessageBox.Show("Are you sure that you want to choose this kashrut?", "Are You sure", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DishesMenu.IsEnabled = true;
                    AmountTextBox.IsEnabled = true;
                    AddDishesButton.IsEnabled = true;
                    KashrutAdding.IsEnabled = false;
                    kashrutLevelComboBox.IsEnabled = false;
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void RemoveDishClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OrderedDishes.SelectedIndex == -1)
                {
                    throw new Exception("You have to select dish!");
                }
                if (MessageBox.Show("Are you sure that you want to remove this dish from order?", "Are You sure", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    TotalPrice -= (bl.GetDish(((Ordered_Dish)OrderedDishes.SelectedItem).DishNumber).DishPrice * ((Ordered_Dish)OrderedDishes.SelectedItem).AmountSameDishes);
                    SelectedDishes.Remove((Ordered_Dish)(OrderedDishes.SelectedItem));
                    TotalPriceShow.Content = TotalPrice.ToString() + "₪";
                    if (OrderedDishes.Items.Count == 0)
                    {
                        RemoveDish.IsEnabled = false;
                        OrderedDishes.IsEnabled = false;
                        ContinueToBranch.IsEnabled = false;
                    }
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (Branches.SelectedIndex == -1)
                {
                    throw new Exception("You have to select branch");
                }
                Order O = new Order();
                O.client = client;
                O.OS = OrderSituation.ORDERED;
                O.BranchNumber = ((Branch)Branches.SelectedItem).Number;
                O.kashrutLevel = ((Branch)Branches.SelectedItem).KashrutLevel;
                bl.AddOrder(O);

                foreach (var x in SelectedDishes)
                {
                    x.OrderNumber = O.orderID;
                }
                foreach (Ordered_Dish od in SelectedDishes)
                    bl.AddOrdered_Dish(od);
                addressTextBox.Text = "";
                ageTextBox.Text = "";
                creditCardNumberTextBox.Text = "";
                currentLocationTextBox.Text = "";
                nameTextBox.Text = "";
                addressTextBox.IsEnabled = true;
                ageTextBox.IsEnabled = true;
                creditCardNumberTextBox.IsEnabled = true;
                currentLocationTextBox.IsEnabled = true;
                nameTextBox.IsEnabled = true;
                ClientDetailsAdding.IsEnabled = true;
                kashrutLevelComboBox.IsEnabled = true;
                KashrutAdding.IsEnabled = true;
                (Window.GetWindow(this) as Client_Main).Functions.Children.Clear();



            }
   
            catch (Exception f)
            {
                MessageBox.Show(f.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ContinueToBranch_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to order those dishes?", "Are You sure", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Branches.IsEnabled = true;
                OrderedDishes.IsEnabled = false;
                RemoveDish.IsEnabled = false;
                ContinueToBranch.IsEnabled = false;
                AddDishesButton.IsEnabled = false;
            }
        }

        private void Branches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to order from this branch?", "Are You sure", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                OrderButton.IsEnabled = true;
        }
    }
}