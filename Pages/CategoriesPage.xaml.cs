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

namespace Enternet_Shop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Categories.xaml
    /// </summary>
    public partial class Categories : Page
    {
        public Categories()
        {
            InitializeComponent();
        }

        private void ClothesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AccessoriesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AlcoholButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DecoratingButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPage menuPage = new MenuPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = menuPage.Title;
            mainWindow.MainFrame.Navigate(menuPage);
        }
    }
}
