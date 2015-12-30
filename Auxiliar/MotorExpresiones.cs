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
            Stack<String> abaco = new Stack<string>();


            RellenaPila();

            while (pila.Count > 0)
            {
                elemento = pila.Pop();

                if (IsOperador(elemento))
                {
                    for (int i = 0; i < NumeroOperandos(elemento); i++)
                    {
                        operandos.Add(int.Parse(abaco.Pop()));
                    }
                    pila.Push(RealizaOperacion(operandos, elemento).ToString());

                    for (int j = 0; j < abaco.Count; j++)
                    {
                        pila.Push(abaco.Pop());
                    }

                }
                else
                {
                    abaco.Push(elemento);
                }
            }



            if (abaco.Count == 1)
            {
                resultado = int.Parse(abaco.Pop());
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

            for (int i = miembros.Length; i > 0; i--)
            {
                pila.Push(miembros[i - 1]);
            }

        }


        private int NumeroOperandos(string operador)
        {
            int numero = 2;

            switch (operador)
            {
                case "S":
                    numero = 1;
                    break;
                case "*":
                case "+":
                case "-":
                default:
                    break;
            }

            return numero;
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

            operandos.Clear();

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
