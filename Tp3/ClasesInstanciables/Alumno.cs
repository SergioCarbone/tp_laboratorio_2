using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region Metodos

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }


        public Alumno(int id, string nombre, string apellido, string dni, Universitario.ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }


        /// <summary>
        /// Muestra los datos de un alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder(base.MostrarDatos());
            string estado = "";
            if(this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                estado += "Cuota al dia";
            }
            else if(this.estadoCuenta == EEstadoCuenta.Becado)
            {
                estado += "Becado";
            }
            else
            {
                estado += "Deudor";
            }
            datos.AppendFormat("\n\nEstado de cuenta: {0}", estado);
            datos.Append(ParticiparEnClase());            
            return datos.ToString();            
        }


        /// <summary>
        /// Se fija si el alumno toma una clase y que no sea deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }
            return retorno;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if(a.claseQueToma != clase)
            {
                return true;
            }
            return retorno;
        }


        /// <summary>
        /// Muestra en que clase participa
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {            
            return string.Format("\nTOMA CLASE DE {0}", this.claseQueToma);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        #endregion

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado,
        }
    }
}
