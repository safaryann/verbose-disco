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
using Enternet_Shop.Infrastructure.Database;
using Enternet_Shop.Infrastructure.ViewModels;


namespace Enternet_Shop.Pages
{
    /// <summary>
    /// Логика взаимодействия для DeliveryPage.xaml
    /// </summary>
    public partial class DeliveryPage : Page
    {
        private DeliveryRepository _repository;
        public DeliveryPage()
        {
            InitializeComponent();
            _repository = new DeliveryRepository();
            DeliveryComboBox.ItemsSource = _repository.GetList();

        }

        private void InMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPage menuPage = new MenuPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = menuPage.Title;
            mainWindow.MainFrame.Navigate(menuPage);
        }

        private void ArrangeButton_Click(object sender, RoutedEventArgs e)
        {
        }
        private void DeliveryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DeliveryComboBox.SelectedItem is DeliveryViewModel selectedDelivery)
            {
                MessageBox.Show(selectedDelivery.Adress);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Адрес выбран");
        }
    }
}
