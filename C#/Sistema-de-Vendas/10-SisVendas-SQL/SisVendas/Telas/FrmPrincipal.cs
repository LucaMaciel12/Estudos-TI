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
    public partial class FrmPrincipal : Form
    {
        Usuario usuarioLogado = new Usuario();
        public FrmPrincipal(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }

        private void menuCliente_Click(object sender, EventArgs e)
        {
            FrmCliente TC = new FrmCliente(usuarioLogado);
            TC.ShowDialog();
        }

        private void menuProduto_Click(object sender, EventArgs e)
        {
            FrmProduto TP = new FrmProduto(usuarioLogado);
            TP.ShowDialog();
        }

        private void menuUsuario_Click(object sender, EventArgs e)
        {
            FrmUsuario TU = new FrmUsuario(usuarioLogado);
            TU.ShowDialog();
        }

        private void alterarSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAlteraSenha AS = new FrmAlteraSenha(usuarioLogado);
            AS.ShowDialog();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Manual.pdf");
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVenda TV = new FrmVenda(usuarioLogado);
            TV.ShowDialog();
        }
    }
}
