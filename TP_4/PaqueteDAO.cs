using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Attributes
        static SqlConnection conexion;
        static SqlCommand commando;
        #endregion Attributes

        #region Methods
        static PaqueteDAO()
        {
            //conexion = new SqlConnection();
            //commando = new SqlCommand();
        }

        public static bool Insertar(Paquete paq)
        {
            //SqlConnection xCon = new SqlConnection();
            //xCon.ConnectionString = @"Data source = .\SQLEXPRESS;Initial catalog = correo_sp_2017; Integrate Security = true";
            //SqlCommand xCmd = new SqlCommand();
            //xCmd.Connection = xCon;
            //xCmd.CommandType = System.Data.CommandType.Text;
            //xCmd.CommandText = "INSERT INTO correo_sp_2017 VALUES ('"+paq.TrackingID+"','"+paq.DireccionEntrega+"','"+paq.Estado+"')";
            //xCon.Close();
            //conexion.ConnectionString = Properties.Settings.Default.ConectionString;
            //commando.Connection = conexion;
            //commando.CommandType = System.Data.CommandType.Text;
            conexion = new SqlConnection();
            commando = new SqlCommand();
            try
            {
                conexion.ConnectionString = Properties.Settings.Default.ConectionString;
                commando.Connection = conexion;
                commando.CommandType = System.Data.CommandType.Text;
                conexion.Open();
                commando.CommandText = String.Format("INSERT INTO Paquetes VALUES ('{0}','{1}','{2}')",paq.DireccionEntrega, paq.TrackingID, "Diego Dipietro");
                commando.ExecuteNonQuery();
            }
            catch (SqlException sqlE)
            {
                throw sqlE;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexion.Close();
            }
         return true;
        }
        #endregion Methods
    }
}
