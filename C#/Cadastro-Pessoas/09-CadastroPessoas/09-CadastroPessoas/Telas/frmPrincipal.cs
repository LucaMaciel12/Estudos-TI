using _09_CadastroPessoas.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09_CadastroPessoas.Telas
{
    public partial class frmPrincipal : Form
    {
        Usuario usuarioLogado = new Usuario();
        public frmPrincipal(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            string nivel = "";
            if(usuarioLogado.Nivel == 0)
            {
                nivel = "administrador";
            }
            else
            {
                nivel = "usuário comum";
                toolUsuarios.Visible = false;
            }
            status.Text = usuarioLogado.Nome + " - permissão: " + nivel;
            dgvPessoas.DataSource = Pessoa.buscarPessoas();
            dgvPessoas.Columns[0].Visible = false;
            dgvPessoas.Columns[1].HeaderText = "Nome";
            dgvPessoas.Columns[2].HeaderText = "E-mail";
            dgvPessoas.Columns[3].HeaderText = "Dt Nascimento";
            dgvPessoas.Columns[4].HeaderText = "Sexo";
            dgvPessoas.Columns[5].Visible = false;
            dgvPessoas.Columns[6].Visible = false;
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog abreFoto = new OpenFileDialog();
            abreFoto.Title = "Selecione a foto";
            abreFoto.Filter = "Fotos .jpg (*.jpg)|*.jpg";
            DialogResult dr = abreFoto.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    txbFoto.Text = abreFoto.FileName;
                    picFoto.ImageLocation = txbFoto.Text;
                }
                catch (Exception)
                {

                    MessageBox.Show("Erro ao carregar a foto", "Aviso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // Remove os caracteres não numéricos da máscara
            // Como os parênteses, espaço e traço
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
                dgvFones.DataSource = null;
                dgvFones.ColumnCount = 1;
                dgvFones.Columns[0].Name = "Fone";
                dgvFones.Rows.Add(mskFone.Text);
                mskFone.Clear();
                mskFone.Focus();
            }
        }

        private void toolSalvar_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                try
                {
                    string Destino = Directory.GetCurrentDirectory();
                    CopiarArquivo(txbFoto.Text, @Destino + "\\" + Path.GetFileName(txbFoto.Text));

                    string dataSql = dtpNascimento.Value.ToString("yyyy-MM-dd");
                    Pessoa insere = new Pessoa(txbNome.Text, txbEmail.Text, dataSql,
                        cbbSexo.SelectedItem.ToString(), Path.GetFileName(txbFoto.Text), 1);
                    List<Fone> fones = new List<Fone>();
                    for(int i = 0; i < dgvFones.Rows.Count; i++)
                    {
                        Fone fone = new Fone(0, dgvFones.Rows[i].Cells[0].Value.ToString());
                        fones.Add(fone);
                    }
                    insere.Fones = fones;
                    insere.inserePessoa(dgvFones.RowCount);
                    MessageBox.Show("Pessoa inserida", "Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    limpaCampos();
                    txbNome.Focus();
                    dgvPessoas.DataSource = Pessoa.buscarPessoas();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private bool verificaCampos()
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
                MessageBox.Show("Preencha o email", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbEmail.Focus();
                return false;
            }
            if (dtpNascimento.Value == DateTime.Now)
            {
                MessageBox.Show("Preencha a data de nascimento", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpNascimento.Focus();
                return false;
            }
            if (cbbSexo.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o sexo", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbbSexo.Focus();
                return false;
            }
            if (dgvFones.Rows.Count < 1)
            {
                MessageBox.Show("Adicione um fone", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskFone.Focus();
                return false;
            }
            return true;
        }


        static bool CopiarArquivo(string nomeArquivoOrigem, 
            string nomeArquivoDestino)
        {
            if (File.Exists(nomeArquivoOrigem) == false)
            {
                MessageBox.Show("Atenção! \nNão foi possível encontrar a foto", "Cadastro de Pessoas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (File.Exists(nomeArquivoDestino) == true)
            {
                if (MessageBox.Show("Atenção! \nJá existe foto com esse nome, deseja substituir a foto?", "Cadastro de Pessoas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;
            }
            try
            {
                Stream s1 = File.Open(@nomeArquivoOrigem, FileMode.Open, FileAccess.ReadWrite);
                Stream s2 = File.Open(@nomeArquivoDestino, FileMode.Create);

                BinaryReader f1 = new BinaryReader(s1);
                BinaryWriter f2 = new BinaryWriter(s2);

                while (true)
                {
                    byte[] buf = new byte[10240];
                    int sz = f1.Read(buf, 0, 10240);
                    if (sz <= 0)
                        break;
                    f2.Write(buf, 0, sz);
                    if (sz < 10240)
                        break;
                }
                f1.Close();
                f2.Close();
                MessageBox.Show("Foto salva!", "Cadastro de Pessoas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao salvar a foto", "Cadastro de Pessoas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        private void limpaCampos()
        {
            txbId.Clear();
            txbNome.Clear();
            txbEmail.Clear();
            dtpNascimento.Value = DateTime.Now;
            cbbSexo.SelectedIndex = -1;
            txbFoto.Clear();
            dgvFones.DataSource = null;
            dgvFones.Rows.Clear();
            picFoto.Image = null;
            txbNome.Focus();
        }

        private void dgvPessoas_Click(object sender, EventArgs e)
        {
            toolSalvar.Enabled = false;
            toolAlterar.Enabled = true;
            toolExcluir.Enabled = true;
            toolCancelar.Visible = true;
            //btnFoto.Enabled = false;
            dgvPessoas.DefaultCellStyle.SelectionBackColor = Color.Tomato;
            grbFoto.Enabled = true;
            mostraPessoas();
            mostraFones();
        }

        private void mostraFones()
        {
            try
            {
                int id = Convert.ToInt32(txbId.Text);
                dgvFones.DataSource = Fone.buscaFones(id);
                dgvFones.Columns[0].Visible = false;
                dgvFones.Columns[1].Visible = false;
                dgvFones.Columns[2].HeaderText = "Fone";
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void mostraPessoas()
        {
            try
            {
                if (dgvPessoas.SelectedRows.Count > 0)
                {
                    txbId.Text = dgvPessoas.SelectedRows[0].Cells[0].Value.ToString();
                    txbNome.Text = dgvPessoas.SelectedRows[0].Cells[1].Value.ToString();
                    txbEmail.Text = dgvPessoas.SelectedRows[0].Cells[2].Value.ToString();
                    dtpNascimento.Text = dgvPessoas.SelectedRows[0].Cells[3].Value.ToString();
                    cbbSexo.Text = dgvPessoas.SelectedRows[0].Cells[4].Value.ToString();
                    txbFoto.Text = dgvPessoas.SelectedRows[0].Cells[5].Value.ToString();
                    picFoto.Image = null;
                    picFoto.Load(dgvPessoas.SelectedRows[0].Cells[5].Value.ToString());
                }
            }
            catch (Exception)
            {
                picFoto.Load("sem-imagem.jpg");
                
            }
        }

        private void toolCancelar_Click(object sender, EventArgs e)
        {
            limpaCampos();
            toolSalvar.Enabled = true;
            toolAlterar.Enabled = false;
            toolExcluir.Enabled = false;
            toolCancelar.Visible = false;
            dgvPessoas.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            txbNome.Focus();
        }

        private void toolAlterar_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                string dataSQL = dtpNascimento.Value.ToString("yyyy-MM-dd");
                Pessoa altera = new Pessoa(int.Parse(txbId.Text), txbNome.Text, 
                    txbEmail.Text, dataSQL, cbbSexo.SelectedItem.ToString());
                altera.alteraPessoa();

                MessageBox.Show("Pessoa alterada", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpaCampos();
                toolCancelar.PerformClick();
                txbNome.Focus();
                dgvPessoas.DataSource = Pessoa.buscarPessoas();
            }
        }

        private void picFoto_DoubleClick(object sender, EventArgs e)
        {
            btnFoto.PerformClick();
            grbCadastro.Enabled = false;
            toolAlterar.Visible = false;
            toolAlterarFoto.Visible = true;
        }

        private void toolAlterarFoto_Click(object sender, EventArgs e)
        {
            string Destino = Directory.GetCurrentDirectory();
            CopiarArquivo(txbFoto.Text, @Destino + "\\" + Path.GetFileName(txbFoto.Text));

            Pessoa mudaFoto = new Pessoa(int.Parse(txbId.Text), Path.GetFileName(txbFoto.Text));
            mudaFoto.alteraFoto();

            limpaCampos();
            grbCadastro.Enabled = true;
            grbFoto.Enabled = false;
            toolAlterar.Visible = true;
            toolAlterarFoto.Visible = false;
            toolCancelar.PerformClick();
            txbNome.Focus();
            dgvPessoas.DataSource = Pessoa.buscarPessoas();
        }

        private void dgvFones_DoubleClick(object sender, EventArgs e)
        {
            string fone = dgvFones.SelectedRows[0].Cells[2].Value.ToString();
            int idFone = Convert.ToInt32(dgvFones.SelectedRows[0].Cells[0].Value.ToString());
            int idPessoa = Convert.ToInt32(dgvFones.SelectedRows[0].Cells[1].Value.ToString());
            int qtde = dgvFones.Rows.Count;
            frmFone TF = new frmFone(fone, idFone, idPessoa, qtde);
            TF.ShowDialog();
        }

        private void toolExcluir_Click(object sender, EventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja excluir essa pessoa?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(Pergunta == DialogResult.Yes)
            {
                Pessoa desativa = new Pessoa(int.Parse(txbId.Text));
                desativa.desativaPessoa();
                MessageBox.Show("Pessoa excluída", "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                limpaCampos();
                toolCancelar.PerformClick();
                dgvPessoas.DataSource = Pessoa.buscarPessoas();
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
                dgvPessoas.DataSource = Pessoa.buscarPessoas();
            }
            if (cbbBusca.SelectedIndex == 1)
            {
                try
                {
                    dgvPessoas.DataSource = Pessoa.buscarPessoasPorId(int.Parse(txbBusca.Text));
                }
                catch (Exception)
                {

                    MessageBox.Show("Digite apenas números", "Aviso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            if (cbbBusca.SelectedIndex == 2)
            {
                dgvPessoas.DataSource = Pessoa.buscarPessoasPorNome(txbBusca.Text);
            }
            if (cbbBusca.SelectedIndex == 3)
            {
                dgvPessoas.DataSource = Pessoa.buscarPessoasPorEmail(txbBusca.Text);
            }
            if (cbbBusca.SelectedIndex == 4)
            {
                dgvPessoas.DataSource = Pessoa.buscarPessoasDesativadas();
            }
        }

        private void toolTrocaSenha_Click(object sender, EventArgs e)
        {
            frmTrocaSenha TS = new frmTrocaSenha(usuarioLogado);
            TS.ShowDialog();
        }

        private void toolUsuarios_Click(object sender, EventArgs e)
        {
            frmUsuarios TU = new frmUsuarios(usuarioLogado);
            TU.ShowDialog();
        }

        private void dgvPessoas_DoubleClick(object sender, EventArgs e)
        {
            if (usuarioLogado.Nivel == 0)
            {
                DialogResult Pergunta = MessageBox.Show("Deseja ativar essa pessoa?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Pergunta == DialogResult.Yes)
                {
                    Pessoa ativa = new Pessoa(int.Parse(txbId.Text));
                    ativa.ativaPessoa();
                    MessageBox.Show("Pessoa ativada", "Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    limpaCampos();
                    toolCancelar.PerformClick();
                    dgvPessoas.DataSource = Pessoa.buscarPessoas();
                    txbNome.Focus();
                }
            }
        }
    }
}
