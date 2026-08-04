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

namespace SisVendas.Telas
{
    public partial class FrmAlteraSenha : Form
    {
        Usuario usuarioLogado = new Usuario();
        public FrmAlteraSenha(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }

        private void FrmAlteraSenha_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = "Olá " + usuarioLogado.Nome;
        }

        private void toolStripAlterar_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                string senhaAtual = Crypto.sha256encrypt(txbSenhaAtual.Text);
                senhaAtual = senhaAtual.ToLower();

                string senhaNova = Crypto.sha256encrypt(txbSenha.Text);
                senhaNova = senhaNova.ToLower();

                if (senhaAtual == usuarioLogado.Senha)
                {
                    Usuario trocaSenha = new Usuario(usuarioLogado.Id_usuario,
                        senhaNova, txbFrase.Text);
                    trocaSenha.alteraSenhaUsuario();
                    MessageBox.Show("Senha alterada", "Aviso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("A senha atual não confere", "Aviso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);    
                }
            }
        }


        private bool verificaCampos()
        {
            if (txbSenhaAtual.Text == string.Empty)
            {
                MessageBox.Show("Preencha a senha atual", 
                    "Aviso", MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                txbSenhaAtual.Focus();
                return false;
            }
            if (txbSenha.Text == string.Empty)
            {
                MessageBox.Show("Preencha a nova senha",
                    "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txbSenha.Focus();
                return false;
            }
            if (txbRepitaSenha.Text == string.Empty)
            {
                MessageBox.Show("Repita a nova senha",
                    "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txbRepitaSenha.Focus();
                return false;
            }
            if (txbSenha.Text != txbRepitaSenha.Text)
            {
                MessageBox.Show("As senhas não conferem",
                    "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txbSenha.Clear();
                txbRepitaSenha.Clear();
                txbSenha.Focus();
                return false;
            }
            if (txbFrase.Text == string.Empty)
            {
                MessageBox.Show("Preencha a frase de segurança",
                    "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txbFrase.Focus();
                return false;
            }
            return true;
        }
    }
}
