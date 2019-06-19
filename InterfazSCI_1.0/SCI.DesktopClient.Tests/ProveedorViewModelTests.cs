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
                context.AddUbicacion(new ubicacion {Colonia = "colprueba" });
                context.AddProveedor(new proveedor { Codigo = "1111", Nombre = "aasdad", idUbicacion = 1 });

                var viewModel = new ProveedorViewModel(context);
                viewModel.GetProveedoresCommand.Execute(null);

                Assert.IsTrue(viewModel.Proveedores.Count == 1);
            }
        }
        
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
    }
}
