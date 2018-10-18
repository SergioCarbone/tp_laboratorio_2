using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Metodos

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Persona)
            {
                if (this == (Universitario)obj)
                {
                    retorno = true;
                }
            }
            return retorno;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder(base.ToString());           
            datos.AppendFormat("\nlegajo: {0}", this.legajo);
            return datos.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (!(pg1 is null) && !(pg2 is null) && pg1.legajo == pg2.legajo && pg1.DNI == pg2.DNI)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return (!(pg1 == pg2));
        }


        protected abstract string ParticiparEnClase();


        public Universitario()
        {

        }


        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion
    }
}
