﻿using System;
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
    /// Логика взаимодействия для SalePage.xaml
    /// </summary>
    public partial class SalePage : Page
    {

        public SalePage()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Промокод применен ^_~");
        }

        private void InMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPage menuPage = new MenuPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = menuPage.Title;
            mainWindow.MainFrame.Navigate(menuPage);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
