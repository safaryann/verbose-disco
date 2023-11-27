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
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Window.GetWindow(this).Close();
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

        private void CategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            Categories categoriesPage = new Categories();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = categoriesPage.Title;
            mainWindow.MainFrame.Navigate(categoriesPage);
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
    }
}
