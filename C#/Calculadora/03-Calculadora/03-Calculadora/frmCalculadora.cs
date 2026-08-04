using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_Calculadora
{
    public partial class frmCalculadora : Form
    {
        double a, b;
        string c;

        public frmCalculadora()
        {
            InitializeComponent();
        }


        private void frmCalculadora_Load(object sender, EventArgs e)
        {
            status.Text = "Fábio Corrêa";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "1";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "1";
            }
            btnCalcular.Focus();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "2";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "2";
            }
            btnCalcular.Focus();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "3";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "3";
            }
            btnCalcular.Focus();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "4";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "4";
            }
            btnCalcular.Focus();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "5";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "5";
            }
            btnCalcular.Focus();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "6";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "6";
            }
            btnCalcular.Focus();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "7";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "7";
            }
            btnCalcular.Focus();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "8";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "8";
            }
            btnCalcular.Focus();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "9";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "9";
            }
            btnCalcular.Focus();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "0";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "0";
            }
            btnCalcular.Focus();
        }

        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text.Contains(',') == false)
            {
                txbEntrada.Text = txbEntrada.Text + ",";
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            a = 0;
            b = 0;
            c = "";
            txbEntrada.Text = string.Empty;
        }

        private void btndividir_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(txbEntrada.Text);
            c = "/";
            txbEntrada.Clear();
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(txbEntrada.Text);
            c = "*";
            txbEntrada.Clear();
        }

        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(txbEntrada.Text);
            c = "-";
            txbEntrada.Clear();
        }

        private void btnSomar_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(txbEntrada.Text);
            c = "+";
            txbEntrada.Clear();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text != string.Empty)
            {
                b = Convert.ToDouble(txbEntrada.Text);
                switch (c)
                {
                    case "+":
                        txbEntrada.Text = Convert.ToString(a + b);
                        break;

                    case "-":
                        txbEntrada.Text = Convert.ToString(a - b);
                        break;

                    case "*":
                        txbEntrada.Text = Convert.ToString(a * b);
                        break;

                    case "/":
                        txbEntrada.Text = Convert.ToString(a / b);
                        break;
                }
            }
        }

        private void frmCalculadora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
            {
                btn1.PerformClick();
            }
            if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            {
                btn2.PerformClick();
            }
            if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
            {
                btn3.PerformClick();
            }
            if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
            {
                btn4.PerformClick();
            }
            if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
            {
                btn5.PerformClick();
            }
            if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
            {
                btn6.PerformClick();
            }
            if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
            {
                btn7.PerformClick();
            }
            if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
            {
                btn8.PerformClick();
            }
            if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
            {
                btn9.PerformClick();
            }
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
            {
                btn0.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnLimpar.PerformClick();
            }
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus && e.Shift)
            {
                btnSomar.PerformClick();
            }
            if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                btnSubtrair.PerformClick();
            }
            if (e.KeyCode == Keys.Multiply)
            {
                btnMultiplicar.PerformClick();
            }
            if (e.KeyCode == Keys.Divide)
            {
                btnDividir.PerformClick();
            }
            if (e.KeyCode == Keys.Back)
            {
                btnApagar.PerformClick();
            }
            if (e.KeyValue == 188)
            {
                btnVirgula.PerformClick();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            relogio.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text.Length > 0)
            {
                txbEntrada.Text = txbEntrada.Text.Remove(txbEntrada.Text.Length - 1, 1);
            }
        }
    }
}
