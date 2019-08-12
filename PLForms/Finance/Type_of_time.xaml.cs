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
    /// Interaction logic for Type_of_time.xaml
    /// </summary>
    public partial class Type_of_time : UserControl
    {
        class LocalDay : IComparable
        {
            public LocalDay(DayOfWeek Day, float Profits)
            {

                this.Profits = Profits;
                this.Time = Day;
            }
            public int Rank { get; set; }
            public DayOfWeek Time { get; set; }
            public float Profits { get; set; }

            public int CompareTo(object obj)
            {
                return -(Profits.CompareTo(((LocalDay)obj).Profits));
            }
        }
        class LocalHour : IComparable
        {
            public LocalHour(int Hour, float Profits)
            {

                this.Profits = Profits;
                this.Time = Hour;
            }
            public int Rank { get; set; }
            public int Time { get; set; }
            public float Profits { get; set; }

            public int CompareTo(object obj)
            {
                return -(Profits.CompareTo(((LocalHour)obj).Profits));
            }
        }
        class LocalMonth : IComparable
        {
            public LocalMonth(Month month, float Profits)
            {

                this.Profits = Profits;
                this.Time = month;
            }
            public int Rank { get; set; }
            public Month Time { get; set; }
            public float Profits { get; set; }

            public int CompareTo(object obj)
            {
                return -(Profits.CompareTo(((LocalMonth)obj).Profits));
            }
        }
        IBL bl = FactoryBL.GetBl();

        public Type_of_time(Time t)
        {
            InitializeComponent();
            if (t == Time.HOUR)
            {
                Time_Tipe.Header = "Hour in day";
                List<LocalHour> Lch = new List<LocalHour>();
                int i = 1;
                var v = bl.BenefitByHour();
                foreach (IGrouping<int, float> item in v)
                    foreach (float f in item)
                        Lch.Add(new LocalHour(item.Key, f));
                Lch.Sort();
                foreach (LocalHour item in Lch)
                {
                    item.Rank = i;
                    i++;
                }
                TimeDataGrid.DataContext = Lch;
                
            }
            if (t == Time.DAY)
            {
                Time_Tipe.Header = "Day in Week";
                List<LocalDay> Lcd = new List<LocalDay>();
                int i = 1;
                var v = bl.BenefitByDay();
                foreach (IGrouping<DayOfWeek, float> item in v)
                    foreach (float f in item)
                        Lcd.Add(new LocalDay((DayOfWeek)(item.Key),f));
                Lcd.Sort();
                foreach (LocalDay item in Lcd)
                {
                    item.Rank = i;
                    i++;
                }
                TimeDataGrid.DataContext = Lcd;
            }
            if (t == Time.MONTH)
            {
                Time_Tipe.Header = "Month in Year";
                List<LocalMonth> Lcm = new List<LocalMonth>();
                int i = 1;
                var v = bl.BenefitByMonth();
                foreach (IGrouping<int, float> item in v)
                    foreach (float f in item)
                        Lcm.Add(new LocalMonth((Month)(item.Key), f));
                Lcm.Sort();
                foreach (LocalMonth item in Lcm)
                {
                    item.Rank = i;
                    i++;
                }
                TimeDataGrid.DataContext = Lcm;
            }
            
        }
    }
}
