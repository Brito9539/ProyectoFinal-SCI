using SCI.DesktopClient.Views;
using SCI.DesktopClient.ViewModels;
using System.Windows;
using SCI.Data;
using System.Linq;
using System;

namespace SCI.DesktopClient
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLlogin_Click(object sender, RoutedEventArgs e)
        {
            UsuariosViewModel uvm = new UsuariosViewModel();
            usuario usu = new usuario();

            try
            {
                usu = uvm.context.context.usuario.Where(u => u.Matricula == txtMatri.Text).FirstOrDefault();


                if (usu.Contraseña == txtPass.Password)
                {
                    MainWindow menu = new MainWindow();
                    menu.Show();
                    this.Hide();
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
