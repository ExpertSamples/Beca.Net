using Ejemplos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejemplos.DelegadoTest;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salida = false;
            while (!salida)
            {
                string expresion = Console.ReadLine();

                string[] elementos = expresion.Split(' ');
                expresion = elementos[0];

                switch (expresion)
                {
                    case "ad":
                        
                        
                        

                        break;
                    case "bd":

                        String conexion = ConfigurationManager.ConnectionStrings["AdWorks"].ConnectionString;

                        String tipoTelefono = (elementos.Length > 1) ? elementos[1] : null;
                        List<String> listaNombres = new List<string>();
                        vEmpleado datos = new vEmpleado();

                        

                        using (SqlConnection connection = new SqlConnection(conexion))
                        {
                            SqlCommand command = connection.CreateCommand();
                            command.CommandType = CommandType.Text;


                            command.CommandText = "select * from HumanResources.vEmployee where 1=1";
                            
                            if (!String.IsNullOrWhiteSpace(tipoTelefono))
                            {
                                command.CommandText += " and PhoneNumberType = @TipoTelefono";
                                command.Parameters.AddWithValue("TipoTelefono", tipoTelefono);
                            }

                            connection.Open();
                            //SqlDataReader reader = command.ExecuteReader();

                            //while (reader.Read())
                            //{
                            //    var fila = datos.vEmployee.NewvEmployeeRow();
                            //    fila.FirstName = reader["FirstName"].ToString();

                            //    datos.vEmployee.Rows.Add(fila);
                            //}

                            SqlDataAdapter adapter = new SqlDataAdapter(command);

                            adapter.Fill(datos, "vEmployee");



                            //reader.Close();
                            connection.Close();
                        }

                        foreach (vEmpleado.vEmployeeRow fila in datos.vEmployee.Rows)
                        {
                            
                            Console.WriteLine(fila["FirstName"]);
                        }

                        break;
                    case "s":
                        int numero = elementos[1].ToInt();
                        int hasta = elementos[2].ToInt();

                        Console.WriteLine(numero.To(hasta).Sum());
                        break;
                    case "libros":
                        TestBookDB.Main2();
                        break;
                    case "q":
                    case "quit":
                        salida = true;
                        break;
                    default:
                        MotorExpresiones motor = new MotorExpresiones(expresion);

                        Console.WriteLine(motor.RealizaCalculo());

                        break;
                }
            }

        }
    }
}
