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
    /// Interaction logic for Kashrut.xaml
    /// </summary>
    public partial class ProfitsKashrut : UserControl
    {
        IBL bl = FactoryBL.GetBl();
        class Local : IComparable
        {
            public Local(Kashrut kashrut, float Profits)
            {

                this.Profits = Profits;
                this.kashrut = kashrut;
            }
            public int Rank { get; set; }
            public Kashrut kashrut { get; set; }
            public float Profits { get; set; }

            public int CompareTo(object obj)
            {
                return -(Profits.CompareTo(((Local)obj).Profits));
            }
        }
        public ProfitsKashrut()
        {
            InitializeComponent();

            List<Local> Pbk = new List<Local>();
            int i = 1;
            var v = bl.BenefitByDishKashrutLevel();
            foreach (IGrouping<Kashrut, float> item in v)
                foreach (float f in item)
                    Pbk.Add(new Local(item.Key, f));
            Pbk.Sort();
            foreach (Local item in Pbk)
            {
                item.Rank = i;
                i++;
            }
            AddressDataGrid.DataContext = Pbk;
        }
    }
}
