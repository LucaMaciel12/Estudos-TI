namespace _09_CadastroPessoas.Telas
{
    partial class frmUsuarios
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
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolAlterar = new System.Windows.Forms.ToolStripButton();
            this.toolExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolTrocaSenha = new System.Windows.Forms.ToolStripButton();
            this.grbCadastro = new System.Windows.Forms.GroupBox();
            this.txbLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbNivel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBusca = new System.Windows.Forms.Button();
            this.txbBusca = new System.Windows.Forms.TextBox();
            this.cbbBusca = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.grbCadastro.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToOrderColumns = true;
            this.dgvUsuarios.AllowUserToResizeColumns = false;
            this.dgvUsuarios.AllowUserToResizeRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(12, 247);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(292, 105);
            this.dgvUsuarios.TabIndex = 6;
            this.dgvUsuarios.Click += new System.EventHandler(this.dgvUsuarios_Click);
            this.dgvUsuarios.DoubleClick += new System.EventHandler(this.dgvUsuarios_DoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSalvar,
            this.toolAlterar,
            this.toolExcluir,
            this.toolCancelar,
            this.toolTrocaSenha});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(447, 54);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
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
            this.toolSalvar.Click += new System.EventHandler(this.toolSalvar_Click);
            // 
            // toolAlterar
            // 
            this.toolAlterar.Enabled = false;
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
            this.toolExcluir.Enabled = false;
            this.toolExcluir.Image = global::_09_CadastroPessoas.Properties.Resources.delete_32;
            this.toolExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExcluir.Name = "toolExcluir";
            this.toolExcluir.Size = new System.Drawing.Size(45, 51);
            this.toolExcluir.Text = "excluir";
            this.toolExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolExcluir.Click += new System.EventHandler(this.toolExcluir_Click);
            // 
            // toolCancelar
            // 
            this.toolCancelar.Image = global::_09_CadastroPessoas.Properties.Resources.cancel_32;
            this.toolCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancelar.Name = "toolCancelar";
            this.toolCancelar.Size = new System.Drawing.Size(57, 51);
            this.toolCancelar.Text = "Cancelar";
            this.toolCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolCancelar.Visible = false;
            this.toolCancelar.Click += new System.EventHandler(this.toolCancelar_Click);
            // 
            // toolTrocaSenha
            // 
            this.toolTrocaSenha.Image = global::_09_CadastroPessoas.Properties.Resources.login_32;
            this.toolTrocaSenha.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolTrocaSenha.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTrocaSenha.Name = "toolTrocaSenha";
            this.toolTrocaSenha.Size = new System.Drawing.Size(78, 51);
            this.toolTrocaSenha.Text = "Trocar senha";
            this.toolTrocaSenha.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTrocaSenha.Click += new System.EventHandler(this.toolTrocaSenha_Click);
            // 
            // grbCadastro
            // 
            this.grbCadastro.Controls.Add(this.txbLogin);
            this.grbCadastro.Controls.Add(this.label4);
            this.grbCadastro.Controls.Add(this.cbbNivel);
            this.grbCadastro.Controls.Add(this.label5);
            this.grbCadastro.Controls.Add(this.txbEmail);
            this.grbCadastro.Controls.Add(this.label3);
            this.grbCadastro.Controls.Add(this.txbNome);
            this.grbCadastro.Controls.Add(this.label2);
            this.grbCadastro.Controls.Add(this.txbId);
            this.grbCadastro.Controls.Add(this.label1);
            this.grbCadastro.Location = new System.Drawing.Point(12, 57);
            this.grbCadastro.Name = "grbCadastro";
            this.grbCadastro.Size = new System.Drawing.Size(292, 175);
            this.grbCadastro.TabIndex = 8;
            this.grbCadastro.TabStop = false;
            this.grbCadastro.Text = "Cadastro";
            // 
            // txbLogin
            // 
            this.txbLogin.Location = new System.Drawing.Point(48, 106);
            this.txbLogin.Name = "txbLogin";
            this.txbLogin.Size = new System.Drawing.Size(163, 20);
            this.txbLogin.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Login";
            // 
            // cbbNivel
            // 
            this.cbbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNivel.FormattingEnabled = true;
            this.cbbNivel.Items.AddRange(new object[] {
            "Administrador",
            "Comum"});
            this.cbbNivel.Location = new System.Drawing.Point(48, 134);
            this.cbbNivel.Name = "cbbNivel";
            this.cbbNivel.Size = new System.Drawing.Size(99, 21);
            this.cbbNivel.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nível";
            // 
            // txbEmail
            // 
            this.txbEmail.Location = new System.Drawing.Point(48, 80);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(222, 20);
            this.txbEmail.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Email";
            // 
            // txbNome
            // 
            this.txbNome.Location = new System.Drawing.Point(48, 54);
            this.txbNome.Name = "txbNome";
            this.txbNome.Size = new System.Drawing.Size(222, 20);
            this.txbNome.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome";
            // 
            // txbId
            // 
            this.txbId.Enabled = false;
            this.txbId.Location = new System.Drawing.Point(48, 28);
            this.txbId.Name = "txbId";
            this.txbId.Size = new System.Drawing.Size(69, 20);
            this.txbId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBusca);
            this.groupBox4.Controls.Add(this.txbBusca);
            this.groupBox4.Controls.Add(this.cbbBusca);
            this.groupBox4.Location = new System.Drawing.Point(320, 57);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(112, 139);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Buscar por...";
            // 
            // btnBusca
            // 
            this.btnBusca.Location = new System.Drawing.Point(11, 97);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(87, 23);
            this.btnBusca.TabIndex = 2;
            this.btnBusca.Text = "Buscar";
            this.btnBusca.UseVisualStyleBackColor = true;
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // txbBusca
            // 
            this.txbBusca.Location = new System.Drawing.Point(11, 61);
            this.txbBusca.Name = "txbBusca";
            this.txbBusca.Size = new System.Drawing.Size(87, 20);
            this.txbBusca.TabIndex = 1;
            // 
            // cbbBusca
            // 
            this.cbbBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBusca.FormattingEnabled = true;
            this.cbbBusca.Items.AddRange(new object[] {
            "Tudo",
            "Id",
            "Nome",
            "Email",
            "Desativados"});
            this.cbbBusca.Location = new System.Drawing.Point(11, 23);
            this.cbbBusca.Name = "cbbBusca";
            this.cbbBusca.Size = new System.Drawing.Size(87, 21);
            this.cbbBusca.TabIndex = 0;
            this.cbbBusca.DropDownClosed += new System.EventHandler(this.cbbBusca_DropDownClosed);
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 375);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grbCadastro);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvUsuarios);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de usuários";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grbCadastro.ResumeLayout(false);
            this.grbCadastro.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSalvar;
        private System.Windows.Forms.ToolStripButton toolAlterar;
        private System.Windows.Forms.ToolStripButton toolExcluir;
        private System.Windows.Forms.ToolStripButton toolCancelar;
        private System.Windows.Forms.ToolStripButton toolTrocaSenha;
        private System.Windows.Forms.GroupBox grbCadastro;
        private System.Windows.Forms.ComboBox cbbNivel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBusca;
        private System.Windows.Forms.TextBox txbBusca;
        private System.Windows.Forms.ComboBox cbbBusca;
    }
}