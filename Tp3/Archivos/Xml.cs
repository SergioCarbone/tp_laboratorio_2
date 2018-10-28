using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {        
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter write;
            XmlSerializer ser;
            
            write = new XmlTextWriter(archivo, Encoding.UTF8);
            ser = new XmlSerializer(typeof(T));

            ser.Serialize(write, datos);
            write.Close();
            return false;
        }

        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader;
            XmlSerializer ser;

            reader = new XmlTextReader(archivo);
            ser = new XmlSerializer(typeof(T));

            datos = (T)ser.Deserialize(reader);
            reader.Close();

            return false;
        }
    }
}
