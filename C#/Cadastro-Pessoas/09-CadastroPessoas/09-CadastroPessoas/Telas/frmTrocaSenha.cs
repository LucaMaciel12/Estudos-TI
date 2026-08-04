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

namespace _09_CadastroPessoas.Telas
{
    public partial class frmTrocaSenha : Form
    {
        Usuario usuarioLogado = new Usuario();
        public frmTrocaSenha(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }

        private void toolAlterar_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                // Criptografar a senha
                string senhaCrypto = Crypto.sha256encrypt(txbSenhaAtual.Text);
                // Transformar para minúsculas
                senhaCrypto = senhaCrypto.ToLower();

                // Comparar com a senha do Banco de Dados
                if (senhaCrypto == usuarioLogado.Senha)
                {
                    // Criptografar a nova senha
                    string novaSenha = Crypto.sha256encrypt(txbSenha.Text);
                    // Transformar em minúsculas
                    novaSenha = novaSenha.ToLower();

                    // Obter a senha do usuário logado
                    int id = usuarioLogado.Id_usu;

                    // Alterar os dados no Banco de dados
                    Usuario alteraSenha = new Usuario(id, novaSenha, txbFrase.Text);
                    alteraSenha.alteraSenha();
                    MessageBox.Show("Senha alterada! \nFaça o login novamente",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("A senha atual não confere!", "Aviso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }


        private bool verificaCampos()
        {
            if (txbSenhaAtual.Text == string.Empty)
            {
                MessageBox.Show("Digite a senha atual", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbSenhaAtual.Focus();
                return false;
            }
            if (txbSenha.Text == string.Empty)
            {
                MessageBox.Show("Digite a nova senha", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbSenha.Focus();
                return false;
            }
            if (txbRepitaSenha.Text == string.Empty)
            {
                MessageBox.Show("Repita a nova senha", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbRepitaSenha.Focus();
                return false;
            }
            if (txbSenha.Text != txbRepitaSenha.Text)
            {
                MessageBox.Show("As senhas não conferem", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbSenha.Clear();
                txbRepitaSenha.Clear();
                txbSenha.Focus();
                return false;
            }
            if (txbFrase.Text == string.Empty)
            {
                MessageBox.Show("Digite a frase de segurança", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbFrase.Focus();
                return false;
            }
            return true;
        }
    }
}
