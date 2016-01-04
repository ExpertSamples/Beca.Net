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

            for(int i = 0; i < lector.Count; i++)
            {
                jugador = new Jugador();

                jugador.FromLineaCsv(i, lector);

                jugadores.Add(jugador);
            }

           

            listBox1.DataSource = jugadores;
            
        }


    }
}
