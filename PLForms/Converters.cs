using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BE;
using BL;
namespace PLForms
{
    class DishNumber_To_DishName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IBL bl = FactoryBL.GetBl();
            return bl.GetDish((int)value).DishName;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class DishNumber_To_DishPrice : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IBL bl = FactoryBL.GetBl();
            return bl.GetDish((int)value).DishPrice;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class DishNumber_To_DishSize : IValueConverter
    {
        IBL bl = FactoryBL.GetBl();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return bl.GetDish((int)value).DishSize;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class DishNumber_To_KashrutLevel : IValueConverter
    {
        IBL bl = FactoryBL.GetBl();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return bl.GetDish((int)value).KashrutLevel;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class BranchNumber_To_BranchName : IValueConverter
    {
        IBL bl = FactoryBL.GetBl();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return bl.GetBranch((int)(value)).Name;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class DishNumber_To_PrepairingTime : IValueConverter
    {
        IBL bl = FactoryBL.GetBl();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return bl.GetDish((int)value).PreparingTime;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class Client_To_ClientName : IValueConverter
    {
        IBL bl = FactoryBL.GetBl();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((Client)value).Name;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class Client_To_ClientAddress : IValueConverter
    {
        IBL bl = FactoryBL.GetBl();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((Client)value).Address;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class Client_To_ClientCreditCard : IValueConverter
    {
        IBL bl = FactoryBL.GetBl();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((Client)value).CreditCardNumber;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class OrderId_To_Profit : IValueConverter
    {
        IBL bl = FactoryBL.GetBl();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return bl.PriceCalculating(bl.GetOrder((int)value));
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
}
