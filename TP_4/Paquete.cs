using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;

namespace Entidades
{
    public class Paquete:IMostrar<Paquete>
    {
        #region Attributes
        private string trackingId;
        private string direccionEntrega;
        private EEstado estado;
        #endregion Attributes

        #region Properties
        public string TrackingID
        {
            get { return this.trackingId;}
            set {this.trackingId = value;}
        }

        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }
        #endregion Properties

        #region Methods
        public Paquete(string tracking, string direccionEntrega)
        {
            this.trackingId = tracking;
            this.direccionEntrega = direccionEntrega;
            //this.estado = EEstado.Ingresado;
        }
        public void MockCicloDeVida()
        {
            EventArgs miEvent = new EventArgs();
            try
            {
                //for (this.Estado = 0; this.Estado <= EEstado.Entregado; this.Estado++)
                for (int i = 0; i <= (int)EEstado.Entregado; i++)
                {
                    switch(i)
                    {
                        case 1:
                            this.Estado = EEstado.EnViaje;
                            break;
                            
                        case 2:
                            this.Estado = EEstado.Entregado;
                            break;
                    }
                    InformaEstado.Invoke(this, miEvent);
                    Thread.Sleep(1000);
                }
                PaqueteDAO.Insertar(this);
            }
            catch (SqlException xSqlExc)
            {

                throw xSqlExc;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }

        public override string ToString()
        {
            return MostrarDatos((IMostrar<Paquete>) this);
        }
        #endregion Methods

        #region Operators
        public static bool operator ==(Paquete paq1, Paquete paq2)
        {
            return (paq1.TrackingID == paq2.TrackingID);
        }

        public static bool operator !=(Paquete paq1, Paquete paq2)
        {
            return (!(paq1 == paq2));
        }
        #endregion Operators

        #region Enumerator
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion Enumerator

        #region Delegate
        public delegate void DelegadoEstado(object sender, EventArgs e);
        #endregion Delegate

        #region Event
        public event DelegadoEstado InformaEstado;
        #endregion Event
    }
}
