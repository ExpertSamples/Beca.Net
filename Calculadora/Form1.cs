using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class frmCalculadora : Form
    {
        Calculadora calculadora;

        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void Numero_Click(object sender, EventArgs e)
        {

            if (sender.GetType() == typeof(Button))
            {
                Button boton = (Button)sender;

                txtPantalla.Text = txtPantalla.Text + boton.Text;
            }


        }


        private void Clear_Click(object sender, EventArgs e)
        {
            this.calculadora = null;
            txtPantalla.Text = "";
        }

        private void Operacion_Click(object sender, EventArgs e)
        {
            float numero;
            if (!float.TryParse(txtPantalla.Text, out numero))
            {
                //TODO devolver error
                return;
            }

            if (sender.GetType() == typeof(Button))
            {
                Button boton = (Button)sender;

                calculadora = new Calculadora();

                calculadora.AñadeTermino(numero);
                calculadora.AñadeTermino(boton.Text);

                txtPantalla.Text = "";
            }
        }

        private void Igual_Click(object sender, EventArgs e)
        {
            float numero;
            if (!float.TryParse(txtPantalla.Text, out numero))
            {
                //TODO devolver error
                return;
            }

            if (calculadora != null)
            {
                calculadora.AñadeTermino(numero);
                txtPantalla.Text = calculadora.RealizaOperacion().ToString();
            }
        }
    }
}
