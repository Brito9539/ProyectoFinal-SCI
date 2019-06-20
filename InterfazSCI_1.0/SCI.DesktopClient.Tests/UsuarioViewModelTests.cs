using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCI.Windows;
using SCI.DesktopClient;
using SCI.DesktopClient.ViewModels;
using SCI.Data;
using System.Linq;
using SCI.Data.Tests;

namespace SCI.DesktopClient.Tests
{
    [TestClass]
    public class UsuarioViewModelTests : FuntionalTest
    {
        [TestMethod]
        public void IsViewModel()
        {
            Assert.IsTrue(typeof(ViewModel).IsAssignableFrom(typeof(UsuariosViewModel)));
        }

        [TestMethod]
        public void agregarUsuarios()
        {
            using (var context = new BusinessContext())
            {
                context.AddUsuario(new usuario { Nombre = "aasdad", Apellido_Paterno = "asdasd", Apellido_Materno = "aasdasda", Matricula = "1236", Admin = 1, Contraseña = "12345", Correo = "asdasdadasdasd" });

                var viewModel = new UsuariosViewModel(context);
                viewModel.GetUsuariosCommand.Execute(null);

                Assert.IsTrue(viewModel.Usuarios.Count == 1);
            }
        }
        
        [TestMethod]
        public void editarUsuario()
        {
            using (var context = new BusinessContext())
            {
                context.AddUsuario(new usuario { Nombre = "aasdad", Apellido_Paterno = "asdasd", Apellido_Materno = "aasdasda", Matricula = "1236", Admin = 1, Contraseña = "12345", Correo = "asdasdadasdasd" });

                var viewModel = new UsuariosViewModel(context);
                viewModel.GetUsuariosCommand.Execute(null);

                viewModel.SelectedUsuario = viewModel.Usuarios.First();

                viewModel.SelectedUsuario.Nombre = "NuevoNombre";
                viewModel.editUsuarioCommand.Execute(null);
                
                var usuario = context.context.usuario.Single();
                context.context.Entry(usuario).Reload();
                Assert.AreEqual(viewModel.SelectedUsuario.Nombre, usuario.Nombre);
            }
        }

        [TestMethod]
        public void eliminarUsuario()
        {
            using (var context = new BusinessContext())
            {
                context.AddUsuario(new usuario { Nombre = "aasdad", Apellido_Paterno = "asdasd", Apellido_Materno = "aasdasda", Matricula = "1236", Admin = 1, Contraseña = "12345", Correo = "asdasdadasdasd" });

                usuario selectedUsuario = context.context.usuario.Where(u => u.Matricula == "1236").FirstOrDefault();
                context.deleteUsuario(selectedUsuario);

                var viewModel = new UsuariosViewModel(context);
                viewModel.GetUsuariosCommand.Execute(null);

                Assert.IsTrue(viewModel.Usuarios.Count == 0);
            }
        }
    }
}
