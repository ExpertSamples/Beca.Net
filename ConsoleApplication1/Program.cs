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

                switch (expresion)
                {
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
