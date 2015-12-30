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
            String linea;
            Jugador jugador;
            string path = @"d:\trabajo\master.csv";

            StreamReader fichero = File.OpenText(path);

            

            fichero.ReadLine();

            linea = fichero.ReadLine();
            while (linea != null)
            {

                jugador = new Jugador();

                jugador.FromString(linea);
                jugadores.Add(jugador);

                linea = fichero.ReadLine();
            }

            fichero.Close();

            listBox1.DataSource = jugadores;
            
        }


    }
}
