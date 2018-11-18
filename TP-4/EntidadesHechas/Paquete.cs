using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesHechas
{
    
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public delegate void DelegadoConexion(object sender, Exception inner);
        public event DelegadoEstado InformarEstado;
        public event DelegadoConexion InformarConexion;
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }

        private string direccionEntrega;
        private string trackingID;
        private EEstado estado;

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

        #region Propiedades

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Compara dos paquetes siendo iguales si coinciden sus trackingId
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>true si son iguales - false si no son iguales</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if(p1.trackingID == p2.trackingID)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Compara dos paquetes siendo distintos si no coinciden sus trackingId
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>true si son distintos - false si no son distintos</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        

        /// <summary>
        /// Muestra los datos de un paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        /// 
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine(string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega));
            return datos.ToString();
        }

        

        /// <summary>
        /// Cambia el estado de los paquetes hasta que cumple es recorrido y guarda en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                System.Threading.Thread.Sleep(1000);
                this.Estado++;
                // Informar el estado a través de InformarEstado. EventArgs
                InformarEstado(this.Estado, null);
            } while (this.Estado != EEstado.Entregado);
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch(Exception e)
            {
                InformarConexion(this,e);
            }
            
        }

        #endregion
    }
}
