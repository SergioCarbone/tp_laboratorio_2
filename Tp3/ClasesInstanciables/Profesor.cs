using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace ClasesInstanciables
{
    sealed public class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Metodos

        /// <summary>
        /// Agrega dos clases aleatorias
        /// </summary>
        private void RandomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                clasesDelDia.Enqueue((Universidad.EClases)random.Next((int)Universidad.EClases.Programacion, (int)Universidad.EClases.SPD));
            }
        }


        /// <summary>
        /// Muestra los datos de un profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.Append(base.MostrarDatos());
            datos.AppendFormat("\nCLASES DEL DIA:");
            datos.AppendFormat(ParticiparEnClase());            
            return datos.ToString();
        }


        /// <summary>
        /// Se fija si un profesor no dicta una clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return (!(i == clase));
        }


        /// <summary>
        /// Se fija si un profesor da una clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach (Universidad.EClases aux in i.clasesDelDia)
            {
                if(aux == clase)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Muestra las clases que da un profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder clase = new StringBuilder();
            foreach (Universidad.EClases aux in this.clasesDelDia)
            {
                clase.AppendFormat("\n{0}", aux);
            }                           
            return clase.ToString();
        }


        static Profesor()
        {
            random = new Random();
        }


        private Profesor()
        {
            
        }


        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            RandomClases();
        }

       
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
    }
}
