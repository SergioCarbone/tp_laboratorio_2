using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;


        #region Propiedades

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }


        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }


        public Jornada this[int i]
        {
            get
            {
                return jornadas[i];                                
            }
            set
            {
                this.jornadas[i] = value;
            }
        }
        #endregion


        #region Metodos

        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            Xml<Universidad> a = new Xml<Universidad>();
            string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + "pruebaXml";
            if (a.Guardar(archivo,uni))
            {
                retorno = true;
            }
            return retorno;
        }


        public static string Leer()
        {
            string retorno = "";
            string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + "pruebaXml";
            Xml<Universidad> uni = new Xml<Universidad>();
            ;

            if (uni.Leer(archivo,out Universidad j))
            {
                retorno = j.ToString();
            }
            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendFormat("JORNADA:");
            foreach (Profesor prof in uni.profesores)
            {                
                datos.AppendLine(prof.ToString());
                datos.AppendFormat("CLASES DEL DIA:");
                datos.AppendFormat("\n\n");
                datos.AppendFormat("ALUMNOS:");
                foreach (Alumno aux in uni.alumnos)
                {                    
                    datos.AppendFormat("\n{0}",aux.ToString());
                }
                datos.AppendFormat("\n<-------------------------------------------->");
                datos.AppendLine();
            }
            return datos.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="uni"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad uni, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno aux in uni.alumnos)
            {
                if(aux == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="uni"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad uni, Alumno a)
        {
            return (!(uni == a));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="uni"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad uni, Profesor i)
        {
            bool retorno = false;
            foreach (Profesor aux in uni.profesores)
            {
                if(aux == i)
                {
                    retorno = true;
                    break;
                }                
            }
            return retorno;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="uni"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad uni, Profesor i)
        {
            return (!(uni == i));
        }



        public static Profesor operator ==(Universidad uni, Universidad.EClases clase)
        {                                   
            foreach (Profesor aux in uni.profesores)
            {                
                if(aux == clase)
                {
                    return aux;
                }
            }
            throw new SinProfesorException();
        }


        public static Profesor operator !=(Universidad uni, Universidad.EClases clase)
        {
            Profesor p = null;
            foreach (Jornada aux in uni.jornadas)
            {
                if (aux.Clases != clase)
                {
                    p = aux.Instructor;
                    break;
                }
            }
            return p;
        }


        public Universidad()
        {
            jornadas = new List<Jornada>();
            profesores = new List<Profesor>();
            alumnos = new List<Alumno>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="uni"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad uni, Universidad.EClases clase)
        {
            Profesor p = (uni == clase);
            Jornada j = new Jornada(clase,p);
            foreach (Alumno aux in uni.alumnos)
            {
                if(aux == clase)
                {
                    j += aux;
                }
            }
            uni.jornadas.Add(j);
            return uni;
        }


        public static Universidad operator +(Universidad uni, Alumno a)
        {
            if(uni != a)
            {
                uni.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return uni;
        }


        public static Universidad operator +(Universidad uni, Profesor i)
        {
            if(uni != i)
            {
                uni.profesores.Add(i);
            }
            return uni;
        }


        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion


        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD,
        }
    }
}
