using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using ClasesInstanciables;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {      
        [TestMethod]
        public void TestExceptionDni()
        {
            try
            {
                Alumno a = new Alumno(4, "sergio", "carbone", "dsfasd", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }


        [TestMethod]
        public void TestExceptionNacionalidad()
        {
            try
            {
                Alumno a = new Alumno(4, "sergio", "carbone", "123", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void TestValidarValorNumerico()
        {
            Alumno a = null;
            int b = 94000000;
            try
            {
                //a = new Alumno();               
                a = new Alumno(1, "sergio", "carbone", b.ToString(), Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
                a.DNI = 1;

            }
            catch (Exception e)
            {
                Assert.IsTrue(a.DNI == b);
            }
        }

        [TestMethod]
        public void TestValidarAtributosNulos()
        {
            Profesor b= new Profesor(45, "sfsd", "dsaf", "123", Persona.ENacionalidad.Argentino);
            Jornada a = new Jornada(Universidad.EClases.Laboratorio, b);

            Assert.IsNotNull(a.Alumnos);
        }
    }
}
