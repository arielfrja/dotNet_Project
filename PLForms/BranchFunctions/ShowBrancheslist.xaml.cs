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
    /// Interaction logic for ShowBrancheslist.xaml
    /// </summary>
    public partial class ShowBrancheslist : UserControl
    {
        IBL bl = FactoryBL.GetBl();
        List<Branch> MyBranches;
        public ShowBrancheslist()
        {
            InitializeComponent();
            MyBranches = new List<Branch>();
          
        }

        private void All_branches_Checked(object sender, RoutedEventArgs e)
        {
            try { show.ItemsSource = bl.GetBranchesList(); }
            catch
            {
                MessageBox.Show("data uploading Problem (Maybe there isn't any data)", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                All_branches.IsEnabled = false;
                Exist_branches.IsEnabled = false;
                Close_branches.IsEnabled = false;
            }
            

        }

        private void Exist_branches_Checked(object sender, RoutedEventArgs e)
        {
            List<Branch> MyBranches = new List<Branch>();
            foreach (Branch item in bl.GetBranchesList())
                if (item.BS == BranchSituation.EXIST)
                    MyBranches.Add(item);
            show.ItemsSource = MyBranches;
        }

        private void Close_branches_Checked(object sender, RoutedEventArgs e)
        {
            List<Branch> MyBranches = new List<Branch>();
            foreach (Branch item in bl.GetBranchesList())
                if (item.BS == BranchSituation.CLOSED)
                    MyBranches.Add(item);
            show.ItemsSource = MyBranches;
        }

        private void All_branches_Checked_1(object sender, RoutedEventArgs e)
        {


        }

        
    }
}
