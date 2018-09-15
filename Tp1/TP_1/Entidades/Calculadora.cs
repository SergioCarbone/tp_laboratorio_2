using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza una operacion entre dos Numeros validando que la operacion sea correcta
        /// </summary>
        /// <param name="num1">Primer valor recibido</param>
        /// <param name="num2">Segundo valor recibido</param>
        /// <param name="operador">Operacion a realizar</param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            string op = Validar(operador);
            double resultado = 0;
            switch(op)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }

        /// <summary>
        /// Valida la operacion que se quiere realizar, si no es correcta realiza una suma
        /// </summary>
        /// <param name="operador">operador recibido</param>
        /// <returns>Retorn el operador</returns>
        private static string Validar(string operador)
        {
            string retorno;
            if (operador == "/" || operador == "*" || operador == "-")
            {
                retorno = operador;
            }
            else
            {
                retorno = "+";
            }
            return retorno;
        }
    }
}
