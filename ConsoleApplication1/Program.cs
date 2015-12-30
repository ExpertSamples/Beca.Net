using Ejemplos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                switch (expresion)
                {
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
