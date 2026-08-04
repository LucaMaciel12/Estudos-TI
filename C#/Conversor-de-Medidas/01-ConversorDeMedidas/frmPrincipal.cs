using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_ConversorDeMedidas
{
    public partial class frmPrincipal : Form
    {
        double celsius, fahrenheit, centimetros, milimetros, polegadas, kg, libras;

        private void btnPeso_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txbKg.Text, out kg))
            {
                libras = kg * 2.2046;
                txbLibras.Text = libras.ToString();
            }
            else
            {
                MessageBox.Show("Digite apenas números", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbKg.Clear();
                txbKg.Focus();
            }
        }

        private void rdbPolegadas_CheckedChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txbCentimetros.Text, out centimetros))
            {
                polegadas = centimetros / 2.54;
                txbResultado.Text = polegadas.ToString();
            }
            else
            {
                MessageBox.Show("Digite apenas números", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbCentimetros.Clear();
                txbCentimetros.Focus();
            }
        }

        private void rdbMilimetros_CheckedChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txbCentimetros.Text, out centimetros))
            {
                milimetros = centimetros * 10;
                txbResultado.Text = milimetros.ToString();
            }
            else
            {
                MessageBox.Show("Digite apenas números", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbCentimetros.Clear();
                txbCentimetros.Focus();
            }
        }

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnTemperatura_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txbCelsius.Text, out celsius))
            {
                fahrenheit = (celsius * 9 / 5) + 32;
                txbFahrenheit.Text = fahrenheit.ToString();
            }
            else
            {
                MessageBox.Show("Digite apenas números", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbCelsius.Clear();
                txbCelsius.Focus();
            }
        }
    }
}
