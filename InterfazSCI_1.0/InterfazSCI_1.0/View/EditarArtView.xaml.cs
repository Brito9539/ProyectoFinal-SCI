using SCI.DesktopClient.ViewModels;
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
    /// Lógica de interacción para EditarArtView.xaml
    /// </summary>
    public partial class EditarArtView : Window
    {
        public EditarArtView()
        {
            InitializeComponent();
            DataContext = new ArticulosViewModel();
        }

        private void BtnEditarArt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
