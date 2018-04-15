using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            string retorno;
            if ((operador == "+") || (operador == "*") || (operador == "/") || (operador == "-"))
            {
                retorno = operador;
            }
            else
            {
                retorno = "+";
            }
            return retorno;
        }


        public static double Operar(double num1, double num2, string operador)
        {
            string op;
            double retorno;
            op = ValidarOperador(operador);

            if (op == "+")
            {
                retorno = num1 + num2;
            }
            else if (op == "-")
            {
                retorno = num1 - num2;
            }
            else if (op == "/")
            {
                retorno = num1 / num2;
            }
            else
            {
                retorno = num1 * num2;
            }
            return retorno;
        }
    }
}
