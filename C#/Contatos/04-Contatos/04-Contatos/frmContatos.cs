using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_Contatos
{
    public partial class frmContatos : Form
    {
        public frmContatos()
        {
            InitializeComponent();
        }

        private List<Contato> contatos = new List<Contato>();

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (VerificaCampos())
            {
                // Instanciando o objeto
                Contato novo = new Contato();
                novo.Nome = txbNome.Text;
                novo.Email = txbEmail.Text;
                novo.Fone = txbFone.Text;

                // Gravar os dados no arquivo de texto
                using (StreamWriter gravar = new StreamWriter("contatos.txt", true))
                {
                    gravar.WriteLine($"{novo.Nome}, {novo.Email}, {novo.Fone}");
                }

                // Limpar a tela
                limpaTela();

                // Atualizar o listBox
                mostraContatos();
            }
        }


        private void limpaTela()
        {
            txbNome.Clear();
            txbEmail.Clear();
            txbFone.Clear();
            txbNome.Focus();
        }

        private bool VerificaCampos()
        {
            if (txbNome.Text == string.Empty)
            {
                MessageBox.Show("Digite o nome", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbNome.Focus();
                return false;
            }
            if (txbEmail.Text == string.Empty)
            {
                MessageBox.Show("Digite o email", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbEmail.Focus();
                return false;
            }
            if (txbFone.Text == string.Empty)
            {
                MessageBox.Show("Digite o fone", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbFone.Focus();
                return false;
            }

            return true;
        }

        private void frmContatos_Load(object sender, EventArgs e)
        {
            mostraContatos();
            btnAlterar.Enabled = false;
            btnRemover.Enabled = false;
        }

        private void LstContatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void mostraContatos()
        {
            // Limpar o listBox e o List
            lstContatos.Items.Clear();
            contatos.Clear();

            // Ler os dados do arquivo texto
            using (StreamReader carrega = new StreamReader("contatos.txt"))
            {
                string linha;
                while ((linha = carrega.ReadLine()) != null)
                {
                    string[] dados = linha.Split(',');
                    string nome = dados[0].Trim();
                    string email = dados[1].Trim();
                    string fone = dados[2].Trim();

                    lstContatos.Items.Add(nome);

                    // Criar um novo objeto 
                    Contato contato = new Contato();
                    contato.Nome = nome;
                    contato.Email = email;
                    contato.Fone = fone;
                    contatos.Add(contato);
                }
            }
        }

        private void lstContatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se um item está selecionado
            if (lstContatos.SelectedIndex >= 0 &&
                lstContatos.SelectedIndex < contatos.Count)
            {
                // Vincular o listBox com o List
                int indiceSelecionado = lstContatos.SelectedIndex;
                Contato contatoSelecionado = contatos[indiceSelecionado];

                // Preencher os textBox com os dados do contato
                txbNome.Text = contatoSelecionado.Nome;
                txbEmail.Text = contatoSelecionado.Email;
                txbFone.Text = contatoSelecionado.Fone;

                btnSalvar.Enabled = false;
                btnAlterar.Enabled = true;
                btnRemover.Enabled = true;
            }
            else
            {
                // Se nenhum contato estiver selecionado ou o índice
                // for inválido, limpar as caixas de texto
                txbNome.Clear();
                txbEmail.Clear();
                txbFone.Clear();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (VerificaCampos())
            {

                int indiceSelecionado = lstContatos.SelectedIndex;
                Contato contatoSelecionado = contatos[indiceSelecionado];

                // Atualizar os dados so contato selecionado
                contatoSelecionado.Nome = txbNome.Text;
                contatoSelecionado.Email = txbEmail.Text;
                contatoSelecionado.Fone = txbFone.Text;

                // Criar uma nova lista de contatos atualizada
                List<Contato> contatosAtualizados = new List<Contato>(contatos);

                // Atualizar o contato na nova lista
                contatosAtualizados[indiceSelecionado] = contatoSelecionado;

                // Atualizar o arquivo de texto
                using (StreamWriter atualizar = new StreamWriter("contatos.txt"))
                {
                    foreach (Contato contato in contatos)
                    {
                        atualizar.WriteLine($"{contato.Nome}, {contato.Email}, {contato.Fone}");
                    }
                }

                // Limpar a tela
                limpaTela();

                // Atualizar o list
                mostraContatos();



            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpaTela();
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnRemover.Enabled = false;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (lstContatos.SelectedIndex >= 0 &&
                lstContatos.SelectedIndex < contatos.Count)
            {
                int indiceSelecionado = lstContatos.SelectedIndex;
                Contato contatoSelecionado = contatos[indiceSelecionado];

                DialogResult Pergunta = MessageBox.Show("Deseja excluir este contato?",
                    "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Pergunta == DialogResult.Yes)
                {
                    // Remover o contato da lista
                    contatos.RemoveAt(indiceSelecionado);

                    // Atualizar o arquivo de texto
                    using (StreamWriter Apagar = new StreamWriter("contatos.txt"))
                    {
                        foreach (Contato contato in contatos)
                        {
                            Apagar.WriteLine($"{contato.Nome}, {contato.Email}, {contato.Fone}");
                        }
                    }

                    // Limpar a tela
                    limpaTela();

                    // Atuializar o listBox
                    mostraContatos();
                }
            }
        }
    }
}
