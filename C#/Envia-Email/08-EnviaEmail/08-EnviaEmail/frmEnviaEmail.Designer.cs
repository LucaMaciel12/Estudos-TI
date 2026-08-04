namespace _08_EnviaEmail
{
    partial class frmEnviaEmail
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txbPara = new System.Windows.Forms.TextBox();
            this.txbAssunto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbMensagem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbCodigo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Para:";
            // 
            // txbPara
            // 
            this.txbPara.Location = new System.Drawing.Point(16, 48);
            this.txbPara.Name = "txbPara";
            this.txbPara.Size = new System.Drawing.Size(288, 20);
            this.txbPara.TabIndex = 1;
            // 
            // txbAssunto
            // 
            this.txbAssunto.Location = new System.Drawing.Point(333, 48);
            this.txbAssunto.Name = "txbAssunto";
            this.txbAssunto.Size = new System.Drawing.Size(288, 20);
            this.txbAssunto.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Assunto:";
            // 
            // txbMensagem
            // 
            this.txbMensagem.Location = new System.Drawing.Point(16, 100);
            this.txbMensagem.Multiline = true;
            this.txbMensagem.Name = "txbMensagem";
            this.txbMensagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbMensagem.Size = new System.Drawing.Size(288, 121);
            this.txbMensagem.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mensagem:";
            // 
            // txbCodigo
            // 
            this.txbCodigo.Location = new System.Drawing.Point(333, 117);
            this.txbCodigo.Name = "txbCodigo";
            this.txbCodigo.PasswordChar = '*';
            this.txbCodigo.Size = new System.Drawing.Size(288, 20);
            this.txbCodigo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Código";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(333, 167);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 54);
            this.btnEnviar.TabIndex = 8;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // frmEnviaEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 235);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txbCodigo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbMensagem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbAssunto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbPara);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEnviaEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviando email";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbPara;
        private System.Windows.Forms.TextBox txbAssunto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbMensagem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEnviar;
    }
}

