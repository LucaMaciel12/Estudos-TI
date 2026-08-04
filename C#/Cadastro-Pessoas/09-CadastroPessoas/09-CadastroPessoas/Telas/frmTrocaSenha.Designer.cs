namespace _09_CadastroPessoas.Telas
{
    partial class frmTrocaSenha
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAlterar = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbFrase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbRepitaSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbSenha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbSenhaAtual = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAlterar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(495, 54);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolAlterar
            // 
            this.toolAlterar.Image = global::_09_CadastroPessoas.Properties.Resources.update_32;
            this.toolAlterar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolAlterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAlterar.Name = "toolAlterar";
            this.toolAlterar.Size = new System.Drawing.Size(46, 51);
            this.toolAlterar.Text = "Alterar";
            this.toolAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolAlterar.Click += new System.EventHandler(this.toolAlterar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbFrase);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbRepitaSenha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txbSenha);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txbSenhaAtual);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 240);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Senha";
            // 
            // txbFrase
            // 
            this.txbFrase.Location = new System.Drawing.Point(25, 200);
            this.txbFrase.Name = "txbFrase";
            this.txbFrase.PasswordChar = '*';
            this.txbFrase.Size = new System.Drawing.Size(420, 20);
            this.txbFrase.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Digite a frase de segurança:";
            // 
            // txbRepitaSenha
            // 
            this.txbRepitaSenha.Location = new System.Drawing.Point(25, 148);
            this.txbRepitaSenha.Name = "txbRepitaSenha";
            this.txbRepitaSenha.PasswordChar = '*';
            this.txbRepitaSenha.Size = new System.Drawing.Size(204, 20);
            this.txbRepitaSenha.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Repita a nova senha:";
            // 
            // txbSenha
            // 
            this.txbSenha.Location = new System.Drawing.Point(25, 96);
            this.txbSenha.Name = "txbSenha";
            this.txbSenha.PasswordChar = '*';
            this.txbSenha.Size = new System.Drawing.Size(204, 20);
            this.txbSenha.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Digite a nova senha:";
            // 
            // txbSenhaAtual
            // 
            this.txbSenhaAtual.Location = new System.Drawing.Point(25, 50);
            this.txbSenhaAtual.Name = "txbSenhaAtual";
            this.txbSenhaAtual.PasswordChar = '*';
            this.txbSenhaAtual.Size = new System.Drawing.Size(204, 20);
            this.txbSenhaAtual.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Digite a senha atual:";
            // 
            // frmTrocaSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 337);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTrocaSenha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trocar senha";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolAlterar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbSenhaAtual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbFrase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbRepitaSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbSenha;
        private System.Windows.Forms.Label label2;
    }
}