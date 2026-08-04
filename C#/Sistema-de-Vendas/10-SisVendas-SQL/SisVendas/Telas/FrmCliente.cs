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
    public partial class FrmCliente : Form
    {
        Usuario usuarioLogado = new Usuario();
        public FrmCliente(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            dgvClientes.DataSource = Cliente.buscarTodosClientes();
            dgvClientes.Columns[0].Visible = false;
            dgvClientes.Columns[1].HeaderText = "Nome";
            dgvClientes.Columns[2].HeaderText = "E-mail";
            dgvClientes.Columns[3].HeaderText = "Fone";
            dgvClientes.Columns[4].HeaderText = "Dt Nascimento";
            dgvClientes.Columns[5].HeaderText = "Sexo";
            dgvClientes.Columns[6].Visible = false;
        }

        private void toolStripExcluir_Click(object sender, EventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja remover esse cliente?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(Pergunta == DialogResult.Yes)
            {
                Cliente desativa = new Cliente(int.Parse(txbId.Text));
                desativa.desativaCliente();
                MessageBox.Show("Cliente excluído", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                toolStripCancelar.PerformClick();
                limpaCampos();
                dgvClientes.DataSource = Cliente.buscarTodosClientes();
                txbNome.Focus();
            }
        }


        private void limpaCampos()
        {
            txbId.Clear();
            txbNome.Clear();
            txbEmail.Clear();
            mskFone.Clear();
            dtpNasc.Value = DateTime.Now;
            cbbSexo.SelectedIndex = -1;
        }

        private void toolStripCancelar_Click(object sender, EventArgs e)
        {
            toolStripSalvar.Enabled = true;
            toolStripAlterar.Enabled = false;
            toolStripExcluir.Enabled = false;
            toolStripCancelar.Visible = false;
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
        }

        private void dgvClientes_Click(object sender, EventArgs e)
        {
            toolStripSalvar.Enabled = false;
            toolStripAlterar.Enabled = true;
            toolStripExcluir.Enabled = true;
            toolStripCancelar.Visible = true;
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.Tomato;
            mostraCliente();
        }


        private void mostraCliente()
        {
            if(dgvClientes.SelectedRows.Count > 0)
            {
                txbId.Text = dgvClientes.SelectedRows[0].Cells[0].Value.ToString();
                txbNome.Text = dgvClientes.SelectedRows[0].Cells[1].Value.ToString();
                txbEmail.Text = dgvClientes.SelectedRows[0].Cells[2].Value.ToString();
                mskFone.Text = dgvClientes.SelectedRows[0].Cells[3].Value.ToString();
                dtpNasc.Text = dgvClientes.SelectedRows[0].Cells[4].Value.ToString();
                cbbSexo.Text = dgvClientes.SelectedRows[0].Cells[5].Value.ToString();
            }
        }

        private void toolStripAlterar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                string dataSQL = dtpNasc.Value.ToString("yyyy-MM-dd");
                Cliente altera = new Cliente(int.Parse(txbId.Text),txbNome.Text,
                    txbEmail.Text, mskFone.Text, dataSQL, 
                    cbbSexo.SelectedItem.ToString());
                altera.alteraCliente();
                MessageBox.Show("Cliente alterado", "Aviso", MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                toolStripCancelar.PerformClick();
                limpaCampos();
                dgvClientes.DataSource = Cliente.buscarTodosClientes();
                txbNome.Focus();
            }
        }


        private bool validaCampos()
        {
            if (txbNome.Text == string.Empty)
            {   
                MessageBox.Show("Preencha o nome", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbNome.Focus();
                return false;
            }

            if (txbEmail.Text == string.Empty)
            {
                MessageBox.Show("Preencha o e-mail", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbEmail.Focus();
                return false;
            }

            if (mskFone.Text == string.Empty)
            {
                MessageBox.Show("Preencha o fone", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskFone.Focus();
                return false;
            }

            if (dtpNasc.Value == DateTime.Now)
            {
                MessageBox.Show("Selecione a data de nascimento", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpNasc.Focus();
                return false;
            }

            if (cbbSexo.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o sexo", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbbSexo.Focus();
                return false;
            }

            return true;
        }

        private void toolStripSalvar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                string dataSQL = dtpNasc.Value.ToString("yyyy-MM-dd");
                Cliente insere = new Cliente(txbNome.Text, txbEmail.Text,
                    mskFone.Text, dataSQL, cbbSexo.SelectedItem.ToString(),
                    1);
                insere.insereCliente();
                MessageBox.Show("Cliente inserido", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                toolStripCancelar.PerformClick();
                limpaCampos();
                dgvClientes.DataSource = Cliente.buscarTodosClientes();
            }
        }

        private void cbbBusca_DropDownClosed(object sender, EventArgs e)
        {
            if(cbbBusca.SelectedIndex == 0 || cbbBusca.SelectedIndex == 5)
            {
                txbBuscar.Clear();
                txbBuscar.Enabled = false;
            }
            else
            {
                txbBuscar.Enabled = true;
                txbBuscar.Clear();
                txbBuscar.Focus();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(cbbBusca.SelectedIndex == 0)
            {
                dgvClientes.DataSource = Cliente.buscarTodosClientes();
            }

            try
            {
                if (cbbBusca.SelectedIndex == 1)
                {
                    dgvClientes.DataSource = Cliente.buscarTodosClientesPorId(int.Parse(txbBuscar.Text));
                }
            }
            catch (Exception)
            {

                
            }

            if (cbbBusca.SelectedIndex == 2)
            {
                dgvClientes.DataSource = Cliente.buscarTodosClientesPorNome(txbBuscar.Text);
            }

            if (cbbBusca.SelectedIndex == 3)
            {
                dgvClientes.DataSource = Cliente.buscarTodosClientesPorEmail(txbBuscar.Text);
            }

            if (cbbBusca.SelectedIndex == 4)
            {
                dgvClientes.DataSource = Cliente.buscarTodosClientesPorFone(txbBuscar.Text);
            }

            if (cbbBusca.SelectedIndex == 5)
            {
                dgvClientes.DataSource = Cliente.buscarTodosClientesDesativados();
            }
        }
    }
}
