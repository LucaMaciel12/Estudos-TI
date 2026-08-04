using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_GeradorDeSenhas
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            // Preenche o comprimento padrão
            txbComprimento.Text = "7";

            // Ativa os campos padrões
            chkMinusculas.Checked = true;
            chkMaiusculas.Checked = true;
            chkNumeros.Checked = true;
        }
    }
}
