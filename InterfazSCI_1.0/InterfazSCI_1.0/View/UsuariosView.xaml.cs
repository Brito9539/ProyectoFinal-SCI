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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SCI.DesktopClient.Views
{
    /// <summary>
    /// Lógica de interacción para UsuariosView.xaml
    /// </summary>
    public partial class UsuariosView : UserControl
    {
        public UsuariosView()
        {
            InitializeComponent();
            DataContext = new UsuariosViewModel();
            
        }

        private void BtnAgregarUsu_Click(object sender, RoutedEventArgs e)
        {
            AgregarUsuView agr = new AgregarUsuView();
            agr.Show();

        }

        private void BtnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            EditarUsuView edit = new EditarUsuView();
            edit.Show();
        }
    }
}
