using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        #region Metodos

        public DniInvalidoException()
            : this("")
        {

        }

        public DniInvalidoException(Exception e)
            : this("",e)
        {

        }

        public DniInvalidoException(string mensaje)
            : this(mensaje,null)
        {

        }

        public DniInvalidoException(string mensaje, Exception e)
            : base(mensaje,e)
        {
            this.mensajeBase = mensaje;
        }
        #endregion
    }
}
