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

namespace InterfazSCI_1._0
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Style s = new Style();
            s.Setters.Add(new Setter(UIElement.VisibilityProperty, Visibility.Collapsed));
            tcmenu.ItemContainerStyle = s;
            DataContext = new MainViewModel();
        }

        private void BtnEntradas_Click(object sender, RoutedEventArgs e)
        {
            tcmenu.SelectedIndex = 0;
        }

        private void BtnSalidas_Click(object sender, RoutedEventArgs e)
        {
            tcmenu.SelectedIndex = 1;
        }

        private void BtnArticulos_Click(object sender, RoutedEventArgs e)
        {
            tcmenu.SelectedIndex = 2;
        }

        private void BtnAgregarArt_Click(object sender, RoutedEventArgs e)
        {
            tcmenu.SelectedIndex = 3;
        }

      
        private void BtnAgregarUsu_Click(object sender, RoutedEventArgs e)
        {
            tcmenu.SelectedIndex = 6;
        }

        private void BtnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            tcmenu.SelectedIndex = 7;
        }

        private void BtnAgregarPro_Click(object sender, RoutedEventArgs e)
        {
            tcmenu.SelectedIndex = 9;
        }

        private void BtnUsuario_Click(object sender, RoutedEventArgs e)
        {
            tcmenu.SelectedIndex = 5;
        }

        private void BtnProveedores_Click(object sender, RoutedEventArgs e)
        {
            tcmenu.SelectedIndex = 8;
        }
    }
}
