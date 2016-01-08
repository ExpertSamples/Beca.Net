using Ejemplos.DAO.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplos.DAO
{
    public partial class BusquedaEmpleados : Form
    {
        Empleados empleados;


        public BusquedaEmpleados()
        {
            InitializeComponent();
        }

        private void BusquedaEmpleados_Load(object sender, EventArgs e)
        {

            GetAll();

        }

        private void GetAll()
        {
            Empleado empleado = new Empleado();

            empleados = empleado.GetEmpleadosAll();

            lstEmpleados.DataSource = empleados.Person.ToList<Ejemplos.DAO.DataSets.Empleados.PersonRow>();
            lstEmpleados.DisplayMember = "FullName";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DetalleEmpleado detalle = new DetalleEmpleado();

            Ejemplos.DAO.DataSets.Empleados.PersonRow persona = ((Ejemplos.DAO.DataSets.Empleados.PersonRow)lstEmpleados.SelectedItem);

            detalle.Persona = persona;
            detalle.Empleado = empleados.Employee.FirstOrDefault(em => em.BusinessEntityID == persona.BusinessEntityID);

            detalle.ShowDialog(this);

            GetAll();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EM.Empleado empleado = new EM.Empleado();

            lstEmpleados.DataSource = empleado.GetEmpleadosAll();
            lstEmpleados.DisplayMember = "FullName";


            //lstEmpleados.DataSource = ;
            //lstEmpleados.DisplayMember = "FullName";
            //using (AdventureWorks2014Entities contexto = new AdventureWorks2014Entities())
            //{
            //    contexto.Database.Log = Console.Write;

            //    var lista = from comercial in contexto.SalesPerson
            //                where comercial.Employee.HireDate > new DateTime(2000, 01, 01)
            //                select comercial;

            //    //var listb = from l in lista
            //    //        where l.Bonus > 100
            //    //        select l.Employee.Person.FirstName;


            //    var listc = lista.ToList();

            //    var lisd = from c in listc
            //               where c.Bonus > 100
            //               select c.Employee.Person.FirstName;

            //    int i = 0;
            //    foreach (SalesPerson comercial in listc)
            //    {
            //        i++;
            //        var liste = (from c in listc
            //                    where c.Bonus > i * 10
            //                    select c.Employee.Person.FirstName).FirstOrDefault();
            //    }

            //    lstEmpleados.DataSource = lista.ToList();
            //    lstEmpleados.DisplayMember = "BusinessEntityId";
            //}

        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            DetalleEmpleado detalle = new DetalleEmpleado();

            detalle.PersonaEF = (Person)lstEmpleados.SelectedItem;

            detalle.ShowDialog(this);

            EM.Empleado empleado = new EM.Empleado();

            lstEmpleados.DataSource = empleado.GetEmpleadosAll();
            lstEmpleados.DisplayMember = "FullName";
        }
    }
}
