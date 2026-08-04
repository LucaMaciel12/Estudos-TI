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
    public partial class frmUsuarios : Form
    {
        Usuario usuarioLogado = new Usuario();
        public frmUsuarios(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }

        private void toolSalvar_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                try
                {
                    string senha = Crypto.sha256encrypt("123");
                    senha = senha.ToLower();
                    string frase = "padrão";
                    Usuario insere = new Usuario(txbNome.Text, txbEmail.Text,
                        txbLogin.Text, senha, frase, cbbNivel.SelectedIndex, 1);
                    insere.insereUsuario();
                    MessageBox.Show("usuário inserido", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpaCampos();
                    dgvUsuarios.DataSource = Usuario.buscarUsuarios();
                }
                catch (Exception erro)
                {

                    MessageBox.Show(erro.Message, "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }


        private bool verificaCampos()
        {
            if(txbNome.Text == string.Empty)
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

            if (txbLogin.Text == string.Empty)
            {
                MessageBox.Show("Preencha o login", "Aviso",
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
            txbId.Clear();
            txbNome.Clear();
            txbEmail.Clear();
            txbLogin.Clear();
            cbbNivel.SelectedIndex = -1;
            txbNome.Focus();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = Usuario.buscarUsuarios();
            dgvUsuarios.Columns[0].Visible = false;
            dgvUsuarios.Columns[1].HeaderText = "Nome";
            dgvUsuarios.Columns[2].HeaderText = "E-mail";
            dgvUsuarios.Columns[3].HeaderText = "Login";
            dgvUsuarios.Columns[4].Visible = false;
            dgvUsuarios.Columns[5].Visible = false;
            dgvUsuarios.Columns[6].Visible = false;
            dgvUsuarios.Columns[7].Visible = false;
        }

        private void dgvUsuarios_Click(object sender, EventArgs e)
        {
            toolSalvar.Enabled = false;
            toolAlterar.Enabled = true;
            toolExcluir.Enabled = true;
            toolCancelar.Visible = true;
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.Tomato;
            mostraUsuarios();
        }


        private void mostraUsuarios()
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    txbId.Text = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                    txbNome.Text = dgvUsuarios.SelectedRows[0].Cells[1].Value.ToString();
                    txbEmail.Text = dgvUsuarios.SelectedRows[0].Cells[2].Value.ToString();
                    txbLogin.Text = dgvUsuarios.SelectedRows[0].Cells[3].Value.ToString();
                    if(txbLogin.Text == "admin")
                    {
                        txbLogin.Enabled = false;
                        toolExcluir.Enabled = false;
                    }
                    else
                    {
                        txbLogin.Enabled = true;
                        toolExcluir.Enabled = true;
                    }
                    cbbNivel.SelectedIndex = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[6].Value.ToString());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        private void toolAlterar_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                Usuario altera = new Usuario(int.Parse(txbId.Text), txbNome.Text,
                    txbEmail.Text, txbLogin.Text, cbbNivel.SelectedIndex);
                altera.alteraUsuario();

                MessageBox.Show("Usuário alterado", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpaCampos();
                toolCancelar.PerformClick();
                txbNome.Focus();
                dgvUsuarios.DataSource = Usuario.buscarUsuarios();
            }
        }

        private void toolCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            toolSalvar.Enabled = true;
            toolAlterar.Enabled = false;
            toolExcluir.Enabled = false;
            toolCancelar.Visible = false;
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            txbNome.Focus();
        }

        private void toolExcluir_Click(object sender, EventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja excluir esse usuário?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Pergunta == DialogResult.Yes)
            {
                Usuario desativa = new Usuario(int.Parse(txbId.Text));
                desativa.desativaUsuario();
                MessageBox.Show("Usuário excluído", "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                limpaCampos();
                toolCancelar.PerformClick();
                dgvUsuarios.DataSource = Usuario.buscarUsuarios();
                txbNome.Focus();
            }
        }

        private void cbbBusca_DropDownClosed(object sender, EventArgs e)
        {
            if (cbbBusca.SelectedIndex == 0 || cbbBusca.SelectedIndex == 4)
            {
                txbBusca.Clear();
                txbBusca.Enabled = false;
            }
            else
            {
                txbBusca.Enabled = true;
                txbBusca.Clear();
                txbBusca.Focus();
            }
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            if (cbbBusca.SelectedIndex == 0)
            {
                dgvUsuarios.DataSource = Usuario.buscarUsuarios();
            }
            if (cbbBusca.SelectedIndex == 1)
            {
                try
                {
                    dgvUsuarios.DataSource = Usuario.buscarUsuariosPorId(int.Parse(txbBusca.Text));
                }
                catch (Exception)
                {

                    MessageBox.Show("Digite apenas números", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            if (cbbBusca.SelectedIndex == 2)
            {
                dgvUsuarios.DataSource = Usuario.buscarUsuariosPorNome(txbBusca.Text);
            }
            if (cbbBusca.SelectedIndex == 3)
            {
                dgvUsuarios.DataSource = Usuario.buscarUsuariosPorEmail(txbBusca.Text);
            }
            if (cbbBusca.SelectedIndex == 4)
            {
                dgvUsuarios.DataSource = Usuario.buscarUsuariosDesativados();
            }
        }

        private void toolTrocaSenha_Click(object sender, EventArgs e)
        {
            frmTrocaSenha TS = new frmTrocaSenha(usuarioLogado);
            TS.ShowDialog();
        }

        private void dgvUsuarios_DoubleClick(object sender, EventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja ativar esse usuário?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Pergunta == DialogResult.Yes)
            {
                Usuario ativa = new Usuario(int.Parse(txbId.Text));
                ativa.ativaUsuario();
                MessageBox.Show("Usuário ativado", "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                limpaCampos();
                toolCancelar.PerformClick();
                dgvUsuarios.DataSource = Usuario.buscarUsuarios();
                txbNome.Focus();
            }
        }
    }
}
