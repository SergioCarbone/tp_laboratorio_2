using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades_;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInstancia()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        public void TestPaqueteDuplicado()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("casa de sergio", "1234");
            Paquete p2 = new Paquete("casa de sergio", "1234");
            

            correo += p1;
            try
            {
                correo += p2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
            