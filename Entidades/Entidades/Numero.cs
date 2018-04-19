using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }


        public Numero()
        {
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            this.SetNumero = numero;
        }

        private double ValidarNumero(string strNumero)
        {
            double auxiliar, retorno;
            if (double.TryParse(strNumero, out auxiliar))
            {
                retorno = auxiliar;
            }
            else
            {
                retorno = 0;
            }
            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        static public double BinarioDecimal(string binario)
        {
            double numero = 0;
            double auxliliar;
            int j = 0, contador = 0;

            do
            {
                for (int i = binario.Length; i > 0; i--)
                {
                    if (binario[i - 1] == '0' || binario[i - 1] == '1')
                    {
                        if (binario[i - 1] == '1')
                        {
                            auxliliar = Math.Pow(2, j);
                            numero += auxliliar;
                        }
                        j++;
                    }
                    else
                    {
                        contador++;
                        j++;
                    }
                }
                if (contador != 0)
                {
                    numero = -1;
                }

            } while (j < binario.Length);

            return numero;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        static public string DecimalBinario(double numero)
        {
            int resultado, resto;
            int auxiliar = (int)numero;
            string binario = "", auxBinario;
            string resBinario = "";

            do
            {
                resultado = auxiliar / 2;
                resto = auxiliar % 2;
                auxiliar = resultado;
                auxBinario = Convert.ToString(resto);
                binario += auxBinario;

            } while (resultado != 1);
            auxBinario = Convert.ToString(resultado);
            binario += auxBinario;

            for (int i = binario.Length; i >= 0; i--)
            {
                if (i != 0)
                {
                    resBinario += binario[i - 1];
                }
            }
            return resBinario;
        }

        public static double operator + (Numero valor1, Numero valor2)
        {
            double retorno = valor1 + valor2;
            return retorno;
        }

        public static double operator - (Numero valor1, Numero valor2)
        {
            double retorno = valor1 - valor2;
            return retorno;
        }

        public static double operator / (Numero valor1, Numero valor2)
        {
            double retorno = valor1 / valor2;
            return retorno;
        }

        public static double operator * (Numero valor1, Numero valor2)
        {
            double retorno = valor1 * valor2;
            return retorno;
        }
    }
}
