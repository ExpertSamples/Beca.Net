using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Calculadora
    {

        float? operando1;
        internal float Operando1
        {
            get
            {
                if (operando1 == null) return 0;
                return (float)operando1;
            }
        }

        float? operando2;
        internal float Operando2
        {
            get
            {
                if (operando2 == null) return 0;
                return (float)operando2;
            }
        }

        string operacion;
        internal string Operacion
        {
            get { return operacion; }
        }

        public Calculadora()
        {

        }

        public Calculadora(float operando1, float operando2, string operacion)
        {
            this.operando1 = operando1;
            this.operando2 = operando2;
            this.operacion = operacion;
        }

        internal void AñadeTermino(float operando)
        {
            if (String.IsNullOrWhiteSpace(operacion) || this.operando1 == null)
            {
                this.operando1 = operando;
                this.operando2 = null;
            }
            else if (this.operando2 == null)
            {
                this.operando2 = operando;
            }
        }

        internal void AñadeTermino(String operacion)
        {
            this.operando2 = null;
            this.operacion = operacion;
        }

        internal float RealizaOperacion()
        {
            if (operando1 == null || !operando2.HasValue || String.IsNullOrWhiteSpace(operacion))
            {
                //TODO devolver error
            }

            if (operacion == "+")
            {
                return operando1.Value + operando2.Value;
            }

            if (operacion == "-")
            {
                return operando1.Value - operando2.Value;
            }

            if (operacion == "*")
            {
                return operando1.Value * operando2.Value;
            }

            if (operacion == "/")
            {
                return operando1.Value / operando2.Value;
            }

            //TODO devolver error
            return 0;
        }
    }
}
