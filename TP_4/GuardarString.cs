using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {
        //Ver como generar Método de extension String
        public static bool Guardar(this String texto, string fileName)
        {
            try
            {
                string xpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                xpath += @"\" + fileName;
                StreamWriter xSW = new StreamWriter(xpath, File.Exists(xpath));
                xSW.WriteLine(texto);
                xSW.Close();
            }
            catch (FileNotFoundException fnfExc)
            {
                throw fnfExc;
            }
            catch (IOException ioExc)
            {

                throw ioExc;
            }
            catch(Exception e)
            {
                throw e;
            }            
            return true;
        }
    }
}
