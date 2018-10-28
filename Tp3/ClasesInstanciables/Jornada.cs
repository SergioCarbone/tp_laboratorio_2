using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;


namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clases;
        private Profesor instructor;
        
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


        public Universidad.EClases Clases
        {
            get
            {
                return this.clases;
            }
            set
            {
                this.clases = value;
            }
        }


        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Metodos

        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.Clases = clase;
            this.Instructor = instructor;
        }


        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }


        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno aux in j.Alumnos)
            {
                if(a == aux)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }


        public static bool operator !=(Jornada j, Alumno a)
        {
            return (!(j == a));
        }


        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            
            foreach (Alumno aux in alumnos)
            {
                datos.AppendFormat("{0}", aux.ToString());
            }
            return datos.ToString();
        }

        public string mostrarDatos()
        {
            return ToString();
        }

        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            Texto a = new Texto();
            string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + "pruebaTxT";
            if(a.Guardar(archivo,jornada.ToString()))                
            {
                retorno = true;
            }
            return retorno;
        }


        public static string Leer()
        {
            string retorno = "";            
            string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + "pruebaTxt";
            Texto a = new Texto();
            if(a.Leer(archivo,out string j))
            {
                retorno = j.ToString();
            }
            return retorno;
        }


        #endregion
    }
}
