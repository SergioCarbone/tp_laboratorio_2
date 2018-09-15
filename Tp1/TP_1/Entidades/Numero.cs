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

        public Numero() { }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Valida que es string sea un numero, caso contrario retorna un 0
        /// </summary>
        /// <param name="strNumero">String a validar</param>
        /// <returns>Retorna el numero convertido en double</returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno, aux;
            if(double.TryParse(strNumero, out aux))
            {
                retorno = aux;
            }
            else
            {
                retorno = 0;
            }
            return retorno;
        }

        /// <summary>
        /// Convierte un numero binario a un decimal
        /// </summary>
        /// <param name="binario">numero binario que se desea convertir</param>
        /// <returns>Si pudo convertir retorna el numero decimal caso contrario retorna mensaje</returns>
        public static string BinarioDecimal(string binario)
        {
            int j = 0;
            string retorno = "1";
            double aux, resultado = 0;
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    retorno = "-1";
                    break;
                }
            }

            if (retorno == "1")
            {
                retorno = "";
                for (int i = binario.Length; i > 0; i--)
                {
                    if (binario[i - 1] == '1')
                    {
                        aux = Math.Pow(2, j);
                        resultado += aux;
                    }
                    j++;
                }
                retorno = Convert.ToString(resultado);
            }
            else
            {
                retorno = "Valor invalido";
            }
            return retorno;
        }


        /// <summary>
        /// Convierte un numero decimal en binario
        /// </summary>
        /// <param name="numero">numero decimal a convertir</param>
        /// <returns>numero convertido o mensaje de error</returns>
        public static string DecimalBinario(double numero)
        {
            int resto, resultado, auxiliar;
            string binario = "", auxBinario, retorno = "", strAux;

            strAux = Convert.ToString(numero);

            if (int.TryParse(strAux, out auxiliar))
            {
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

                for (int i = binario.Length; i > 0; i--)
                {
                    retorno += binario[i - 1];
                }
            }
            else
            {
                retorno = "Valor invalido";
            }
            return retorno;
        }


        /// <summary>
        /// Convierte un numero decimal en binario
        /// </summary>
        /// <param name="numero">numero decimal a convertir</param>
        /// <returns>numero convertido o mensaje de error</returns>
        public static string DecimalBinario(string numero)
        {
            double aux;
            string binario = "";
            if(double.TryParse(numero, out aux))
            {
                binario = DecimalBinario(aux);
            }
            return binario;
        }

        /// <summary>
        /// Resta dos numeros
        /// </summary>
        /// <param name="num1">Numero recibido</param>
        /// <param name="num2">Numero recibido</param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator -(Numero num1, Numero num2)
        {
            double retorno = num1.numero - num2.numero;
            return retorno;
        }


        /// <summary>
        /// Suma dos numeros
        /// </summary>
        /// <param name="num1">Numero recibido</param>
        /// <param name="num2">Numero recibido</param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator +(Numero num1, Numero num2)
        {
            double retorno = num1.numero + num2.numero;
            return retorno;
        }

        /// <summary>
        /// Multiplica dos numeros
        /// </summary>
        /// <param name="num1">Numero recibido</param>
        /// <param name="num2">Numero recibido</param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator *(Numero num1, Numero num2)
        {
            double retorno = num1.numero * num2.numero;
            return retorno;
        }

        /// <summary>
        /// Divide dos numeros
        /// </summary>
        /// <param name="num1">Numero recibido</param>
        /// <param name="num2">Numero recibido</param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator /(Numero num1, Numero num2)
        {
            double retorno = num1.numero / num2.numero;
            return retorno;
        }
    }
}
