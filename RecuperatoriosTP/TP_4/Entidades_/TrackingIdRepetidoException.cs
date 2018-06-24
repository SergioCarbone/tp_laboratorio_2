using System;
using System.Runtime.Serialization;

namespace Entidades_
{
    public class TrackingIdRepetidoException : Exception
    {
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        { }

        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        { }
    }
}