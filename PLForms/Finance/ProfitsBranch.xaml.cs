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
namespace PLForms.Finance
{
    /// <summary>
    /// Interaction logic for Branch.xaml
    /// </summary>
    public partial class ProfitsBranch : UserControl
    {
        class Local : IComparable
        {
            public Local(string BranchName, float Profits)
            {

                this.Profits = Profits;
                this.BranchName = BranchName;
            }
            public int Rank { get; set; }
            public string BranchName { get; set; }
            public float Profits { get; set; }

            public int CompareTo(object obj)
            {
                return -Profits.CompareTo(((Local)obj).Profits);
            }
        }
        IBL bl = FactoryBL.GetBl();

        public ProfitsBranch()
        {
            InitializeComponent();
           
            List<Local> Pbb = new List<Local>();
            int i = 1;
            var v = bl.BenefitByBranch();
            foreach (IGrouping<string, float> item in v)
                foreach (float f in item)
                    Pbb.Add(new Local(item.Key, f));
            Pbb.Sort();
            foreach (Local item in Pbb)
            {
                item.Rank = i;
                i++;
            }
            AddressDataGrid.DataContext = Pbb;
        }
    }
}
