using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.DAO.DataSets
{
    partial class Empleados
    {
        partial class PersonRow
        {
            public string FullName
            {
                get
                {
                    return this.FirstName + " " + this.LastName;
                }
            }
        }

    }
}
