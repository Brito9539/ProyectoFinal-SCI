using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SCI.Data.Tests
{
    [TestClass]
    public class BusinessContextTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void addUsduarioCommandNoEjecutaCuandoValorEsNulo()
        {
            string valor = null;
            using (var bc = new BusinessContext())
            {
                BusinessContext.Check.Require(valor);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void addUsduarioCommandNoEjecutaCuandoValorNoEsValido()
        {
            string valor = "";
            using (var bc = new BusinessContext())
            {
                BusinessContext.Check.Require(valor);
            }
        }
    }
}
