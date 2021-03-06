
﻿using SCI.Data;
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
    public partial class ProveedoresView : UserControl
    {

        public ICollection<proveedor> Proveedores;

        public ProveedoresView()
        {
            InitializeComponent();
            DataContext = new ProveedorViewModel();

            UsuariosViewModel artvm = new UsuariosViewModel();
            Proveedores = artvm.context.context.proveedor.ToList();
            dtProveedores.ItemsSource = Proveedores;


        }

        private void BtnAgregarPro_Click(object sender, RoutedEventArgs e)
        {
            AgregarProView agr = new AgregarProView();
            agr.Show();
        }

        private void BtnProveedores_Click(object sender, RoutedEventArgs e)
        {
            EditarProView edit = new EditarProView();
            edit.Show();
        }
    }
}
