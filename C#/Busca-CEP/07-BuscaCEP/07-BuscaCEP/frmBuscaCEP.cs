using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07_BuscaCEP
{
    public partial class frmBuscaCEP : Form
    {
        public frmBuscaCEP()
        {
            InitializeComponent();
        }


        private void BuscaCep()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + mskCep.Text + "/json/");
                request.AllowAutoRedirect = false;
                HttpWebResponse ChecaServidor = (HttpWebResponse)request.GetResponse();

                if (ChecaServidor.StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show("Servidor indisponível", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; // Sai da rotina
                }

                using (Stream webStream = ChecaServidor.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            string response = responseReader.ReadToEnd();
                            response = Regex.Replace(response, "[{},]", string.Empty);
                            response = response.Replace("\"", "");

                            String[] substrings = response.Split('\n');

                            int cont = 0;
                            foreach (var substring in substrings)
                            {
                                if (cont == 1)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    if (valor[0] == "  erro")
                                    {
                                        MessageBox.Show("CEP não encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        mskCep.Focus();
                                        return;
                                    }
                                }

                                //Logradouro
                                if (cont == 2)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    txbLogradouro.Text = valor[1];
                                }

                                //Complemento
                                if (cont == 3)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    txbComplemento.Text = valor[1];
                                }

                                //Bairro
                                if (cont == 5)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    txbBairro.Text = valor[1];
                                }

                                //Localidade (Cidade)
                                if (cont == 6)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    txbCidade.Text = valor[1];
                                }

                                //Estado (UF)
                                if (cont == 7)
                                {
                                    string[] valor = substring.Split(":".ToCharArray());
                                    txbEstado.Text = valor[1];
                                }

                                cont++;
                            }
                        }
                        txbNumero.Focus();
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Atenção! Digite corretamente o CEP", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskCep.Focus();
            }
        }

        private void mskCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                BuscaCep();
            }
        }

        private void mskCep_Leave(object sender, EventArgs e)
        {
            BuscaCep();
        }
    }
}