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
                txtMiddleName.Text = DAO.Empleado.SIN_VALOR;
            }
            txtLastName.Text = Persona.LastName;

            dtpFechaContratacion.Value = Empleado.HireDate;


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            List<string> msg = new List<string>();

            if (modificando)
            {
                if (String.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    msg.Add("First Name");
                }
                if (String.IsNullOrWhiteSpace(txtMiddleName.Text))
                {
                    msg.Add("Middle Name");
                }
                if (String.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    msg.Add("Last Name");
                }

                if (msg.Count > 0)
                {
                    StringBuilder str = new StringBuilder();
                    str.AppendLine("Debe rellenar los siguientes campos:");

                    foreach (string campo in msg)
                    {
                        str.AppendLine(campo);
                    }

                    MessageBox.Show(str.ToString());

                    return;
                }

                Persona.FirstName = txtFirstName.Text;
                Persona.MiddleName = txtMiddleName.Text;
                Persona.LastName = txtLastName.Text;

                Empleado.HireDate = dtpFechaContratacion.Value;

                Empleado empleado = new DAO.Empleado();

                try
                {
                    empleado.Update(Persona, Empleado);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fallo en la actualización del empleado en bbdd.");
                }

                this.Close();
            }
        }
    }
}
