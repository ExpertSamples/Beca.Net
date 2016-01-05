using Ejemplos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejemplos.DelegadoTest;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salida = false;
            while (!salida)
            {
                string expresion = Console.ReadLine();

                string[] elementos = expresion.Split(' ');
                expresion = elementos[0];

                switch (expresion)
                {
                    case "s":
                        int numero = elementos[1].ToInt();
                        int hasta = elementos[2].ToInt();

                        Console.WriteLine(numero.To(hasta).Sum());
                        break;
                    case "libros":
                        TestBookDB.Main2();
                        break;
                    case "q":
                    case "quit":
                        salida = true;
                        break;
                    default:
                        MotorExpresiones motor = new MotorExpresiones(expresion);

                        Console.WriteLine(motor.RealizaCalculo());

                        break;
                }
            }

        }
    }
}
