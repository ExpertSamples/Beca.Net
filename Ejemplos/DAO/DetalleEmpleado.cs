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
    public partial class DetalleEmpleado : Form
    {
        private const string SIN_VALOR = "Sin definir";

        public Ejemplos.DAO.DataSets.Empleados.PersonRow Persona { get; set; }
        public Ejemplos.DAO.DataSets.Empleados.EmployeeRow Empleado { get; set; }

        private bool modificando = false;

        public DetalleEmpleado()
        {
            InitializeComponent();
        }

        private void DetalleEmpleado_Load(object sender, EventArgs e)
        {
            if (Persona != null && Empleado != null)
            {
                modificando = true;
                CargaDatos();
            }
        }

        private void CargaDatos()
        {
            txtFirstName.Text = Persona.FirstName;
            try
            {
                txtMiddleName.Text = Persona.MiddleName;
            }
            catch(StrongTypingException ex)
            {
                txtMiddleName.Text = SIN_VALOR;
            }
            txtLastName.Text = Persona.LastName;

            dtpFechaContratacion.Value = Empleado.HireDate;


        }
    }
}
