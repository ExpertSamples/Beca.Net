using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ejemplos.Ficheros;

namespace Ejemplos.Linq
{
    public partial class frmEquipos : Form
    {
        List<Jugador> jugadores = new List<Jugador>();
        List<Equipo> equipos = new List<Equipo>();
        List<Aparicion> apariciones = new List<Aparicion>();
        List<Salario> salarios = new List<Salario>();

        public frmEquipos()
        {
            InitializeComponent();
        }

        private void frmEquipos_Load(object sender, EventArgs e)
        {

            string dir = @"D:\Trabajo\lahman-csv_2015-01-24\";

            LectorCsv lector = new LectorCsv(dir + "Master.csv", ',');
            lector.ProcesaFichero();
            for (int i = 0; i < lector.Count; i++)
            {
                jugadores.Add((new Jugador()).FromLineaCsv(i, lector));
            }

            lector = new LectorCsv(dir + "Teams.csv", ',');
            lector.ProcesaFichero();
            for (int i = 0; i < lector.Count; i++)
            {
                equipos.Add((new Equipo()).FromLineaCsv(i, lector));
            }

            lector = new LectorCsv(dir + "Appearances.csv", ',');
            lector.ProcesaFichero();
            for (int i = 0; i < lector.Count; i++)
            {
                apariciones.Add((new Aparicion()).FromLineaCsv(i, lector));
            }

            lector = new LectorCsv(dir + "Salaries.csv", ',');
            lector.ProcesaFichero();
            for (int i = 0; i < lector.Count; i++)
            {
                salarios.Add((new Salario()).FromLineaCsv(i, lector));
            }

            txtAños.Minimum = (from eq in equipos
                               select eq.Año).Min();

            

            txtAños.Minimum = (decimal)equipos.Select<Equipo, int>(eq => eq.Año).Min();
            txtAños.Maximum = (decimal)equipos.Select<Equipo, int>(eq => eq.Año).Max();
            txtAños.Value = txtAños.Maximum;

        }

        private void txtAños_ValueChanged(object sender, EventArgs e)
        {

            List<Equipo> equiposAño = equipos.Where(eq => eq.Año == (int)txtAños.Value).OrderBy(eq => eq.Nombre).ToList();

            equiposAño = (from eq in equipos
                         where eq.Año == (int)txtAños.Value
                         orderby eq.Nombre
                         select eq).ToList();

            lstEquipos.DataSource = equiposAño;
        }

        private void lstEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstJugadores.DataSource = null;

            if (lstEquipos.SelectedIndex > -1)
            {
                string idEquipo = ((Equipo)lstEquipos.SelectedItem).Id;

                lstJugadores.DataSource = (from a in apariciones
                                          join j in jugadores on a.IdJugador equals j.Id
                                          where a.Año == (int)txtAños.Value && a.IdEquipo == idEquipo
                                          select j).ToList();

                lstJugadores.DisplayMember = "Apodo";
            }
        }

        private void lstJugadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstJugadores.SelectedIndex > -1)
            {
                MuestraJugador((Jugador)lstJugadores.SelectedItem);
            }
        }

        private void MuestraJugador(Jugador jugador)
        {
            txtId.Text = jugador.Id;
            txtNombre.Text = jugador.Nombre + " " + jugador.Apellido;
            txtAltura.Text = jugador.Altura.ToString();

            Salario salario = salarios.FirstOrDefault(s => s.Año == (int)txtAños.Value && s.IdJugador == jugador.Id && s.IdEquipo == ((Equipo)lstEquipos.SelectedItem).Id);


            txtSalario.Clear();
            if (salario != null)
            {
                txtSalario.Text = salario.Cantidad.ToString();
            }
            
        }
    }
}
