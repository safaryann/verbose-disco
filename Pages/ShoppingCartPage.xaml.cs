using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Enternet_Shop;
using Enternet_Shop.Infrastructure.Database;
using Enternet_Shop.Infrastructure.ViewModels;
using Enternet_Shop.Windows;

namespace Enternet_Shop.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShoppingCartPage.xaml
    /// </summary>
    public partial class ShoppingCartPage : Page
    {
        private ObservableCollection<ShoppingCartViewModel> shoppingCartItems;

        public ShoppingCartPage()
        {
            InitializeComponent();
            shoppingCartItems = new ObservableCollection<ShoppingCartViewModel>();
            ShoppingCartDataGrid.ItemsSource = shoppingCartItems;
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            var items = ShoppingCartStorage.GetItems();
            shoppingCartItems.Clear(); // Очищаем текущую коллекцию
            foreach (var item in items)
            {
                shoppingCartItems.Add(item);
            }
        }

        private void InMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPage menuPage = new MenuPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = menuPage.Title;
            mainWindow.MainFrame.Navigate(menuPage);
        }
        private void ClearCartButton_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCartStorage.ClearCart();
            UpdateGrid();
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Hide();
            var paymentWindow = new PaymentWindow();
            paymentWindow.ShowDialog();
            UpdateGrid();
            mainWindow.Show();
        }
    }
}
