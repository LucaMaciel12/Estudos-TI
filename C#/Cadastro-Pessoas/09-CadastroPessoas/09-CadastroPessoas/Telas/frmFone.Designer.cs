namespace _09_CadastroPessoas.Telas
{
    partial class frmFone
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
            this.toolLimpar = new System.Windows.Forms.ToolStripButton();
            this.toolSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolAlterar = new System.Windows.Forms.ToolStripButton();
            this.toolExcluir = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mskFone = new System.Windows.Forms.MaskedTextBox();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLimpar,
            this.toolSalvar,
            this.toolAlterar,
            this.toolExcluir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(228, 54);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolLimpar
            // 
            this.toolLimpar.Image = global::_09_CadastroPessoas.Properties.Resources.limpar_32;
            this.toolLimpar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolLimpar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLimpar.Name = "toolLimpar";
            this.toolLimpar.Size = new System.Drawing.Size(48, 51);
            this.toolLimpar.Text = "Limpar";
            this.toolLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolLimpar.Click += new System.EventHandler(this.toolLimpar_Click);
            // 
            // toolSalvar
            // 
            this.toolSalvar.Image = global::_09_CadastroPessoas.Properties.Resources.save_32;
            this.toolSalvar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSalvar.Name = "toolSalvar";
            this.toolSalvar.Size = new System.Drawing.Size(42, 51);
            this.toolSalvar.Text = "Salvar";
            this.toolSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolSalvar.Visible = false;
            this.toolSalvar.Click += new System.EventHandler(this.toolSalvar_Click);
            // 
            // toolAlterar
            // 
            this.toolAlterar.Image = global::_09_CadastroPessoas.Properties.Resources.update_321;
            this.toolAlterar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolAlterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAlterar.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.toolAlterar.Name = "toolAlterar";
            this.toolAlterar.Size = new System.Drawing.Size(46, 51);
            this.toolAlterar.Text = "Alterar";
            this.toolAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolAlterar.Click += new System.EventHandler(this.toolAlterar_Click);
            // 
            // toolExcluir
            // 
            this.toolExcluir.Image = global::_09_CadastroPessoas.Properties.Resources.delete_32;
            this.toolExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExcluir.Name = "toolExcluir";
            this.toolExcluir.Size = new System.Drawing.Size(45, 51);
            this.toolExcluir.Text = "excluir";
            this.toolExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolExcluir.Click += new System.EventHandler(this.toolExcluir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mskFone);
            this.groupBox1.Location = new System.Drawing.Point(12, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fone";
            // 
            // mskFone
            // 
            this.mskFone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskFone.Location = new System.Drawing.Point(18, 38);
            this.mskFone.Mask = "(00) 00000-0000";
            this.mskFone.Name = "mskFone";
            this.mskFone.Size = new System.Drawing.Size(158, 30);
            this.mskFone.TabIndex = 0;
            // 
            // frmFone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 176);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar fone";
            this.Load += new System.EventHandler(this.frmFone_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSalvar;
        private System.Windows.Forms.ToolStripButton toolAlterar;
        private System.Windows.Forms.ToolStripButton toolExcluir;
        private System.Windows.Forms.ToolStripButton toolLimpar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox mskFone;
    }
}