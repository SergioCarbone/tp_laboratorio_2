using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace EntidadesHechas
{
    public static class PaqueteDAO
    {
        
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            try
            {
                SqlConnection conexion = new SqlConnection();

                //string query = string.Format("INSERT INTO PK_Paquetes (direccionEntrega,trackingID,alumno) VALUES ('{0}', '{1}','{2}'", p.DireccionEntrega, p.TrackingID, "Sergio Carbone");
                string query = string.Format("INSERT INTO PK_Paquete (direccionEntrega,trackingID,alumno) VALUES ('{0}', '{1}','{2}'", p.DireccionEntrega, p.TrackingID, "Sergio Carbone");
                SqlCommand comando = new SqlCommand(query, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
                retorno = true;
            }
            catch(Exception e)
            {
                throw new Exception("Error al insertar en la base de datos", e);
            }
            return retorno;
        }

        static PaqueteDAO()
        {
            SqlConnection conexion;            
            try
            {
                //string conectionStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True";
                string conectionStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=correo-sp-2018;Integrated Security=True";
                conexion = new SqlConnection(conectionStr);
            }
            catch (Exception e)
            {
                throw new Exception("Error en la coneccion con la base de datos", e);
            }            
        }
    }
}
