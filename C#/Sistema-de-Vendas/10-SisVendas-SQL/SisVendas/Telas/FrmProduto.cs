using SisVendas.Classes;
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

namespace SisVendas.Telas
{
    public partial class FrmProduto : Form
    {
        Usuario usuarioLogado = new Usuario();
        public FrmProduto(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            dgvProdutos.DataSource = Produto.buscarTodosProdutos();
            dgvProdutos.Columns[0].Visible = false;
            dgvProdutos.Columns[1].HeaderText = "Nome";
            dgvProdutos.Columns[2].Visible = false;
            dgvProdutos.Columns[3].Visible = false;
            dgvProdutos.Columns[4].HeaderText = "Quantidade";
            dgvProdutos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProdutos.Columns[5].HeaderText = "Valor";
            dgvProdutos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProdutos.Columns[5].DefaultCellStyle.Format = "C2";
            dgvProdutos.Columns[6].Visible = false;
        }

        private void dgvProdutos_Click(object sender, EventArgs e)
        {
            toolStripSalvar.Enabled = false;
            toolStripAlterar.Enabled = true;
            toolStripExcluir.Enabled = true;
            toolStripCancelar.Visible = true;
            gpbFoto.Enabled = true;
            if (int.Parse(dgvProdutos.SelectedRows[0].Cells[6].Value.ToString()) == 1)
            {
                toolStripDesativar.Visible = true;
                toolStripAtivar.Visible = false;
            }
            else
            {
                toolStripDesativar.Visible = false;
                toolStripAtivar.Visible = true;
            }
            dgvProdutos.DefaultCellStyle.SelectionBackColor = Color.Tomato;
            try
            {
                txbId.Text = dgvProdutos.SelectedRows[0].Cells[0].Value.ToString();
                txbNome.Text = dgvProdutos.SelectedRows[0].Cells[1].Value.ToString();
                txbFoto.Text = dgvProdutos.SelectedRows[0].Cells[2].Value.ToString();
                
                txbDescricao.Text = dgvProdutos.SelectedRows[0].Cells[3].Value.ToString();
                txbQtde.Text = dgvProdutos.SelectedRows[0].Cells[4].Value.ToString();
                txbValor.Text = dgvProdutos.SelectedRows[0].Cells[5].Value.ToString();
                picFoto.Image = null;
                picFoto.Load(dgvProdutos.SelectedRows[0].Cells[2].Value.ToString());
            }
            catch (Exception)
            {
                picFoto.Image = null;
                picFoto.Load("sem-imagem.jpg");
                
            }
        }

        private void toolStripAtivar_Click(object sender, EventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja ativar este produto?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(Pergunta == DialogResult.Yes)
            {
                Produto ativa = new Produto(int.Parse(txbId.Text));
                ativa.ativarProduto();
                limpaCampos();
                toolStripCancelar.PerformClick();
                dgvProdutos.DataSource = Produto.buscarTodosProdutos();
                txbNome.Focus();
            }
        }

        private void limpaCampos()
        {
            txbId.Clear();
            txbNome.Clear();
            txbDescricao.Clear();
            txbValor.Clear();
            txbQtde.Clear();
            picFoto.Image = null;
            txbFoto.Clear();
        }

        private void toolStripCancelar_Click(object sender, EventArgs e)
        {
            toolStripSalvar.Enabled = true;
            toolStripAlterar.Enabled = false;
            toolStripAlterar.Visible = true;
            toolStripMudaFoto.Visible = false;
            toolStripExcluir.Enabled = false;
            toolStripCancelar.Visible = false;
            toolStripAtivar.Visible = false;
            toolStripDesativar.Visible = false;
            dgvProdutos.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue;
            gpbCadastro.Enabled = true;
            limpaCampos();
        }

        private void toolStripSalvar_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                try
                {
                    // Copiar a foto
                    string Destino = Directory.GetCurrentDirectory();
                    CopiarArquivo(txbFoto.Text, @Destino + "\\" + Path.GetFileName(txbFoto.Text));

                    // Enviar dados para o banco de dados
                    Produto insere = new Produto(txbNome.Text, Path.GetFileName(txbFoto.Text),
                        txbDescricao.Text, int.Parse(txbQtde.Text), Convert.ToDecimal(txbValor.Text),
                        1);
                    insere.insereProduto();
                    MessageBox.Show("Produto inserido", "Aviso", MessageBoxButtons.OK, 
                        MessageBoxIcon.Exclamation);
                    limpaCampos();
                    toolStripCancelar.PerformClick();
                    dgvProdutos.DataSource = Produto.buscarTodosProdutos();
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
                MessageBox.Show("Digite o nome", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbNome.Focus();
                return false;
            }
            if (txbValor.Text == string.Empty)
            {
                MessageBox.Show("Digite o valor", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbValor.Focus();
                return false;
            }
            if (txbFoto.Text == string.Empty)
            {
                MessageBox.Show("Selecione a foto", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnFoto.Focus();
                return false;
            }
            if (txbQtde.Text == string.Empty)
            {
                MessageBox.Show("Digite a quantidade", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbQtde.Focus();
                return false;
            }
            if (txbDescricao.Text == string.Empty)
            {
                MessageBox.Show("Digite a descrição", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbDescricao.Focus();
                return false;
            }
            return true;
        }

        static bool CopiarArquivo(string nomeArquivoOrigem, string nomeArquivoDestino)
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

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog abreFoto = new OpenFileDialog();
            abreFoto.Title = "Selecione sua foto";
            abreFoto.Filter = "Fotos .jpg (*.jpg)|*.jpg";
            DialogResult dr = abreFoto.ShowDialog();
            if(dr == DialogResult.OK)
            {
                try
                {
                    txbFoto.Text = abreFoto.FileName;
                    picFoto.ImageLocation = txbFoto.Text;
                }
                catch (Exception erro)
                {

                    MessageBox.Show(erro.Message, "Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripAlterar_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                Produto altera = new Produto(int.Parse(txbId.Text),
                    txbNome.Text, txbDescricao.Text, int.Parse(txbQtde.Text),
                    Convert.ToDecimal(txbValor.Text));
                altera.alteraProduto();
                limpaCampos();
                toolStripCancelar.PerformClick();
                dgvProdutos.DataSource = Produto.buscarTodosProdutos();
                MessageBox.Show("Produto alterado", "Aviso", MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                txbNome.Focus();
            }
        }

        private void picFoto_DoubleClick(object sender, EventArgs e)
        {
            btnFoto.Enabled = true;
            btnFoto.PerformClick();
            gpbCadastro.Enabled = false;
            toolStripSalvar.Enabled = false;
            toolStripAlterar.Visible = false;
            toolStripMudaFoto.Visible = true;
            toolStripExcluir.Enabled = false;
            toolStripDesativar.Visible = false;
            toolStripAtivar.Visible = false;
            toolStripCancelar.Visible = true;
        }

        private void toolStripMudaFoto_Click(object sender, EventArgs e)
        {
            string Destino = Directory.GetCurrentDirectory();
            CopiarArquivo(txbFoto.Text, @Destino + "\\" + Path.GetFileName(txbFoto.Text));

            Produto mudaFoto = new Produto(int.Parse(txbId.Text), 
                                           Path.GetFileName(txbFoto.Text));
            mudaFoto.alteraFoto();
            MessageBox.Show("Foto alterada", "Aviso", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            limpaCampos();
            toolStripCancelar.PerformClick();
            dgvProdutos.DataSource = Produto.buscarTodosProdutos();
            txbNome.Focus();
        }

        private void toolStripDesativar_Click(object sender, EventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja desativar este produto?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(Pergunta == DialogResult.Yes)
            {
                Produto desativa = new Produto(int.Parse(txbId.Text));
                desativa.desativarProduto();
                MessageBox.Show("Produto desativado", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpaCampos();
                toolStripCancelar.PerformClick();
                dgvProdutos.DataSource = Produto.buscarTodosProdutos();
                txbNome.Focus();
            }
        }

        private void toolStripExcluir_Click(object sender, EventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja excluir este produto?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Pergunta == DialogResult.Yes)
            {
                Produto excluir = new Produto(int.Parse(txbId.Text));
                excluir.excluirProduto();
                MessageBox.Show("Produto excluído", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpaCampos();
                toolStripCancelar.PerformClick();
                dgvProdutos.DataSource = Produto.buscarTodosProdutos();
                txbNome.Focus();
            }
        }

        private void cbbBusca_DropDownClosed(object sender, EventArgs e)
        {
            if(cbbBusca.SelectedIndex == 0)
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
                dgvProdutos.DataSource = Produto.buscarTodosProdutos();
            }

            if(cbbBusca.SelectedIndex == 1)
            {
                try
                {
                    dgvProdutos.DataSource = Produto.buscarProdutosPorId(int.Parse(txbBuscar.Text));
                }
                catch (Exception)
                {

                    
                }
            }

            if (cbbBusca.SelectedIndex == 2)
            {
                dgvProdutos.DataSource = Produto.buscarProdutosPorNome(txbBuscar.Text);
            }
        }
    }
}
