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

namespace _05_GerenciadorDeTarefas
{
    public partial class frmTarefas : Form
    {
        public frmTarefas()
        {
            InitializeComponent();
        }

        private void frmTarefas_Load(object sender, EventArgs e)
        {
            if (File.Exists("tarefas.txt"))
            {
                using (StreamReader carrega = new StreamReader("tarefas.txt"))
                {
                    string linha;
                    while ((linha = carrega.ReadLine()) != null)
                    {
                        string[] dados = linha.Split('|');
                        Tarefa tarefa = new Tarefa()
                        {
                            Titulo = dados[0],
                            Descricao = dados[1],
                            Concluida = bool.Parse(dados[2])
                        };
                        lstTarefas.Items.Add(tarefa);
                    }
                }
            }
            else
            {
                MessageBox.Show("Arquivo tarefas.txt não encontrado",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                // Instanciar o objeto da tarefa
                Tarefa novaTarefa = new Tarefa
                {
                    Titulo = txbTarefa.Text,
                    Descricao = txbDescricao.Text,
                    Concluida = chkConcluida.Checked
                };

                // Adicionar a tarefa na listBox
                lstTarefas.Items.Add (novaTarefa);

                // Limpar os campos
                limpaCampos();
            }
        }

        private void limpaCampos()
        {
            txbTarefa.Clear();
            txbDescricao.Clear();
            chkConcluida.Checked = false;
        }

        private bool verificaCampos()
        {
            if (txbTarefa.Text == string.Empty)
            {
                MessageBox.Show("Digite o título da tarefa", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbTarefa.Focus();
                return false;
            }
            if (txbDescricao.Text == string.Empty)
            {
                MessageBox.Show("Digite a descrição da tarefa", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbDescricao.Focus();
                return false;
            }
            return true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            salvarArquivo();
            MessageBox.Show("Tarefa(s) salva(s)", "Aviso", 
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (lstTarefas.SelectedItem != null)
            {
                // Instanciando o objeto da classe Tarefa
                Tarefa tarefaSelecionada = (Tarefa)lstTarefas.SelectedItem;

                // Atualiza os dados da tarefa
                tarefaSelecionada.Titulo = txbTarefa.Text;
                tarefaSelecionada.Descricao = txbDescricao.Text;
                tarefaSelecionada.Concluida = chkConcluida.Checked;

                // Atualiza a exibição na listBox
                int index = lstTarefas.SelectedIndex;
                lstTarefas.Items[index] = tarefaSelecionada;

                // Salvar no arquivo de texto
                salvarArquivo();
                MessageBox.Show("Tarefa(s) alterada(s)", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // Limpar os campos
                limpaCampos();
            }
        }


        private void salvarArquivo()
        {
            using (StreamWriter salvar = new StreamWriter("tarefas.txt"))
            {
                foreach (Tarefa tarefa in lstTarefas.Items)
                {
                    salvar.WriteLine($"{tarefa.Titulo} | {tarefa.Descricao} | {tarefa.Concluida}");
                }
            }
        }

        private void lstTarefas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTarefas.SelectedItem != null)
            {
                // Instanciar o objeto da classe Tarefa
                Tarefa tarefaSelecionada = (Tarefa)lstTarefas.SelectedItem;

                txbTarefa.Text = tarefaSelecionada.Titulo;
                txbDescricao.Text = tarefaSelecionada.Descricao;
                chkConcluida.Checked = tarefaSelecionada.Concluida;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (lstTarefas.SelectedItem != null)
            {
                // Remover a tarefa da listBox
                lstTarefas.Items.Remove(lstTarefas.SelectedItem);

                // Atualizar o arquivo de texto
                salvarArquivo();
                MessageBox.Show("Tarefa removida", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // Limpar os campos
                limpaCampos();
            }
        }
    }
}
