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
using System.Windows.Shapes;
using BL;
using BE;

namespace PLForms
{
    /// <summary>
    /// Interaction logic for StaffConfigure.xaml
    /// </summary>
    public partial class StaffConfigure : Window
    {
        IBL bl = FactoryBL.GetBl();
        User user = new User();

        public StaffConfigure()
        {
            InitializeComponent();
            if (!bl.SearchAtUsersList(new User("admin", "123")))
                bl.AddUser(new User("admin", "123"));


            Password.Password = "";
            Login.IsEnabled = false;
            this.DataContext = user;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user.Password = Password.Password;
                    if (bl.GetUser(user.Username) != null && bl.GetUser(user.Username).Password == user.Password)
                    {
                        StaffMenu SM = new StaffMenu();
                        SM.Show();
                        this.Close();
                    }
                else
                    throw new Exception("The user or the password isn't correct");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Password.Password == "" || UsernameTextBox.Text == "")
                Login.IsEnabled = false;
            else
                Login.IsEnabled = true;

        }

    }
}
