using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Calculadora calculadora = new Calculadora();
            Numero operaciones = new Numero();

            double numero1, numero2;
            string operador, salir = "n", opcion;

            do
            {
                Console.Clear();
                Console.Write("Ingrese el primer operando: ");
                if(double.TryParse(Console.ReadLine(), out numero1))
                {
                    Console.Write("Ingrese el segundo operando: ");
                    if(double.TryParse(Console.ReadLine(), out numero2))
                    {
                        Console.WriteLine("\n1 - Operar. ");
                        Console.WriteLine("2 - Salir.");
                        Console.WriteLine();
                        Console.Write("Ingrese una opcion: ");
                        opcion = Console.ReadLine();
                        switch(opcion)
                        {
                            case "1":
                                Console.WriteLine();
                                Console.Write("Ingrese el operador que desea: ");
                                operador = Console.ReadLine();
                                Console.WriteLine("El resultado de la operacion entre {0} y {1} es: {2}",
                                    numero1, numero2,Entidades.Calculadora.Operar(numero1, numero2, operador));
                                break;
                            case "2":
                                salir = "s";
                                break;
                        }
                    }
                }
                Console.ReadKey();
            } while (salir == "n");            
        }
    }
}
