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
                context.AddProducto(new producto { Nombre = "aaasdasd", Unidad = "Litros", Cantidad_Actual = 0, idProducto = "1234", PuntoReorden = 5 });

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
                context.AddProducto(new producto { Nombre = "aaasdasd", Unidad = "Litros", Cantidad_Actual = 0, idProducto = "1234", PuntoReorden = 5 });

                var viewModel = new ArticulosViewModel(context);
                viewModel.GetProductosCommand.Execute(null);
                viewModel.SelectedProducto = viewModel.Productos.First();

                viewModel.SelectedProducto.Nombre = "NuevoNombre";
                viewModel.editProductoCommand.Execute(null);

                var producto = context.context.producto.Single();
                context.context.Entry(producto).Reload();
                Assert.AreEqual(viewModel.SelectedProducto.Nombre, producto.Nombre);
            }
        }

        [TestMethod]
        public void eliminarProducto()
        {
            using (var context = new BusinessContext())
            {
                context.AddProducto(new producto { Nombre = "aaasdasd", Unidad = "Litros", Cantidad_Actual = 0, idProducto = "1234", PuntoReorden = 5 });

                producto selectedProducto = context.context.producto.Where(u => u.Nombre == "aaasdasd").FirstOrDefault();
                context.deleteProducto(selectedProducto);

                var viewModel = new ArticulosViewModel(context);
                viewModel.GetProductosCommand.Execute(null);

                Assert.IsTrue(viewModel.Productos.Count == 0);
            }
        }
    }
}
