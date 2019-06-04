using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCI.Windows;
using SCI.DesktopClient;
using SCI.DesktopClient.ViewModels;

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
        public void addUsduarioCommandNoEjecutaCuandoNombreNoEsValido()
        {
            var viewModel = new UsuariosViewModel
            {
            };

        }
    }
}
