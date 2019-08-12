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
    /// Interaction logic for UpdateBranch.xaml
    /// </summary>
    public partial class UpdateBranch : UserControl
    {
        IBL bl = FactoryBL.GetBl();
        Branch branch = new Branch();
        int BranchNumber;
        public UpdateBranch()
        {
            InitializeComponent();
            this.DataContext = branch;
            this.kashrutLevelComboBox.ItemsSource = Enum.GetValues(typeof(Kashrut));
            addressTextBox.IsEnabled = false;
            kashrutLevelComboBox.IsEnabled = false;
            nameTextBox.IsEnabled = false;
            phoneNumberTextBox.IsEnabled = false;
            workersAmountTextBox.IsEnabled = false;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {


            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        private void Enable_Button_Click(object sender, RoutedEventArgs e)
        {
            
            bool Enable = false;
            string deleter;
            int.TryParse(NumberEnter.Text, out BranchNumber);
            foreach (Branch b in bl.GetBranchesList())
            {
                if (b.Number == BranchNumber && b.BS == BranchSituation.EXIST)
                {
                    branch = b;
                    Enable = true;
                }
            }
            if (Enable == true)
            {
                addressTextBox.IsEnabled = true;
                kashrutLevelComboBox.IsEnabled = true;
                nameTextBox.IsEnabled = true;
                phoneNumberTextBox.IsEnabled = true;
                workersAmountTextBox.IsEnabled = true;
                NumberEnter.IsEnabled = false;
                CheckAccess.IsEnabled = false;
                if (branch.PhoneNumber.Length == 10 && branch.PhoneNumber[1] == '7' && branch.PhoneNumber[2] == '7')
                    deleter=branch.PhoneNumber.Remove(0,3);
                else
                    deleter = branch.PhoneNumber.Remove(0, 2);
                branch.PhoneNumber = deleter;
                this.DataContext = branch;
            }
            else
                MessageBox.Show("There isn't branch with this number!", "Access problem", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private void WorkersAmoutUp(object sender, RoutedEventArgs e)
        {
            try
            {
                if (branch.WorkersAmount >= 10)
                    throw new Exception("You didn't need so much workers");

                branch.WorkersAmount++;
                workersAmountTextBox.Text = branch.WorkersAmount.ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void WorkersAmountDown(object sender, RoutedEventArgs e)
        {
            try
            {
                if (branch.WorkersAmount <= 1)
                    throw new Exception("You cannot sub more!!!!");
                branch.WorkersAmount--;
                workersAmountTextBox.Text = branch.WorkersAmount.ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (branch.Name == "" || branch.WorkersAmount == 0 || branch.Address == ""
                    || branch.PhoneNumber == "0")
                    throw new Exception("Fill the fields Please");
                branch.PhoneNumber = AreaCode.SelectedItem.ToString().Remove(0, 38) + branch.PhoneNumber;
                bl.UpdateBranchDetails((Branch)DataContext);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error); ;
            }
        }


    }
}
