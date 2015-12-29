using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos
{
    public class MotorExpresiones
    {
        const string operadores = "+,-";

        Stack<String> pila = new Stack<string>();

        private string expresion;
        public string Expresion
        {
            get { return expresion; }
            //set { expresion = value; }
        }


        public MotorExpresiones()
        {

        }

        public MotorExpresiones(String expresion)
        {
            this.expresion = expresion;
        }


        public int RealizaCalculo()
        {
            int resultado = 0;
            string elemento;
            List<int> operandos = new List<int>();

            RellenaPila();

            while (pila.Count > 1)
            {
                elemento = pila.Pop();

                if (IsOperador(elemento))
                {
                    pila.Push(RealizaOperacion(operandos, elemento).ToString());
                }
                else
                {
                    operandos.Add(int.Parse(elemento));
                }

            }

            if (pila.Count == 1)
            {
                resultado = int.Parse(pila.Pop());
            }
            else
            {
                throw new Exception("Parece que no hay resultado");
            }

            return resultado;
        }

        private void RellenaPila()
        {
            String[] miembros = expresion.Split(',');

            foreach (String miembro in miembros)
            {
                pila.Push(miembro);
            }

        }

        private bool IsOperador(string miembro)
        {
            if (miembro.Length != 1) return false;

            return operadores.Contains(miembro);
        }

        private int RealizaOperacion(List<int> operandos, string operacion)
        {
            int resultado = 0;

            if (operandos.Count != 2) throw new ExpresionMalFormadaException();

            switch (operacion)
            {
                case "+":
                    resultado = operandos[0] + operandos[1];
                    break;
                case "-":
                    resultado = operandos[0] - operandos[1];
                    break;
                default:
                    throw new ExpresionMalFormadaException();
                    break;
            }


            return resultado;
        }

    }

    public class ExpresionMalFormadaException : Exception
    {
        public ExpresionMalFormadaException(): base()
        {

        }


    }
}
