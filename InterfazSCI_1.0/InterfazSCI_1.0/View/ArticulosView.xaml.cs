using System.Windows;
using System.Windows.Controls;
using SCI.Data;
using SCI.DesktopClient.ViewModels;
using System.Linq;
using System.Collections.Generic;

namespace SCI.DesktopClient.Views
{
    /// <summary>
    /// Lógica de interacción para ArticulosView.xaml
    /// </summary>
    public partial class ArticulosView : UserControl
    {
        public ICollection<producto> Productos;
        public ArticulosView()
        {
            InitializeComponent();
            DataContext = new ArticulosViewModel();
            ArticulosViewModel artvm = new ArticulosViewModel();
            Productos = artvm.context.context.producto.ToList();
            dtArticulos.ItemsSource = Productos;
        }

   




        private void BtnAgregarArt_Click(object sender, RoutedEventArgs e)
        {
            AgregarArtView agr = new AgregarArtView();
            agr.Show();



        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            EditarArtView edit = new EditarArtView();
            edit.Show();
        }

      
    }
}
