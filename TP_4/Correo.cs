using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;

namespace Entidades
{
    public class Correo:IMostrar<List<Paquete>>
    {
        #region Atributes
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion Atributes

        #region Properties
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

        public List<Thread> MockPaquetes
        {
            get
            {
                return this.mockPaquetes;
            }
            set
            {
                this.mockPaquetes = value;
            }

        }
        #endregion Properties

        #region Methods
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            //Preguntar el Lunes o Martes
            StringBuilder xStr = new StringBuilder();
            foreach(Paquete xItem in (List<Paquete>)((Correo)elementos).Paquetes)
            {
                xStr.AppendLine(String.Format("{0} ({1})", xItem.ToString(), xItem.Estado.ToString()));
            }
            /*if(elementos is IMostrar<List<Paquete>>)
            {
                foreach (IMostrar<List<Paquete>> xItem in ((Correo)elementos).Paquetes)
                {
                    xStr.AppendLine(String.Format("{0} ({1})", ((Paquete)xItem).ToString(), ((Paquete)xItem).Estado.ToString()));
                }
            }
            */
            return xStr.ToString();
        }

        public void FinEntregas()
        {
            foreach(Thread th in this.MockPaquetes)
            {
                if (th.IsAlive)
                    th.Abort();
            }
        }
        #endregion Methods

        #region Operators
        public static Correo operator + (Correo c, Paquete p)
        {
            bool existeBO = false;
            foreach (Paquete xItem in c.Paquetes)
            {
                //if(!(xItem != p))
                if (xItem == p)
                {
                    //existeBO = true;
                    throw new TrackingIdRepetidoException("El paquete ya esta en la lista!");
                }
            }
            if (!existeBO)
            {
                try
                {
                    c.Paquetes.Add(p);
                    Thread hiloMock = new Thread(p.MockCicloDeVida);
                    c.mockPaquetes.Add(hiloMock);
                    hiloMock.Start();
                }
                catch (SqlException sqlEx)
                {

                    throw sqlEx;
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
            return c;
        }
        #endregion Operators
    }
}
