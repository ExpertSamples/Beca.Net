using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplos.Ficheros
{
    public partial class Form1 : Form
    {

        List<Jugador> jugadores = new List<Jugador>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jugador jugador;

            string path = @"d:\trabajo\master.csv";

            LectorCsv lector = new LectorCsv(path, ',');
            lector.ProcesaFichero();

            for (int i = 0; i < lector.Count; i++)
            {
                jugador = new Jugador();

                jugador.FromLineaCsv(i, lector);

                jugadores.Add(jugador);
            }

            DateTime fechaLimite = new DateTime(1970, 01, 01);

            //var filtro = jugadores.Where(j => j.Bateador == Destreza.Diestro && j.FechaNacimiento > fechaLimite);

            var filtro = from j in jugadores
                         where j.Bateador == Destreza.Diestro
                            && j.FechaNacimiento > fechaLimite
                         select new { j.Nombre, j.FechaNacimiento };

            

            listBox1.DataSource = filtro.ToList();

        }


    }
}
