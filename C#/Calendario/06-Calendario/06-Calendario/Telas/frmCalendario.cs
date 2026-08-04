using _06_Calendario.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_Calendario
{
    public partial class frmCalendario : Form
    {
        public frmCalendario()
        {
            InitializeComponent();
        }

        // Um list para armazenar as datas do banco de dados
        private List<DateTime> datasMarcadas = new List<DateTime>();

        // Um dicionário para guardar os compromissos
        private Dictionary<DateTime ,string> compromissos = new Dictionary<DateTime ,string>(); 

        private void frmCalendario_Load(object sender, EventArgs e)
        {
            // Buscar dados do banco
            List<(DateTime, string)> dadosCompromisso = Compromisso.buscarDataECompromisso();

            // Adicionar ao dicionário
            foreach(var (data, nome) in dadosCompromisso)
            {
                compromissos[data] = nome;
            }

            // Destacar as datas no calendário com negrito
            mthCalendario.BoldedDates = compromissos.Keys.ToArray();
        }

        private void mthCalendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            txbData.Text = mthCalendario.SelectionStart.ToShortDateString();
            DataTable compromissos = Compromisso.buscarCompromisso(txbData.Text);

            // Limpar o listBox
            lstCompromisso.Items.Clear();

            // Mostrar todos os compromissos cadastrados na mesma data
            foreach(DataRow row in compromissos.Rows)
            {
                // Adiciona cada compromisso do dia selecionado
                lstCompromisso.Items.Add(
                    $"{row["id_compromisso"]} - " +
                    $"{row["nome"]} - " +
                    $"{Convert.ToDateTime(row["data_inicio"]).ToString("dd/MM/yyyy")} - " +
                    $"{Convert.ToDateTime(row["data_fim"]).ToString("dd/MM/yyyy")} - " +
                    $"{row["hora_inicio"]} - " +
                    $"{row["hora_fim"]} - " +
                    $"{row["local"]}"
                    );
            }
            limparDados();
        }


        private void limparDados()
        {
            // Limpar os campos 
            txbId.Clear();
            txbCompromisso.Clear();
            txbDataInicio.Clear();
            txbDataFim.Clear();
            txbHoraInicio.Clear();
            txbHoraFim.Clear();
            txbLocal.Clear();

            // Resetar os botões
            btnCadastrar.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void lstCompromisso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCompromisso.SelectedIndex != -1)
            {
                string[] dados = lstCompromisso.SelectedItem.ToString().Split('-');
                txbId.Text = dados[0].Trim();
                txbCompromisso.Text = dados[1].Trim();
                txbDataInicio.Text = dados[2].Trim();
                txbDataFim.Text = dados[3].Trim();
                txbHoraInicio.Text = dados[4].Trim();
                txbHoraFim.Text = dados[5].Trim();
                txbLocal.Text = dados[6].Trim();

                btnCadastrar.Enabled = false;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparDados();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                try
                {
                    Compromisso insere = new Compromisso(txbCompromisso.Text, 
                        txbDataInicio.Text, txbDataFim.Text, txbHoraInicio.Text, 
                        txbHoraFim.Text, txbLocal.Text);
                    insere.insereCompromisso();
                    MessageBox.Show("Compromisso inserido", "Aviso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limparDados();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }



        private bool verificaCampos()
        {
            if (txbCompromisso.Text == string.Empty)
            {
                MessageBox.Show("Preencha o título do compromisso",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbCompromisso.Focus();
                return false;
            }
            if (txbDataInicio.Text == string.Empty)
            {
                MessageBox.Show("Preencha a data de início do compromisso",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbDataInicio.Focus();
                return false;
            }
            if (txbDataFim.Text == string.Empty)
            {
                MessageBox.Show("Preencha a data de término do compromisso",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbDataFim.Focus();
                return false;
            }
            if (txbHoraInicio.Text == string.Empty)
            {
                MessageBox.Show("Preencha hora do início do compromisso",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbCompromisso.Focus();
                return false;
            }
            if (txbHoraFim.Text == string.Empty)
            {
                MessageBox.Show("Preencha a hora de término do compromisso",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbHoraFim.Focus();
                return false;
            }
            if (txbLocal.Text == string.Empty)
            {
                MessageBox.Show("Preencha o local do compromisso",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbLocal.Focus();
                return false;
            }
            return true;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                try
                {
                    Compromisso altera = new Compromisso(int.Parse(txbId.Text),
                        txbCompromisso.Text, txbDataInicio.Text, txbDataFim.Text,
                        txbHoraInicio.Text, txbHoraFim.Text, txbLocal.Text);
                    altera.alteraCompromisso();
                    MessageBox.Show("Compromisso alterado", "Aviso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limparDados();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja remover esse compromisso?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(Pergunta == DialogResult.Yes)
            {
                Compromisso excluir = new Compromisso(int.Parse(txbId.Text));
                excluir.excluiCompromisso();
                MessageBox.Show("Compromisso excluído", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limparDados();
            }
        }
    }
}
