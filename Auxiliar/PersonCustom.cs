using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos
{
    partial class Person
    {

        public String FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}
