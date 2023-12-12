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
using Enternet_Shop.Infrastructure.Consts;
using Enternet_Shop.Infrastructure.Database;

namespace Enternet_Shop.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordPasswordBox.Password;

            var clientRepository = new ClientRepository();
            var user = clientRepository.ValidateAndGetUser(login, password);

            if (user != null)
            {
                Application.Current.Resources[UserInfoConsts.UserId] = user.ID;
                Application.Current.Resources[UserInfoConsts.UserName] = user.Login;
                Application.Current.Resources[UserInfoConsts.PostId] = user.PostId;
                Application.Current.Resources[UserInfoConsts.Post] = user.post;

                MainWindow menuWindow = new MainWindow();
                menuWindow.Show();

                Close();
            }
        }
        private void SignInGuestButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources[UserInfoConsts.UserId] = 0;
            Application.Current.Resources[UserInfoConsts.UserName] = "Гость";
            Application.Current.Resources[UserInfoConsts.PostId] = 0;
            Application.Current.Resources[UserInfoConsts.Post] = "Гость";

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
