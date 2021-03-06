﻿using System;
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


        /// <summary>
        /// Agrega un alumno a una jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }


        /// <summary>
        /// Busca si un alumno ya esta cargado en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
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


        /// <summary>
        /// busca si un alumno no esta cargado en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return (!(j == a));
        }


        /// <summary>
        /// Muestra los datos de una jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();            
            datos.AppendFormat("\nClase de {0} por NOMBRE COMPLETO: {1}", this.Clases, this.instructor.ToString());                                   
            datos.AppendFormat("\n\nALUMNOS:");
            foreach (Alumno aux in alumnos)
            {
                datos.AppendFormat("\nNOMBRE COMPLETO: {0}", aux.ToString());
            }
            datos.AppendFormat("\n<-------------------------------------------->");
            datos.AppendLine();
            return datos.ToString();
        }

        public string MostrarDatos()
        {
            return ToString();
        }

        /// <summary>
        /// Guarda los datos de una jornada en un archivo txt
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Lee los datos de un archivo txt y los muestra
        /// </summary>
        /// <returns></returns>
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
