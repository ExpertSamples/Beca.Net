using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejemplos;

namespace Ejemplos.EM
{
    public class Empleado
    {
        public Empleado()
        {

        }

        public List<Person> GetEmpleadosAll()
        {
            List<Person> resultado = null;

            using (AdventureWorks2014Entities contexto = new AdventureWorks2014Entities())
            {
                //contexto.Database.Log = Console.Write;
                resultado = contexto.Person.Include("Employee").Where(p => p.Employee != null).ToList();

            }

            return resultado;
        }

        public void Update(Person persona)
        {
            using (AdventureWorks2014Entities contexto = new AdventureWorks2014Entities())
            {
                contexto.Database.Log = Console.Write;

                Person personaOld = contexto.Person.First(p => p.BusinessEntityID == persona.BusinessEntityID);

                personaOld.FirstName = persona.FirstName;
                personaOld.MiddleName = persona.MiddleName;
                personaOld.LastName = persona.LastName;
                personaOld.Employee.HireDate = persona.Employee.HireDate;

                contexto.SaveChanges();
            }
        }
    }
}
