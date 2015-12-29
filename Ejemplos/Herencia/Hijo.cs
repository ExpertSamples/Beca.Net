using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.Herencia
{
    public class Hijo:Persona
    {
        protected Padre madre;
        public Padre Madre
        {
            get { return madre; }
            set { madre = value; }
        }


    }
}
