using SisVendas.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisVendas.Telas
{
    public partial class FrmVenda : Form
    {
        Usuario usuarioLogado = new Usuario();
        decimal total = 0;
        public FrmVenda(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }

        private void FrmVenda_Load(object sender, EventArgs e)
        {
            cbbCliente.DataSource = Cliente.buscarTodosClientes();
            cbbCliente.DisplayMember = "nome";
            cbbCliente.ValueMember = "id_cliente";
            cbbCliente.SelectedIndex = -1;

            cbbProduto.DataSource = Produto.buscarTodosProdutos();
            cbbProduto.DisplayMember = "nome";
            cbbProduto.ValueMember = "id_produto";
            cbbProduto.SelectedIndex = -1;

            lblData.Text = DateTime.Now.ToString("dd/MM/yyyy");

            dgvPedidos.DataSource = Pedido.buscarTodosPedidos();
            dgvPedidos.Columns[0].HeaderText = "Código";
            dgvPedidos.Columns[1].Visible = false;
            dgvPedidos.Columns[2].Visible = false;
            dgvPedidos.Columns[3].Visible = false;
            dgvPedidos.Columns[4].Visible = false;

        }

        private void cbbProduto_DropDownClosed(object sender, EventArgs e)
        {
            if (cbbProduto.SelectedIndex != -1)
            {
                DataRowView drw = ((DataRowView)cbbProduto.SelectedItem);
                txbId.Text = drw["id_produto"].ToString();
                txbPreco.Text = drw["valor"].ToString();
                txbEstoque.Text = drw["qtde"].ToString();
                mskQtde.Clear();
                mskQtde.Focus();

            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(mskQtde.Text) > 0 &&
                mskQtde.Text != string.Empty)
            {
                if (Convert.ToInt32(mskQtde.Text) <= 
                    Convert.ToInt32(txbEstoque.Text))
                {
                    dgvItens.DataSource = null;
                    dgvItens.ColumnCount = 5;
                    dgvItens.Columns[0].HeaderText = "Código";
                    dgvItens.Columns[1].HeaderText = "Produto";
                    dgvItens.Columns[2].HeaderText = "Qtde";
                    dgvItens.Columns[3].HeaderText = "Preço";
                    dgvItens.Columns[4].HeaderText = "Subtotal";
                    dgvItens.Rows.Add(txbId.Text, 
                                      cbbProduto.Text,
                                      mskQtde.Text,
                                      txbPreco.Text,
                                      Convert.ToInt32(mskQtde.Text) * Convert.ToDecimal(txbPreco.Text));
                    total += (Convert.ToInt32(mskQtde.Text) * Convert.ToDecimal(txbPreco.Text));
                    lblTotal.Text = total.ToString();
                }
                else
                {
                    MessageBox.Show("Verifique a quantidade em estoque", 
                        "Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }

        private void dgvItens_DoubleClick(object sender, EventArgs e)
        {
            if(dgvItens.SelectedRows.Count > 0)
            {
                total -= Convert.ToDecimal(dgvItens.CurrentRow.Cells[4].Value.ToString());
                lblTotal.Text = total.ToString();
                dgvItens.Rows.Remove(dgvItens.CurrentRow);
            }
        }

        private void toolStripSalvar_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                String dataSQL = DateTime.Now.ToString("yyyy-MM-dd");
                Pedido PD = new Pedido(int.Parse(cbbCliente.SelectedValue.ToString()),
                              usuarioLogado.Id_usuario, dataSQL, total);
                List<ItensPedido> itens = new List<ItensPedido>();
                for(int i = 0; i < dgvItens.Rows.Count; i++)
                {
                    ItensPedido item = new ItensPedido(
                        0,
                        Convert.ToInt32(dgvItens.Rows[i].Cells[0].Value),
                        Convert.ToDecimal(dgvItens.Rows[i].Cells[3].Value),
                        Convert.ToInt32(dgvItens.Rows[i].Cells[2].Value),
                        Convert.ToDecimal(dgvItens.Rows[i].Cells[4].Value)
                        );
                    itens.Add(item);

                    // Dar baixa na quantidade de cada produto
                    Produto baixa = new Produto(
                        Convert.ToInt32(dgvItens.Rows[i].Cells[0].Value),
                        Convert.ToInt32(dgvItens.Rows[i].Cells[2].Value),
                        1
                        );
                    baixa.baixaProdutos();
                }
                PD.ItensPedido = itens;
                PD.inserePedido(dgvItens.RowCount);
                MessageBox.Show("Pedido gerado com sucesso", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                toolStripSalvar.Enabled = false;
                toolStripImprimir.Visible = true;
                toolStripLimpar.Enabled = false;

                // Atualizar o combobox dos produtos
                cbbProduto.DataSource = Produto.buscarTodosProdutos();
                cbbProduto.DisplayMember = "nome";
                cbbProduto.ValueMember = "id_produto";
                cbbProduto.SelectedIndex = -1;

                toolStripImprimir.PerformClick();
            }
        }


        private bool verificaCampos()
        {
            if(cbbCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o cliente", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbbCliente.Focus();
                return false;
            }
            if (cbbProduto.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um produto", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbbProduto.Focus();
                return false;
            }
            if (mskQtde.Text == string.Empty)
            {
                MessageBox.Show("Digite a quantidade", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskQtde.Focus();
                return false;
            }
            if (dgvItens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Adicione o produto", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnAdicionar.Focus();
                return false;
            }
            return true;
        }

        private void toolStripImprimir_Click(object sender, EventArgs e)
        {
            using(PrintDocument print = new PrintDocument())
            using(PrintPreviewDialog dialog = new PrintPreviewDialog())
            {
                print.PrintPage += Print_Page;
                dialog.Document = print;

                // Abrir o documento maximizado
                dialog.Load += (s, ev) =>
                {
                    Form form = dialog as Form;
                    if (form != null)
                    {
                        form.WindowState = FormWindowState.Maximized;
                    }
                };

                dialog.ShowDialog();
                toolStripLimpar.Enabled = true;
            }
        }


        private void Print_Page(object sender, PrintPageEventArgs e)
        {
            int UltimoId = Pedido.buscaID();

            // Instanciando o objeto gráfico
            Graphics g = e.Graphics;
            // Instanciando o local da imagem
            Image image = Image.FromFile(string.Format("{0}{1}", Application.StartupPath, "\\logo.png"));

            using (Font fontDestaque = new Font("Arial Black", 14),
                        fontPadrao = new Font("Arial", 12),
                        fontData = new Font("Arial", 10))
            {
                // Posicionamento do logo
                g.DrawImage(image, 40, 20);
                // Posicionamdo o título
                g.DrawString("SISTEMA DE VENDAS", fontDestaque, Brushes.DarkRed, 100, 30);
                g.DrawString("Pedido número: " + UltimoId, fontDestaque, Brushes.DarkRed, 100, 50);

                // Posicionando o nome do cliente
                g.DrawString("Cliente: " + cbbCliente.Text, fontData, Brushes.Black, 40, 90);
                // Posicionando a data
                g.DrawString("Data: " + lblData.Text, fontData, Brushes.Black, 40, 110);

                // Criar uma linha divisória
                Pen divisoria = new Pen(Color.Black);
                g.DrawLine(divisoria, 40, 140, 800, 140);

                // Posicionar os cabeçalhos
                g.DrawString("Código", fontDestaque, Brushes.Black, 40, 160);
                g.DrawString("Produto", fontDestaque, Brushes.Black, 140, 160);
                g.DrawString("Qtde", fontDestaque, Brushes.Black, 480, 160);
                g.DrawString("Valor", fontDestaque, Brushes.Black, 580, 160);
                g.DrawString("Subtotal", fontDestaque, Brushes.Black, 700, 160);

                // variável para os conteúdos das próximas linhas
                int linha = 190;

                // Laço para carregar os prosutos do DataGrid
                for (int i = 0; i < dgvItens.RowCount; i++)
                {
                    string Produto = dgvItens.Rows[i].Cells[1].Value.ToString();
                    if(Produto.Length > 35)
                    {
                        Produto = Produto.Substring(0, 35) + "...";
                    }
                    // Definir os alinhamentos
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Far;

                    // Impressão do conteúdo do DataGrid
                    g.DrawString(Convert.ToString(dgvItens.Rows[i].Cells[0].Value), fontPadrao, Brushes.Black, 60, linha);
                    g.DrawString(Produto, fontPadrao, Brushes.Black, 140, linha);
                    g.DrawString(Convert.ToString(dgvItens.Rows[i].Cells[2].Value), fontPadrao, Brushes.Black, 500, linha);
                    g.DrawString(Convert.ToString(dgvItens.Rows[i].Cells[3].Value), fontPadrao, Brushes.Black, 640, linha, stringFormat);
                    g.DrawString(Convert.ToString(dgvItens.Rows[i].Cells[4].Value), fontPadrao, Brushes.Black, 788, linha, stringFormat);

                    // Incrementando a linha
                    linha += 25;
                }

                // Linha divisória antes do total
                g.DrawLine(divisoria, 40, (linha + 10), 800, (linha + 10));

                // Imprimir o total
                g.DrawString("Total", fontDestaque, Brushes.DarkRed, 580, linha + 20);
                g.DrawString(lblTotal.Text, fontDestaque, Brushes.DarkRed, 700, linha + 20);
            }
        }

        private void dgvPedidos_Click(object sender, EventArgs e)
        {
            dgvPedidos.DefaultCellStyle.SelectionBackColor = Color.Tomato;
            mostraPedido();
            toolStripExcluir.Visible = true;
            toolStripSalvar.Enabled = false;
            toolStripImprimir.Visible = true;
        }

        private void mostraPedido()
        {
            if (dgvPedidos.SelectedRows.Count > 0)
            {
                toolStripLimpar.PerformClick();
                for(int i = 0; i < dgvItens.RowCount; i++)
                {
                    dgvItens.Rows[i].DataGridView.Columns.Clear();
                }
                dgvItens.DataSource = Pedido.buscarPorId(int.Parse(dgvPedidos.SelectedRows[0].Cells[0].Value.ToString()));
                dgvItens.Columns[0].HeaderText = "Código";
                dgvItens.Columns[1].HeaderText = "Produto";
                dgvItens.Columns[2].HeaderText = "Qtde";
                dgvItens.Columns[3].HeaderText = "Valor";
                dgvItens.Columns[4].HeaderText = "Subtotal";
                dgvItens.Columns[5].Visible = false;
                dgvItens.Columns[6].Visible = false;
                dgvItens.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvItens.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvItens.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                lblData.Text = dgvPedidos.SelectedRows[0].Cells[3].Value.ToString();
                lblTotal.Text = dgvPedidos.SelectedRows[0].Cells[4].Value.ToString();
                cbbCliente.SelectedValue = dgvPedidos.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        private void toolStripLimpar_Click(object sender, EventArgs e)
        {
            cbbCliente.SelectedIndex = -1;
            cbbProduto.SelectedIndex = -1;
            txbId.Clear();
            txbPreco.Clear();
            mskQtde.Clear();
            lblData.Text = DateTime.Now.ToString();
            lblTotal.Text = string.Empty;
            toolStripExcluir.Visible = false;
            toolStripSalvar.Enabled = true;
            toolStripImprimir.Visible = false;
            for(int i = 0; i < dgvItens.RowCount; i++)
            {
                dgvItens.Rows[i].DataGridView.Columns.Clear();
            }
            cbbCliente.Focus();
            dgvItens.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue;
        }

        private void toolStripExcluir_Click(object sender, EventArgs e)
        {
            DialogResult excluir = MessageBox.Show("Deseja excluir esse pedido?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(excluir == DialogResult.Yes)
            {
                ItensPedido itens = new ItensPedido(int.Parse(dgvPedidos.SelectedRows[0].Cells[0].Value.ToString()));
                itens.excluiItensPedido();

                Pedido pedido = new Pedido(int.Parse(dgvPedidos.SelectedRows[0].Cells[0].Value.ToString()));
                pedido.excluiPedido();

                for(int i = 0; i < dgvItens.RowCount; i++)
                {
                    // Repor quantidade de cada produto
                    Produto repor = new Produto(Convert.ToInt32(dgvItens.Rows[i].Cells[0].Value),
                                                Convert.ToInt32(dgvItens.Rows[i].Cells[2].Value),
                                                1);
                    repor.reporProdutos();
                }

                toolStripLimpar.PerformClick();
                dgvPedidos.DataSource = Pedido.buscarTodosPedidos();

                // Atualizar o combobox dos produtos
                cbbProduto.DataSource = Produto.buscarTodosProdutos();
                cbbProduto.DisplayMember = "nome";
                cbbProduto.ValueMember = "id_produto";
                cbbProduto.SelectedIndex = -1;
            }
        }
    }
}
