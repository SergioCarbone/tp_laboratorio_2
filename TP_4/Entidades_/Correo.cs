using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;
using Entidades_;


namespace Entidades_
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

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete aux in c.Paquetes)
            {
                if (aux == p)
                {                   
                    throw new TrackingIdRepetidoException("El paquete ya esta en la lista!");
                }
            }

            if (!(c.paquetes.Contains(p)))
            {
                c.paquetes.Add(p);
                Thread hilo = new Thread(p.MockCicloDeVida);
                hilo.Start();
                c.mockPaquetes.Add(hilo);
            }

            return c;
        }


        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {           
            StringBuilder datos = new StringBuilder();
            foreach (Paquete p in (List<Paquete>)((Correo)elementos).paquetes)
            {
                datos.AppendLine(string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()));
            }
            return datos.ToString();
        }

        public void FinEntregas()
        {
            foreach (Thread hilo in this.mockPaquetes)
            {
                hilo.Abort();
            }
        }
    }
}