using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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


        //public void ToXML(string ruta = null)
        //{
        //    if (ruta == null) ruta = this.nombre + ".xml";

        //    XmlSerializer serial = new XmlSerializer(this.GetType());
        //    TextWriter escritor = new StreamWriter(ruta);

        //    serial.Serialize(escritor, this);
        //    escritor.Close();
        //}

    }
}
