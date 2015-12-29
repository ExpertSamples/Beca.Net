using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ejemplos.Herencia;

namespace Ejemplos
{
    public enum MiEnum
    {
        Valor1,
        Valor2,
        Valor3
    }


    public partial class Form1 : Form
    {
        protected List<Persona> personas;

        protected Persona personaActual;

        public Form1()
        {
            InitializeComponent();

        }

        private void RellenaPadres()
        {
            

            Padre padre;
            Padre conyuge;
            Hijo hijo;
            //if (sender.GetType() == typeof(Button))
            padre = new Padre(true);
            padre.Nombre = "Macarena";
            padre.FechaNacimiento = new DateTime(1980, 01, 01);
            padre.Sexo = Sexo.Mujer;
            padre.Conocimientos.Add("Mandar", NivelConocimientos.Todo);

            conyuge = new Padre();
            conyuge.Nombre = "Juan";
            conyuge.FechaNacimiento = new DateTime(1979, 02, 19);
            conyuge.Conyuge = padre;

            padre.Conyuge = conyuge;

            hijo = new Hijo() { FechaNacimiento = new DateTime(2010, 3, 24), Nombre = "Juan", Madre = padre };

            padre.Hijos.Add(hijo);

            personas = new List<Persona>();
            personas.Add(padre);
            personas.Add(conyuge);
            personas.Add(hijo);

            padre = new Padre(true) {FechaNacimiento=new DateTime(1975,05,13),Nombre="Desiree" };
            conyuge = new Padre() { Nombre = "Jose", FechaNacimiento = new DateTime(1975, 08, 4), Conyuge = padre };
            padre.Conyuge = conyuge;
            hijo = new Hijo() { Nombre = "Pepe", FechaNacimiento = new DateTime(2006, 9, 18), Madre = padre };
            padre.Hijos.Add(hijo);
            hijo = new Hijo() { Nombre = "Julio", FechaNacimiento = new DateTime(2009, 4, 15), Madre = padre };
            padre.Hijos.Add(hijo);

            personas.Add(padre);
            personas.Add(conyuge);
            personas.Add(padre.Hijos[0]);
            personas.Add(padre.Hijos[1]);
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            RellenaPadres();

            listBox1.DataSource = personas;
            listBox1.DisplayMember = "Nombre";

            string[] nombres = Enum.GetNames(typeof(NivelConocimientos));

            for (int i = 0; i < nombres.Length; i++)
            {
                comboBox1.Items.Add(nombres[i]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            personaActual = (Persona)((ListBox)sender).SelectedItem;
            MuestraConocimientos();
        }

        protected void MuestraConocimientos()
        {
            listBox2.Items.Clear();

            if (personaActual != null)
            {
                string materia = null;

                foreach (String clave in personaActual.Conocimientos.Keys)
                {
                    materia = clave + "-";
                    NivelConocimientos nivel;
                    if (personaActual.Conocimientos.TryGetValue(clave,out nivel))
                    {
                        materia += nivel.ToString();
                    }
                    else
                    {
                        materia += "???";
                    }

                    listBox2.Items.Add(materia);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (personaActual != null)
            {
                if (!String.IsNullOrWhiteSpace(textBox1.Text))
                {
                    try
                    {
                        personaActual.Conocimientos.Add(textBox1.Text, (NivelConocimientos)Enum.Parse(typeof(NivelConocimientos), comboBox1.Text));
                    }
                    catch (ArgumentException ex)
                    {
                        
                        MessageBox.Show("Ya tiene el conocimiento");
                    }
                }

                MuestraConocimientos();
            }
        }
    }
}
