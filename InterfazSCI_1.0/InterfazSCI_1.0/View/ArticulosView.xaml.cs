﻿using System.Windows;
using System.Windows.Controls;

namespace IntrfazSCI_Final_.Views
{
    /// <summary>
    /// Lógica de interacción para ArticulosView.xaml
    /// </summary>
    public partial class ArticulosView : UserControl
    {
        public ArticulosView()
        {
            InitializeComponent();
        }

        private void BtnAgregarArt_Click(object sender, RoutedEventArgs e)
        {
            AgregarArtView agr = new AgregarArtView();
            agr.Show();
            
        }
    }
}
