using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        bool retorno = false;
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter writer = new StreamWriter(archivo);
                writer.WriteLine(datos);
                writer.Close();
                retorno =true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }

        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader reader = new StreamReader(archivo);
                datos = reader.ReadToEnd();
                reader.Close();
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
    }
}
