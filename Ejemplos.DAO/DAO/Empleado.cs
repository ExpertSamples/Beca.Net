using Ejemplos.DAO.DataSets;
using Ejemplos.DAO.DataSets.EmpleadosTableAdapters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplos.DAO
{
    public class Empleado
    {
        public Empleado()
        {

        }

        public Empleados GetEmpleadosAll()
        {
            Empleados empleados = new Empleados();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AdWorks"].ConnectionString))
            {
                conn.Open();
                SqlCommand comando = conn.CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "select p.* from Person.Person  as p inner join HumanResources.Employee as e on p.BusinessEntityID = e.BusinessEntityID;";
                SqlDataAdapter personAdapter = new SqlDataAdapter(comando);

                personAdapter.Fill(empleados.Person);

                comando = conn.CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "select * from HumanResources.Employee;";
                SqlDataAdapter employeeAdapter = new SqlDataAdapter(comando);

                employeeAdapter.Fill(empleados.Employee);
                conn.Close();
            }



            return empleados;
        }
    }
}
