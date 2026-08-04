using SisVendas.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisVendas
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                try
                {
                    string senha = Crypto.sha256encrypt(txbSenha.Text);
                    senha = senha.ToLower();
                    Usuario.realizarLogin(txbLogin.Text, senha);
                    txbLogin.Clear();
                    txbSenha.Clear();
                    txbLogin.Focus();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "Aviso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                }
            }
        }


        private Boolean verificaCampos()
        {
            if (txbLogin.Text == "")
            {
                MessageBox.Show("Digite o login", "AViso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbLogin.Focus();
                return false;
            }
            if (txbSenha.Text == "")
            {
                MessageBox.Show("Digite a senha", "AViso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbSenha.Focus();
                return false;
            }
            return true;
        }
    }
}
