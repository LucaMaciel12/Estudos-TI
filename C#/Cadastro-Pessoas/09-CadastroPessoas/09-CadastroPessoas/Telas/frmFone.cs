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
    public partial class frmFone : Form
    {
        string fone;
        int idFone;
        int idPessoa;
        int qtde;

        public frmFone(string foneAlterar, int idFoneAlterar, 
            int idPessoaAlterar, int qtdeAlterar)
        {
            InitializeComponent();
            fone = foneAlterar;
            idFone = idFoneAlterar;
            idPessoa = idPessoaAlterar;
            qtde = qtdeAlterar;
        }

        private void frmFone_Load(object sender, EventArgs e)
        {
            mskFone.Text = fone;
            if(qtde == 1)
            {
                toolExcluir.Enabled = false;
            }
        }

        private void toolLimpar_Click(object sender, EventArgs e)
        {
            toolLimpar.Visible = false;
            toolSalvar.Visible = true;
            toolAlterar.Enabled = false;
            toolExcluir.Enabled = false;
            mskFone.Clear();
            mskFone.Focus();
        }

        private void toolSalvar_Click(object sender, EventArgs e)
        {
            string fone = new string(mskFone.Text.Where(char.IsDigit).ToArray());
            // Verifica se o campo foi preenchido corretamente
            if(fone.Length != 11)
            {
                MessageBox.Show("Preencha o fone corretamente", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskFone.Focus();
            }
            else
            {
                Fone insere = new Fone(idPessoa, mskFone.Text);
                insere.insereFone(idPessoa);
                MessageBox.Show("Fone inserido", "AViso", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void toolAlterar_Click(object sender, EventArgs e)
        {
            string fone = new string(mskFone.Text.Where(char.IsDigit).ToArray());
            // Verifica se o campo foi preenchido corretamente
            if (fone.Length != 11)
            {
                MessageBox.Show("Preencha o fone corretamente", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskFone.Focus();
            }
            else
            {
                Fone altera = new Fone(idFone, mskFone.Text);
                altera.alteraFone();
                MessageBox.Show("Fone alterado", "AViso", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void toolExcluir_Click(object sender, EventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja apagar esse telefone?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(Pergunta == DialogResult.Yes)
            {
                Fone excluir = new Fone(idFone);
                excluir.excluiFone();
                MessageBox.Show("Fone excluído", "Aviso", MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                this.Close();
            }
        }
    }
}
