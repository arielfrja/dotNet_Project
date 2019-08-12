using PLForms.Finance;
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

namespace PLForms
{
    /// <summary>
    /// Interaction logic for StaffMenu.xaml
    /// </summary>
    public partial class StaffMenu : Window
    {
        public StaffMenu()
        {
            InitializeComponent();
            Screen.Children.Add(new Staff());
        }

        
        private void Add_branch_Click(object sender, RoutedEventArgs e)
        {
            Screen.Children.Clear();
            Screen.Children.Add(new Staff());
            Screen.Children.Add(new AddBranch());
            Screen.Children.Add(stack);
        }

        private void Remove_branch_Click(object sender, RoutedEventArgs e)
        {
            Screen.Children.Clear();
            Screen.Children.Add(new Staff());
            Screen.Children.Add(new RemoveBranch());
            
        }
        private void show_branches_list_Click(object sender, RoutedEventArgs e)
        {
            Screen.Children.Clear();
            Screen.Children.Add(new Staff());
            Screen.Children.Add(new ShowBrancheslist());
        }

        private void Add_dish_Click(object sender, RoutedEventArgs e)
        {
            Screen.Children.Clear();
            Screen.Children.Add(new Staff());
            Screen.Children.Add(new AddDish());
        }

        private void Update_branch_Click(object sender, RoutedEventArgs e)
        {
            Screen.Children.Clear();
            Screen.Children.Add(new Staff());
            Screen.Children.Add(new UpdateBranch());

        }

        private void Remove_dish_Click(object sender, RoutedEventArgs e)
        {
            Screen.Children.Clear();
            Screen.Children.Add(new Staff());
            Screen.Children.Add(new RemoveDish());
        }

        private void Show_Dishes_Click(object sender, RoutedEventArgs e)
        {
            Screen.Children.Clear();
            Screen.Children.Add(new Staff());
            Screen.Children.Add(new DishFunctions.ShowDishesList());
        }

        private void Update_Dish_Click(object sender, RoutedEventArgs e)
        {
            Screen.Children.Clear();
            Screen.Children.Add(new Staff());
            Screen.Children.Add(new DishFunctions.UpdateDish());
        }

        private void Exit_to_main_menu_Click(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).Show();
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Screen.Children.Clear();
            Screen.Children.Add(new Staff());
            Screen.Children.Add(new ShowOrdersList());
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Screen.Children.Clear();
            Screen.Children.Add(new ProfitsByKashrut());
        }
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            Screen.Children.Clear();
            Screen.Children.Add(new AddUser());
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Screen.Children.Clear();
            Screen.Children.Add(new TheMostProfitableCustomer());
        }

       

        
    }
}
