using _09_CadastroPessoas.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09_CadastroPessoas
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (verificaDados())
            {
                try
                {
                    string senhaCrypto = Crypto.sha256encrypt(txbSenha.Text);
                    senhaCrypto = senhaCrypto.ToLower();
                    Usuario.realizarLogin(txbLogin.Text, senhaCrypto);
                    txbLogin.Clear();
                    txbSenha.Clear();
                    txbLogin.Focus();
                }
                catch (Exception erro)
                {

                    MessageBox.Show(erro.Message, "Aviso", MessageBoxButtons.OK, 
                          MessageBoxIcon.Error);
                }
            }
        }

        private bool verificaDados()
        {
            if(txbLogin.Text == string.Empty)
            {
                MessageBox.Show("Digite o login", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbLogin.Focus();
                return false;
            }
            if (txbSenha.Text == string.Empty)
            {
                MessageBox.Show("Digite a senha", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbSenha.Focus();
                return false;
            }
            return true;
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja fechar o programa?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(Pergunta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
