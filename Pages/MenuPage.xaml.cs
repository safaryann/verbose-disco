using Enternet_Shop.Windows;
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
using Enternet_Shop.Pages;
using Enternet_Shop;
using Enternet_Shop.Infrastructure.Consts;

namespace Enternet_Shop.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {

        public MenuPage()
        {
            InitializeComponent();
            GrantAccessByRole();

            DataContext = this;

            UserNameTextBlock.Text = Application.Current.Resources[UserInfoConsts.UserName].ToString();
            PostTextBlock.Text = Application.Current.Resources[UserInfoConsts.Post].ToString();
            UserIdTextBlock.Text = Application.Current.Resources[UserInfoConsts.UserId].ToString();
            PostIdTextBlock.Text = Application.Current.Resources[UserInfoConsts.PostId].ToString();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources[UserInfoConsts.UserId] = null;
            Application.Current.Resources[UserInfoConsts.UserName] = null;
            Application.Current.Resources[UserInfoConsts.PostId] = null;
            Application.Current.Resources[UserInfoConsts.Post] = null;

            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Close();
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            ProductPage productPage = new ProductPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = productPage.Title;
            mainWindow.MainFrame.Navigate(productPage);
        }

        private void SaleButton_Click(object sender, RoutedEventArgs e)
        {
            SalePage salePage = new SalePage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = salePage.Title;
            mainWindow.MainFrame.Navigate(salePage);
        }

        private void DeliveryButton_Click(object sender, RoutedEventArgs e)
        {
            DeliveryPage deliveryPage = new DeliveryPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = deliveryPage.Title;
            mainWindow.MainFrame.Navigate(deliveryPage);
        }

        private void ShoppingCartButton_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCartPage shoppingCartPage = new ShoppingCartPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = shoppingCartPage.Title;
            mainWindow.MainFrame.Navigate(shoppingCartPage);
        }
        private void GrantAccessByRole()
        {
            if (Application.Current.Resources.Contains(UserInfoConsts.PostId))
            {
                int postId = Convert.ToInt32(Application.Current.Resources[UserInfoConsts.PostId]);

                if (postId == 0) //Роль гостя
                {
                    ShoppingCartButton.IsEnabled = false;
                }
            }
        }
    }
}
