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
    public class ArticulosViewModelTests : FuntionalTest
    {
        [TestMethod]
        public void agregarProducto()
        {
            using (var context = new BusinessContext())
            {
                context.AddProducto(new producto { Nombre = "aaasdasd", Unidad = "Litros" });

                var viewModel = new ArticulosViewModel(context);
                viewModel.GetProductosCommand.Execute(null);

                Assert.IsTrue(viewModel.Productos.Count == 1);
            }
        }
        
        [TestMethod]
        public void editarProducto()
        {
            using (var context = new BusinessContext())
            {
                context.AddProducto(new producto { Nombre = "aaasdasd", Unidad = "Litros" });

                var viewModel = new ArticulosViewModel(context);
                viewModel.GetProductosCommand.Execute(null);
                viewModel.SelectedProducto = viewModel.Productos.First();

                viewModel.SelectedProducto.Nombre = "NuevoNombre";
                viewModel.editProductoCommand.Execute(null);

                var usuario = context.context.usuario.Single();
                context.context.Entry(usuario).Reload();
                Assert.AreEqual(viewModel.SelectedProducto.Nombre, usuario.Nombre);
            }
        }

        [TestMethod]
        public void eliminarProducto()
        {
            using (var context = new BusinessContext())
            {
                context.AddProducto(new producto { Nombre = "aaasdasd", Unidad = "Litros" });

                producto selectedProducto = context.context.producto.Where(u => u.Nombre == "aaasdasd").FirstOrDefault();
                context.deleteProducto(selectedProducto);

                var viewModel = new ArticulosViewModel(context);
                viewModel.GetProductosCommand.Execute(null);

                Assert.IsTrue(viewModel.Productos.Count == 0);
            }
        }
    }
}
