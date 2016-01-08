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
        public static string SIN_VALOR = "Sin definir";

        private string cadenaConexion = ConfigurationManager.ConnectionStrings["AdWorks"].ConnectionString;

        public Empleado()
        {

        }

        public Empleados GetEmpleadosAll()
        {
            Empleados empleados = new Empleados();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
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

        public void Update(Ejemplos.DAO.DataSets.Empleados.PersonRow persona, Ejemplos.DAO.DataSets.Empleados.EmployeeRow empleado)
        {
            string sql;

            sql = "update Person.Person set";
            sql += " FirstName ='" + persona.FirstName+"'";
            if (persona.MiddleName != Empleado.SIN_VALOR)
            {
                sql += " ,MiddleName ='" + persona.MiddleName+"'";
            }
            else
            {
                sql += " ,MiddleName = NULL";
            }
            sql += " ,LastName ='" + persona.LastName+"'";
            sql += " where BusinessEntityID=" + persona.BusinessEntityID.ToString()+";";

            sql += "update HumanResources.Employee set";
            sql += " hiredate='" + empleado.HireDate.ToString("yyyyMMdd")+"'";
            sql += " where BusinessEntityID=" + empleado.BusinessEntityID.ToString() + ";";

            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlTransaction transaccion = conexion.BeginTransaction();

                SqlCommand comando = conexion.CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;

                conexion.Open();
                try
                {
                    comando.ExecuteNonQuery();
                    transaccion.Commit();
                }
                catch(Exception ex)
                {
                    transaccion.Rollback();
                }


      

                conexion.Close();
            }

        }
    }
}
