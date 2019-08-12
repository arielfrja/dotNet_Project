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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : UserControl
    {
        IBL bl = FactoryBL.GetBl();
        public AddUser()
        {
            InitializeComponent();
        }


        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            User u = new User();
            try
            {
                if (passwordTextBox.Password.Length < 4)
                    throw new Exception("The length of the password must be four or more characters!");
                if (passwordTextBox.Password == "")
                    throw new Exception("Insert password!");
                if (usernameTextBox.Text == "")
                    throw new Exception("Insert user name!");
                u.Password = passwordTextBox.Password;
                u.Username = usernameTextBox.Text;
                bl.AddUser(u);
                MessageBox.Show("The user has been added succsefuly", "", MessageBoxButton.OK, MessageBoxImage.None);
                (Window.GetWindow(this) as StaffMenu).Screen.Children.Clear();
                (Window.GetWindow(this) as StaffMenu).Screen.Children.Add(new Staff());
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
