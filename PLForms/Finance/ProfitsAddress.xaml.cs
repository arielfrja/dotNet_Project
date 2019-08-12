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
    /// Interaction logic for Address.xaml
    /// </summary>
    public partial class ProfitsAddress : UserControl
    {
        class Local:IComparable
        {
            public Local(string Address,float Profits)
            {
               
                this.Profits = Profits;
                this.ClientAddress = Address;
            }
            public int Rank { get; set; }
            public string ClientAddress { get; set; }
            public float Profits { get; set; }

            public int CompareTo(object obj)
            {
                return -(Profits.CompareTo(((Local)obj).Profits));
            }
        }
        IBL bl = FactoryBL.GetBl();
       
        public ProfitsAddress()
        {
            InitializeComponent();
            List<Local> Pba = new List<Local>();
            int i=1;
            var v=bl.BenefitByAddress();
            foreach(IGrouping<string,float> item in v)
                foreach(float f in item)
                    Pba.Add(new Local(item.Key,f));
            Pba.Sort();
            foreach (Local item in Pba)
            {
                item.Rank = i;
                i++;
            }
            AddressDataGrid.DataContext = Pba;

        }

        private void AddressDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
