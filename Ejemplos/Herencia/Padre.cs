using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ejemplos.Herencia
{
    [Serializable]
    public class Padre: Persona
    {
        //Cambio tipo, quito ctor, propiedad en el indexador, Propiedad Alfa.

        public bool IsAlpha
        {
            get
            {
                return this.hijos != null;
            }
        }

        protected Padre conyuge;
        public Padre Conyuge
        {
            get { return conyuge; }
            set
            {
                conyuge = value;
                //if (conyuge != null) this.nombreConyuge = conyuge.Nombre;
            }
        }




        protected List<Hijo> hijos;
        
        public List<Hijo> Hijos
        {
            get { return hijos; }
        }

        public Padre()
        {

        }

        public Padre(bool isAlpha = false)
        {
            if (isAlpha) this.hijos = new List<Hijo>();
        }


        public Hijo this[int numHijo]
        {
            get
            {
                try
                {
                    return this.hijos[numHijo];
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return null;

            }
        }

        public Hijo this[string nombre]
        {
            get
            {
                for(int i = 0; i < hijos.Count; i++)
                {
                    if (hijos[i].Nombre == nombre) return hijos[i];
                }

                return null;
            }
        }
    }
}
