using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCI.Windows;
using SCI.DesktopClient;
using SCI.DesktopClient.ViewModels;
using SCI.Data;
using System.Linq;

namespace SCI.DesktopClient.Tests
{
    [TestClass]
    public class UsuarioViewModelTests
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

        //[TestMethod]
        //public void editarUsuarios()
        //{
        //    using (var context = new BusinessContext())
        //    {
        //        usuario selectedUsuario = new usuario { Nombre = "aasdad", Apellido_Paterno = "asdasd", Apellido_Materno = "aasdasda", Matricula = "1236", Admin = 1, Contraseña = "12345", Correo = "asdasdadasdasd" };

        //        context.updateUsuario(selectedUsuario);

        //        var viewModel = new UsuariosViewModel(context);
        //        viewModel.editUsuarioCommand.Execute(null);

        //        Assert.IsTrue);
        //    }
        //}

        [TestMethod]
        public void eliminarUsuario()
        {
            using (var context = new BusinessContext())
            {
                usuario selectedUsuario = new usuario { Nombre = "aasdad", Apellido_Paterno = "asdasd", Apellido_Materno = "aasdasda", Matricula = "1236", Admin = 1, Contraseña = "12345", Correo = "asdasdadasdasd" };
                context.deleteUsuario(selectedUsuario);

                var viewModel = new UsuariosViewModel(context);
                viewModel.deleteUsuarioCommand.Execute(null);

                Assert.IsTrue(viewModel.Usuarios.Count == 0);
            }
        }

        //[TestMethod]
        //public void addUsuarioAgregaUsuario()
        //{
        //    var viewModel = new UsuariosViewModel
        //    {
        //    };

        //}
    }
}
