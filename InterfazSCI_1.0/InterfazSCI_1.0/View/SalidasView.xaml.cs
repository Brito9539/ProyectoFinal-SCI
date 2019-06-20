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
using SCI.Data;
using SCI.DesktopClient.ViewModels;

namespace SCI.DesktopClient.Views
{
    /// <summary>
    /// Lógica de interacción para SalidasView.xaml
    /// </summary>
    public partial class SalidasView : UserControl
    {

        EntradaViewModel evm = new EntradaViewModel();
        List<entrada> entradas = new List<entrada>();

        public SalidasView()
        {
            InitializeComponent();

            entradas = evm.context.context.entrada.ToList();

            


        }

        public void generarReporte()
        {
            foreach(var entrada in entradas)
            {
                
            }
        }
    }
}
