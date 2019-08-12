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
    /// Interaction logic for AddBranch.xaml
    /// </summary>
    public partial class AddBranch : UserControl
    {
        IBL bl = FactoryBL.GetBl();
        Branch branch = new Branch();
        public AddBranch()
        {
            InitializeComponent();
            this.DataContext = branch;
            this.kashrutLevelComboBox.ItemsSource = Enum.GetValues(typeof(Kashrut));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach(char c in phoneNumberTextBox.Text)
                 {
                    if(c<'0'||c>'9'||phoneNumberTextBox.Text.Length !=7)
                        throw new Exception("Fill the Phone number field correctly");
                }
                branch.PhoneNumber = AreaCode.SelectedItem.ToString().Remove(0, 38) + branch.PhoneNumber;
                branch.BS = BranchSituation.EXIST;
                bl.AddBranch(branch);
                (Window.GetWindow(this) as StaffMenu).branchMessage.Visibility = Visibility.Visible;
                branch = new Branch();
                this.DataContext = branch;
                this.kashrutLevelComboBox.ItemsSource = Enum.GetValues(typeof(Kashrut));

                nameTextBox.Text = branch.Name;
                workersAmountTextBox.Text = branch.WorkersAmount.ToString();
                addressTextBox.Text = branch.Address;
                phoneNumberTextBox.Text = branch.PhoneNumber;


            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error); 
            }

        }

        private void Button_Click_UP(object sender, RoutedEventArgs e)
        {
            try
            {
                if (branch.WorkersAmount > 10)
                    throw new Exception("You didnt need so much workers");

                branch.WorkersAmount++;
                workersAmountTextBox.Text = branch.WorkersAmount.ToString();
                (Window.GetWindow(this) as StaffMenu).branchMessage.Visibility = Visibility.Hidden;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_DOWN(object sender, RoutedEventArgs e)
        {
            try
            {
                if (branch.WorkersAmount <= 0)
                    throw new Exception("You cannot sub more!!!!");
                branch.WorkersAmount--;
                workersAmountTextBox.Text = branch.WorkersAmount.ToString();
                (Window.GetWindow(this) as StaffMenu).branchMessage.Visibility = Visibility.Hidden;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void GotFocus(object sender, RoutedEventArgs e)
        {
            (Window.GetWindow(this) as StaffMenu).branchMessage.Visibility = Visibility.Hidden;
        }
    }
}
