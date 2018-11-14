using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesHechas
{
    public class TrackingIdRepetidoException : Exception
    {
        TrackingIdRepetidoException(string mensaje)
            : this(mensaje,null)
        {

        }

        TrackingIdRepetidoException(string mensaje, Exception inner)
            : base(mensaje,inner)
        {

        }
    }
}
