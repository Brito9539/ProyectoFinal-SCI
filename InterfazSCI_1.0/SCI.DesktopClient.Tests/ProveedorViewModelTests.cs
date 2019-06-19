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
    public class ProveedorViewModelTests : FuntionalTest
    {
        [TestMethod]
        public void agregarProveedor()
        {
            using (var context = new BusinessContext())
            {
                context.AddProveedor(new proveedor { Codigo="1111", Nombre = "aasdad"});

                var viewModel = new ProveedorViewModel(context);
                viewModel.GetProveedoresCommand.Execute(null);

                Assert.IsTrue(viewModel.Proveedores.Count == 1);
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
        public void editarProveedor()
        {
            using (var context = new BusinessContext())
            {
                context.AddProveedor(new proveedor { Codigo = "1111", Nombre = "aasdad" });

                var viewModel = new ProveedorViewModel(context);
                viewModel.GetProveedoresCommand.Execute(null);
                viewModel.SelectedProveedor = viewModel.Proveedores.First();

                viewModel.SelectedProveedor.Nombre = "NuevoNombre";
                viewModel.editProveedorCommand.Execute(null);

                //usuario selectedUsuario = context.context.usuario.Where(u => u.Matricula == "1236").FirstOrDefault();
                //context.context.Entry(selectedUsuario).CurrentValues.SetValues(new usuario { Nombre = "Nuevo", Apellido_Paterno = "asdasd", Apellido_Materno = "aasdasda", Matricula = "1236", Admin = 1, Contraseña = "12345", Correo = "asdasdadasdasd" });
                //context.deleteUsuario(selectedUsuario);

                var proveedor = context.context.usuario.Single();
                context.context.Entry(proveedor).Reload();
                Assert.AreEqual(viewModel.SelectedProveedor.Nombre, proveedor.Nombre);
            }
        }

        [TestMethod]
        public void eliminarProveedor()
        {
            using (var context = new BusinessContext())
            {
                context.AddProveedor(new proveedor { Codigo = "1111", Nombre = "aasdad" });

                proveedor selectedProveedor = context.context.proveedor.Where(u => u.Codigo == "1111").FirstOrDefault();
                context.deleteProveedor(selectedProveedor);

                var viewModel = new ProveedorViewModel(context);
                viewModel.GetProveedoresCommand.Execute(null);

                Assert.IsTrue(viewModel.Proveedores.Count == 0);
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
