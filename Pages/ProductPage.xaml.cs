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
using Enternet_Shop;
using Enternet_Shop.Infrastructure;
using Enternet_Shop.Infrastructure.Consts;
using Enternet_Shop.Infrastructure.Database;
using Enternet_Shop.Infrastructure.Mappers;
using Enternet_Shop.Infrastructure.QR;
using Enternet_Shop.Infrastructure.ViewModels;
using Enternet_Shop.Windows;
using System.IO;
using System.Reflection;
using Enternet_Shop.Infrastructure.Report;

namespace Enternet_Shop.Pages
{
    /// <summary>
    /// Логика взаимодействия для TovarPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private ProductRepository _repository;
        public ProductPage()
        {
            InitializeComponent();
            GrantAccessByRole();
            _repository = new ProductRepository();
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            ProductsDataGrid.ItemsSource = _repository.GetList();
        }
        private void InMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPage menuPage = new MenuPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = menuPage.Title;
            mainWindow.MainFrame.Navigate(menuPage);

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string search = SearchTextBox.Text;

            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Поисковый запрос не может быть пустым.");
            }
            else
            {
                var productRepository = new ProductRepository();
                var searchResults = productRepository.Search(search);

                // Преобразование результатов поиска в ProductViewModel
                var searchViewModels = searchResults.Select(result => new ProductViewModel
                {
                    Name = result.Name,
                }).ToList();

                // Обновление DataGrid с результатами поиска
                ProductsDataGrid.ItemsSource = searchViewModels;
            }
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            var reportManager = new ReportManager();
            var data = reportManager.GenerateReport(ProductsDataGrid.ItemsSource as List<ProductViewModel>);

            var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"report_{DateTime.Now.ToShortDateString()}.xlsx");
            using (var stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                stream.Write(data, 0, data.Length);
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateGrid();
        }

        private void InCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is ProductViewModel selectedProduct)
            {
                ShoppingCartRepository.AddToCart(selectedProduct.ID);
            }
        }

        private void ProductsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem == null)
                return;
            var productCard = new ProductCardWindow(ProductsDataGrid.SelectedItem as ProductViewModel);
            productCard.ShowDialog();
            UpdateGrid();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Hide();
            var productCard = new ProductCardWindow();
            productCard.ShowDialog();
            UpdateGrid();
            mainWindow.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Ничего не выбрано для удаления");
            }
            var item = ProductsDataGrid.SelectedItem as ProductViewModel;
            if (item == null)
            {
                MessageBox.Show("Не удалось получить данные");
            }
            else
            {
                _repository.Delete(item.ID);
                UpdateGrid();
            }
        }
        private void GrantAccessByRole()
        {
            if (Application.Current.Resources.Contains(UserInfoConsts.PostId))
            {
                int postId = Convert.ToInt32(Application.Current.Resources[UserInfoConsts.PostId]);

                if (postId == 6) // Роль клиента
                {
                    DeleteButton.IsEnabled = false;
                    AddButton.IsEnabled = false;
                    UploadButton.IsEnabled = false;
                }
                else if (postId == 0) //Роль гостя
                {
                    DeleteButton.IsEnabled = false;
                    AddButton.IsEnabled = false;
                    UploadButton.IsEnabled = false;
                    InCartButton.IsEnabled = false;
                }
            }
        }
        private void GenerateQRCodeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedProduct = ProductsDataGrid.SelectedItem as ProductViewModel;

                if (selectedProduct == null)
                {
                    MessageBox.Show("Выберите товар из списка.");
                    return;
                }

                var qrCodeImage = QRManager.Generate(selectedProduct);

                ShowQRCodeWindow(qrCodeImage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
        private void ShowQRCodeWindow(System.Windows.Media.DrawingImage qrCodeImage)
        {
            var qrCodeWindow = new Window
            {
                Title = "QR Code",
                Width = 300,
                Height = 300,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            var imageControl = new Image
            {
                Source = qrCodeImage,
                Stretch = System.Windows.Media.Stretch.Fill
            };

            qrCodeWindow.Content = imageControl;
            qrCodeWindow.ShowDialog();
        }
    }
}
