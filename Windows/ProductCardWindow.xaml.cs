using Enternet_Shop.Infrastructure.Consts;
using Enternet_Shop.Infrastructure.Database;
using Enternet_Shop.Infrastructure.ViewModels;
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

namespace Enternet_Shop.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductCardWindow.xaml
    /// </summary>
    public partial class ProductCardWindow : Window
    {
        private ProductViewModel _selectedItem = null;
        private ProductRepository _repository;
        public ProductCardWindow()
        {
            InitializeComponent();
        }

        public ProductCardWindow(ProductViewModel selectedItem)
        {
            InitializeComponent();
            GrantAccessByRole();
            _selectedItem = selectedItem;
            if (selectedItem != null)
            {
                _selectedItem = selectedItem;
                NameTextBox.Text = selectedItem.Name;
                CostTextBox.Text = selectedItem.Cost.ToString();
                QuanityTextBox.Text = selectedItem.Quanity.ToString();
            }
            else
            {
                _selectedItem = selectedItem;
                NameTextBox.Text = null;
                CostTextBox.Text = null;
                QuanityTextBox.Text = null;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _repository = new ProductRepository();
                if (_selectedItem != null)
                {
                    var entity = new ProductViewModel
                    {
                        ID = _selectedItem.ID,
                        Name = NameTextBox.Text,
                        Cost = (long)Convert.ToDecimal(CostTextBox.Text),
                        Quanity = (long)Convert.ToDecimal(QuanityTextBox.Text),
                    };
                    if (_repository != null)
                    {
                        _repository.Update(entity);
                        Window.GetWindow(this).Close();
                    }
                    else
                    {
                        MessageBox.Show(".");
                    }
                }
                else
                {
                    var entity = new ProductViewModel
                    {
                        Name = NameTextBox.Text,
                        Cost = (long)Convert.ToDecimal(CostTextBox.Text),
                        Quanity = (long)Convert.ToDecimal(QuanityTextBox.Text),
                    };
                    if (_repository != null)
                    {
                        _repository.Add(entity);
                        Window.GetWindow(this).Close();
                    }
                    else
                    {
                        MessageBox.Show("-");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
        private void GrantAccessByRole()
        {
            if (Application.Current.Resources.Contains(UserInfoConsts.PostId))
            {
                int postId = Convert.ToInt32(Application.Current.Resources[UserInfoConsts.PostId]);

                if (postId == 6) // Роль клиента
                {
                    NameTextBox.IsEnabled = false;
                    CostTextBox.IsEnabled = false;
                    QuanityTextBox.IsEnabled = false;
                    SaveButton.IsEnabled = false;
                }
                else if (postId == 0) //Роль гостя
                {
                    NameTextBox.IsEnabled = false;
                    CostTextBox.IsEnabled = false;
                    QuanityTextBox.IsEnabled = false;
                    SaveButton.IsEnabled = false;
                }
            }
        }
    }
}
