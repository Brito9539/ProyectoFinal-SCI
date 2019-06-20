using System.Windows;
using System.Windows.Controls;
using SCI.DesktopClient.ViewModels;

namespace SCI.DesktopClient.Views
{
    /// <summary>
    /// Lógica de interacción para ArticulosView.xaml
    /// </summary>
    public partial class ArticulosView : UserControl
    {
        public ArticulosView()
        {
            InitializeComponent();
            DataContext = new ArticulosViewModel();
            
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
