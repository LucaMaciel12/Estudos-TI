using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_GeradorDeSenhas
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            // Preenche o comprimento padrão
            txbComprimento.Text = "7";

            // Ativa os campos padrões
            chkMinusculas.Checked = true;
            chkMaiusculas.Checked = true;
            chkNumeros.Checked = true;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Resetar todos os campos
            txbComprimento.Text = "7";
            chkMinusculas.Checked = true;
            chkMaiusculas.Checked = true;
            chkNumeros.Checked = true;
            chkSimbolos.Checked = false;
            txbSenha.Clear();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            if (chkMinusculas.Checked != true &&
                chkMaiusculas.Checked != true &&
                chkNumeros.Checked != true && 
                chkSimbolos.Checked != true || 
                txbComprimento.Text == "")
            {
                MessageBox.Show("ATENÇÃO!!! \nO comprimento deve ter de 7 a 20 caracteres", 
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Convert.ToInt32(txbComprimento.Text) < 7 || 
                    Convert.ToInt32(txbComprimento.Text) > 20)
                {
                    MessageBox.Show("ATENÇÃO!!! \nO comprimento deve ter de 7 a 20 caracteres",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int comprimento = Convert.ToInt32(txbComprimento.Text);
                    string caracteres = "";

                    if (chkMinusculas.Checked)
                        caracteres += "abcdefghijklmnopqrstuvwxyz";

                    if (chkMaiusculas.Checked)
                        caracteres += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                    if (chkNumeros.Checked)
                        caracteres += "0123456789";

                    if (chkSimbolos.Checked)
                        caracteres += "!@#$%";

                    // StringBuilder é uma classe da biblioteca System.Text
                    StringBuilder senha = new StringBuilder();

                    Random random = new Random();

                    for (int i = 0; i < comprimento; i++) 
                    {
                        int index = random.Next(caracteres.Length);
                        senha.Append(caracteres[index]);
                    }

                    txbSenha.Text = senha.ToString();
                }
            }
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txbSenha.Text);
            MessageBox.Show("Senha copiada para a Área de transferência",
                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
