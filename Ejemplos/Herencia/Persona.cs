using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos
{
    public enum Sexo
    {
        Hombre,
        Mujer
    }

    public enum NivelConocimientos
    {
        Ninguno,
        Alguno,
        Todo
    }
}

namespace Ejemplos.Herencia
{


    public class Persona
    {
        protected string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        protected DateTime fechaNacimiento;
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public Ejemplos.Sexo Sexo { get; set; }

        private Dictionary<string,NivelConocimientos> conocimientos = new Dictionary<string, NivelConocimientos>();

        public Dictionary<string,NivelConocimientos> Conocimientos
        {
            get { return conocimientos; }
        }


    }
}
