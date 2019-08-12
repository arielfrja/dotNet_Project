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
    /// Interaction logic for RemoveBranch.xaml
    /// </summary>
    public partial class RemoveBranch : UserControl
    {
        IBL bl = FactoryBL.GetBl();
        
        public RemoveBranch()
        {
            InitializeComponent();
            try
            {
                List<Branch> list = (from e in bl.GetBranchesList()
                                     where e.BS == BranchSituation.EXIST
                                     select e).ToList();
                this.DataContext = list;
            }
            catch
            {
                MessageBox.Show("data uploading Problem (Maybe there isn't any data)","Error",MessageBoxButton.OK,MessageBoxImage.Warning);
                RemoveButton.IsEnabled = false;
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bl.RemoveBranch((Branch)Branches.SelectedItem);
            List<Branch> list = (from f in bl.GetBranchesList()
                                 where f.BS == BranchSituation.EXIST
                                 select f).ToList();
            this.DataContext = list;
            
        }

     

    }
}
