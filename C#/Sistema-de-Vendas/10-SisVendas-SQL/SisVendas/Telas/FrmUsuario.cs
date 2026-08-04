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
    public partial class FrmUsuario : Form
    {
        Usuario usuarioLogado = new Usuario();
        public FrmUsuario(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = Usuario.buscarTodosUsuarios();
            dgvUsuarios.Columns[0].Visible = false;
            dgvUsuarios.Columns[1].HeaderText = "Nome";
            dgvUsuarios.Columns[2].HeaderText = "E-mail";
            dgvUsuarios.Columns[3].Visible = false;
            dgvUsuarios.Columns[4].Visible = false;
            dgvUsuarios.Columns[5].Visible = false;
            dgvUsuarios.Columns[6].HeaderText = "Nível";
            dgvUsuarios.Columns[7].Visible = false;

            dgvUsuariosDesativados.DataSource = Usuario.buscarTodosUsuariosDesativados();
            dgvUsuariosDesativados.Columns[0].Visible = false;
            dgvUsuariosDesativados.Columns[1].HeaderText = "Nome";
            dgvUsuariosDesativados.Columns[2].HeaderText = "E-mail";
            dgvUsuariosDesativados.Columns[3].Visible = false;
            dgvUsuariosDesativados.Columns[4].Visible = false;
            dgvUsuariosDesativados.Columns[5].Visible = false;
            dgvUsuariosDesativados.Columns[6].HeaderText = "Nível";
            dgvUsuariosDesativados.Columns[7].Visible = false;
        }

        private void dgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.Value != null)
            {
                int valor = Convert.ToInt32(e.Value);
                if(valor == 0)
                {
                    e.Value = "Administrador";
                }
                else
                {
                    e.Value = "Comum";
                }
                e.FormattingApplied = true;
            }
        }

        private void dgvUsuariosDesativados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.Value != null)
            {
                int valor = Convert.ToInt32(e.Value);
                if (valor == 0)
                {
                    e.Value = "Administrador";
                }
                else
                {
                    e.Value = "Comum";
                }
                e.FormattingApplied = true;
            }
        }

        private void toolStripSalvar_Click(object sender, EventArgs e)
        {
            if (validaDados())
            {
                try
                {
                    string senha = Crypto.sha256encrypt("123");
                    senha = senha.ToLower();
                    string frase = "Padrão";
                    Usuario insere = new Usuario(txbNome.Text, txbEmail.Text, txbLogin.Text,
                        senha, frase, cbbNivel.SelectedIndex, 1);
                    insere.insereUsuario();
                    MessageBox.Show("Usuário inserido", "Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    limpaCampos();
                    txbNome.Focus();
                    dgvUsuarios.DataSource = Usuario.buscarTodosUsuarios();
                }
                catch (Exception erro)
                {

                    MessageBox.Show(erro.Message, "Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                
            }
        }



        private bool validaDados()
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
                MessageBox.Show("Digite o e-mail", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbEmail.Focus();
                return false;
            }
            if (txbLogin.Text == string.Empty)
            {
                MessageBox.Show("Digite o login", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbLogin.Focus();
                return false;
            }
            if (cbbNivel.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o nível", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbbNivel.Focus();
                return false;
            }
            return true;
        }



        private void limpaCampos()
        {
            txbNome.Clear();
            txbEmail.Clear();
            txbLogin.Clear();
            cbbNivel.SelectedIndex = -1;
        }

        private void toolStripAlterar_Click(object sender, EventArgs e)
        {
            if (validaDados())
            {
                Usuario altera = new Usuario(int.Parse(txbId.Text),
                    txbNome.Text, txbEmail.Text, txbLogin.Text,
                    cbbNivel.SelectedIndex);
                altera.alteraUsuario();
                MessageBox.Show("Usuário alterado", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpaCampos();
                toolStripCancelar.PerformClick();
                dgvUsuarios.DataSource = Usuario.buscarTodosUsuarios();
                txbNome.Focus();
            }
            
        }

        private void toolStripCancelar_Click(object sender, EventArgs e)
        {
            toolStripSalvar.Enabled = true;
            toolStripAlterar.Enabled = false;
            toolStripExcluir.Enabled = false;
            toolStripCancelar.Visible = false;
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue;
        }

        private void dgvUsuarios_Click(object sender, EventArgs e)
        {
            toolStripSalvar.Enabled = false;
            toolStripAlterar.Enabled = true;
            toolStripExcluir.Enabled = true;
            toolStripCancelar.Visible = true;
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.Tomato;
            txbId.Text = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();
            txbNome.Text = dgvUsuarios.SelectedRows[0].Cells[1].Value.ToString();
            txbEmail.Text = dgvUsuarios.SelectedRows[0].Cells[2].Value.ToString();
            txbLogin.Text = dgvUsuarios.SelectedRows[0].Cells[3].Value.ToString();
            cbbNivel.SelectedIndex = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[6].Value.ToString());
            if (txbLogin.Text == "admin")
            {
                txbLogin.Enabled = false;
                toolStripExcluir.Enabled = false;
                cbbNivel.Enabled = false;
            }
            else
            {
                txbLogin.Enabled = true;
                toolStripExcluir.Enabled = true;
                cbbNivel.Enabled = true;
            }
        }

        private void dgvUsuariosDesativados_DoubleClick(object sender, EventArgs e)
        {
            if (dgvUsuariosDesativados.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgvUsuariosDesativados.SelectedRows[0].Cells[0].Value.ToString());
                DialogResult pergunta = MessageBox.Show("Deseja ativar este usuário?",
                    "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(pergunta == DialogResult.Yes)
                {
                    Usuario ativa = new Usuario(id);
                    ativa.ativaUsuario();
                    MessageBox.Show("Usuário ativado", "Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    dgvUsuarios.DataSource = Usuario.buscarTodosUsuarios();
                    dgvUsuariosDesativados.DataSource = Usuario.buscarTodosUsuariosDesativados();
                    txbNome.Focus();
                }
            }
            

        }

        private void toolStripExcluir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString());
            DialogResult pergunta = MessageBox.Show("Deseja desativar este usuário?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pergunta == DialogResult.Yes)
            {
                Usuario desativa = new Usuario(id);
                desativa.desativaUsuario();
                MessageBox.Show("Usuário desativado", "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                dgvUsuarios.DataSource = Usuario.buscarTodosUsuarios();
                dgvUsuariosDesativados.DataSource = Usuario.buscarTodosUsuariosDesativados();
                limpaCampos();
                toolStripCancelar.PerformClick();
                txbNome.Focus();
            }

        }
    }
}
