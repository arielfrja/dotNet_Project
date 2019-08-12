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
    /// Interaction logic for TheMostProfitableCustomer.xaml
    /// </summary>
    public partial class TheMostProfitableCustomer : UserControl
    {
        class Local:IComparable
        {
            public Local(int ClientCreditCard, float Profits)
            {
               
                this.Profits = Profits;
                this.ClientCreditCard = ClientCreditCard;
            }
            public int Rank { get; set; }
            public int ClientCreditCard { get; set; }
            public float Profits { get; set; }

            public int CompareTo(object obj)
            {
                return -(Profits.CompareTo(((Local)obj).Profits));
            }
        }
        IBL bl = FactoryBL.GetBl();

        public TheMostProfitableCustomer()
        {
            InitializeComponent();
            List<Local> Pbcc = new List<Local>();
            int i = 1;
            var v = bl.BenefitByCreditCard();
            foreach (IGrouping<int, float> item in v)
                foreach (float f in item)
                    Pbcc.Add(new Local(item.Key, f));
            Pbcc.Sort();
            foreach (Local item in Pbcc)
            {
                item.Rank = i;
                i++;
            }
            ProfitableCustomer.DataContext = Pbcc;
        }
    }
}
