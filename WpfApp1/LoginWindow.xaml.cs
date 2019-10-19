using DataAccess.Implementation;
using System;
using System.Security.Cryptography;
using System.Windows;
using UserService;
using UserService.Interface;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IUserService _userService;

        public LoginWindow()
        {
            InitializeComponent();
            _userService = new UserService.UserService(new HashService(new SHA384Managed(), new RNGCryptoServiceProvider()), new UserDao());
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            bool isSuccess = false;
            try
            {
                isSuccess = _userService.Authorize(Login.Text, Password.Password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error durring login process", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (!isSuccess)
            {
                MessageBox.Show("Invalid User name or Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this.Hide();
            MainWindow mainWindow = new MainWindow();

            mainWindow.ShowDialog();
           
        }
    }
}
