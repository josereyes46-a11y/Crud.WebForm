using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Crud.BusinessLayer;

namespace TestProducto
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void PruebaCantidadProducto()
        {
            ProductoBL productoBL = new ProductoBL();

            bool result = productoBL.validarCantidad(10);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PruebaClaveProducto()
        {
            ProductoBL productoBL = new ProductoBL();

            try
            {
                bool result = productoBL.validarClaveProducto(5);
                Assert.IsTrue(result);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.Message);
            }
        }

        [TestMethod]
        public void PruebaNombreProducto()
        {
            ProductoBL productoBL = new ProductoBL();

            try
            {
                bool result = productoBL.validarNombre("Serrucho", 1, true);
                Assert.IsTrue(result);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.Message);
            }
        }


        [TestMethod]
        public void PruebaCantidadFallida() 
        {
            ProductoBL productoBL = new ProductoBL();

            bool result = productoBL.validarCantidad(-5);

            Assert.IsTrue(result);
        }
    }
}