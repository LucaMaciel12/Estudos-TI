using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08_EnviaEmail
{
    public partial class frmEnviaEmail : Form
    {
        public frmEnviaEmail()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                try
                {
                    btnEnviar.Text = "Aguarde...";
                    btnEnviar.Enabled = false;
                    MailMessage mensagem = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    mensagem.From = new MailAddress("shefarolbi@gmail.com", "Fábio");
                    mensagem.To.Add(txbPara.Text);
                    mensagem.Subject = (txbAssunto.Text);
                    mensagem.Body = (txbMensagem.Text);
                    mensagem.Priority = MailPriority.Normal;

                    // Informações do Gmail
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com";

                    // Na linha abaixo onde está o txbcodigo.text você
                    // coloca sua senha de app do Gamil
                    smtp.Credentials = new NetworkCredential("shefarolbi@gmail.com", txbCodigo.Text);
                    smtp.Send(mensagem);

                    MessageBox.Show("Email enviado", "Aviso", MessageBoxButtons.OK, 
                        MessageBoxIcon.Exclamation);
                    txbPara.Clear();
                    txbAssunto.Clear();
                    txbMensagem.Clear();
                    txbPara.Focus();
                    btnEnviar.Enabled = true;
                    btnEnviar.Text = "Enviar";

                }
                catch (Exception)
               
                {

                    throw;
                }
            }
        }


        private bool verificaCampos()
        {
            if(txbPara.Text == string.Empty)
            {
                MessageBox.Show("Digite o destinatário",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbPara.Focus();
                return false;
            }
            if (txbAssunto.Text == string.Empty)
            {
                MessageBox.Show("Digite o assunto",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbAssunto.Focus();
                return false;
            }
            if (txbMensagem.Text == string.Empty)
            {
                MessageBox.Show("Digite a mensagem",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbMensagem.Focus();
                return false;
            }
            return true;
        }
    }
}
