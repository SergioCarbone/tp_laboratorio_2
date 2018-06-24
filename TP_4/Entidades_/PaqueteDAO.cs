using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades_
{
    public static class PaqueteDAO
    {        
        static SqlConnection conexion;
        static SqlCommand comando;

        static PaqueteDAO()
        {

        }

        public static bool Insertar(Paquete paquete)
        {
            bool retorno = false;
            conexion = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog=correo-sp-2017;Integrated Security=True");
            comando = new SqlCommand();                               
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                comando.CommandText = string.Format("INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES ('{0}','{1}', 'Sergio Carbone')", paquete.DireccionEntrega, paquete.TrackingID);
                comando.ExecuteNonQuery();
                conexion.Close();
                retorno = true;
            }
            catch(Exception)
            {
               
            }

            return retorno;
        }        
    }
}
