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
using System.Windows.Shapes;
using SCI.DesktopClient.ViewModels;

namespace SCI.DesktopClient.Views
{
    /// <summary>
    /// Lógica de interacción para AgregarArtView.xaml
    /// </summary>
    public partial class AgregarArtView : Window
    {
        public AgregarArtView()
        {
            InitializeComponent();
            DataContext = new ArticulosViewModel();
        }

        private void BtnAgregArt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
