﻿using SCI.DesktopClient.ViewModels;
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


namespace SCI.DesktopClient.Views
{
    /// <summary>      
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void btnProveedores_clicked(object sender, RoutedEventArgs e)
        {
        }

        private void BtnUsuarios_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void BtnProveedores_Click(object sender, RoutedEventArgs e)
        {
          
        }
    }
}