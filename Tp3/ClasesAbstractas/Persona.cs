using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #region Propiedades
        /// <summary>
        /// 
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (ValidarNombreApellido(value) == "ok")
                {
                    this.apellido = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                try
                {
                    if (ValidarDni(this.Nacionalidad, value) != -1)
                    {
                        this.dni = value;
                    }                    
                }
                catch(NacionalidadInvalidaException e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if(ValidarNombreApellido(value) == "ok")
                {
                    this.nombre = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string StringToDNI
        {
            set
            {
                try
                {
                    if(ValidarDni(this.Nacionalidad, value) != "")
                    {
                        this.dni = Convert.ToInt32(value);
                    }
                }
                catch(DniInvalidoException w)
                {
                    throw w;
                }
                catch(NacionalidadInvalidaException e)
                {
                    throw e;
                }
            }
        }

        #endregion

        #region Metodos

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad)
            : this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Muestra los datos de una persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendFormat("{0} {1}",this.Apellido, this.Nombre);            
            datos.AppendFormat("\nNACIONALIDAD: {0}", this.nacionalidad);            
            return datos.ToString();
        }
        
        /// <summary>
        /// Valida que el dni y la nacionalidad sean correctos
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = -1;

            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
            {
                retorno = dato;
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {
                retorno = dato;
            }
            else
            {
                throw new NacionalidadInvalidaException("Error, no coincide nacionalidad y rango de dni");
            }
            return retorno;
            
        }

        /// <summary>
        /// Valida que un dni contenga solo numeros
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            bool esNumero = true;
            string retorno = "";
            int aux;

            for (int i = 0; i < dato.Length; i++)
            {
                if (!(char.IsNumber(dato[i])))
                {
                    esNumero = false;
                    break;
                }
            }

            if (esNumero == true)
            {
                aux = Convert.ToInt32(dato);
                if (nacionalidad == ENacionalidad.Argentino && aux >= 1 && aux <= 89999999)
                {
                    retorno = dato;
                }
                else if (nacionalidad == ENacionalidad.Extranjero && aux >= 90000000 && aux <= 99999999)
                {
                    retorno = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                }
            }
            else
            {
                throw new DniInvalidoException("No son solo numeros");
            }
            return retorno;
        }

        /// <summary>
        /// Valida que un string contenga solo letras
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = "ok";
            for (int i = 1; i < dato.Length; i++)
            {
                if(!(dato[0] >= 'A' && dato[0] <= 'Z'))
                {
                    retorno = "error";
                    break;
                }
                
                if (!(dato[i] >= 'a' && dato[i] <= 'z'))
                {
                    retorno = "error";
                    break;
                }
            }
            return retorno;
        }

        #endregion


        public enum ENacionalidad
        {
            Argentino,
            Extranjero,
        }
    }
}
