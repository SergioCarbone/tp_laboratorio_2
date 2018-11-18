using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EntidadesHechas
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Paquete> paquetes;
        private List<Thread> mockPaquetes;

        public Correo()
        {
            paquetes = new List<Paquete>();
            mockPaquetes = new List<Thread>();
        }

        #region Propiedad
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region Metodos       

        /// <summary>
        /// Agrega un paquete a la lista del correo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns>retorna el correo</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete aux in c.paquetes)
            {
                if (p == aux)
                {
                    throw new TrackingIdRepetidoException("Id repetido");
                }
            }
            c.paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();

            return c;
        }

        /// <summary>
        /// Muestra los datos de un paquete
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> l = (List<Paquete>)((Correo)elementos).Paquetes;
            StringBuilder datos = new StringBuilder();
            foreach (Paquete p in l)
            {
                datos.AppendLine( string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega,p.Estado.ToString()));
            }            
            return datos.ToString();
        }

        /// <summary>
        /// Cierra todos los hilos que esten activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilo in mockPaquetes)
            {
                if(hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
        }

        #endregion
    }
}
