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
        }
    }
}
