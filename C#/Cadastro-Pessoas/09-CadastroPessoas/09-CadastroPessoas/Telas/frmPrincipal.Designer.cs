namespace _09_CadastroPessoas.Telas
{
    partial class frmPrincipal
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
            this.toolSalvar = new System.Windows.Forms.ToolStripButton();
            this.toolAlterar = new System.Windows.Forms.ToolStripButton();
            this.toolAlterarFoto = new System.Windows.Forms.ToolStripButton();
            this.toolExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolUsuarios = new System.Windows.Forms.ToolStripButton();
            this.toolCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolTrocaSenha = new System.Windows.Forms.ToolStripButton();
            this.grbCadastro = new System.Windows.Forms.GroupBox();
            this.btnFoto = new System.Windows.Forms.Button();
            this.txbFoto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbSexo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpNascimento = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.mskFone = new System.Windows.Forms.MaskedTextBox();
            this.grbFoto = new System.Windows.Forms.GroupBox();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBusca = new System.Windows.Forms.Button();
            this.txbBusca = new System.Windows.Forms.TextBox();
            this.cbbBusca = new System.Windows.Forms.ComboBox();
            this.dgvPessoas = new System.Windows.Forms.DataGridView();
            this.dgvFones = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.grbCadastro.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grbFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPessoas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFones)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSalvar,
            this.toolAlterar,
            this.toolAlterarFoto,
            this.toolExcluir,
            this.toolUsuarios,
            this.toolCancelar,
            this.toolTrocaSenha});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(583, 54);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "+";
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
            // toolAlterarFoto
            // 
            this.toolAlterarFoto.Image = global::_09_CadastroPessoas.Properties.Resources.update_321;
            this.toolAlterarFoto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolAlterarFoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAlterarFoto.Name = "toolAlterarFoto";
            this.toolAlterarFoto.Size = new System.Drawing.Size(67, 51);
            this.toolAlterarFoto.Text = "Muda foto";
            this.toolAlterarFoto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolAlterarFoto.Visible = false;
            this.toolAlterarFoto.Click += new System.EventHandler(this.toolAlterarFoto_Click);
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
            // toolUsuarios
            // 
            this.toolUsuarios.Image = global::_09_CadastroPessoas.Properties.Resources.user_32;
            this.toolUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUsuarios.Name = "toolUsuarios";
            this.toolUsuarios.Size = new System.Drawing.Size(56, 51);
            this.toolUsuarios.Text = "Usuários";
            this.toolUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolUsuarios.Click += new System.EventHandler(this.toolUsuarios_Click);
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
            this.grbCadastro.Controls.Add(this.btnFoto);
            this.grbCadastro.Controls.Add(this.txbFoto);
            this.grbCadastro.Controls.Add(this.label6);
            this.grbCadastro.Controls.Add(this.cbbSexo);
            this.grbCadastro.Controls.Add(this.label5);
            this.grbCadastro.Controls.Add(this.dtpNascimento);
            this.grbCadastro.Controls.Add(this.label4);
            this.grbCadastro.Controls.Add(this.txbEmail);
            this.grbCadastro.Controls.Add(this.label3);
            this.grbCadastro.Controls.Add(this.txbNome);
            this.grbCadastro.Controls.Add(this.label2);
            this.grbCadastro.Controls.Add(this.txbId);
            this.grbCadastro.Controls.Add(this.label1);
            this.grbCadastro.Location = new System.Drawing.Point(12, 57);
            this.grbCadastro.Name = "grbCadastro";
            this.grbCadastro.Size = new System.Drawing.Size(292, 223);
            this.grbCadastro.TabIndex = 1;
            this.grbCadastro.TabStop = false;
            this.grbCadastro.Text = "Cadastro";
            // 
            // btnFoto
            // 
            this.btnFoto.Image = global::_09_CadastroPessoas.Properties.Resources.finder_16;
            this.btnFoto.Location = new System.Drawing.Point(242, 178);
            this.btnFoto.Name = "btnFoto";
            this.btnFoto.Size = new System.Drawing.Size(28, 28);
            this.btnFoto.TabIndex = 12;
            this.btnFoto.UseVisualStyleBackColor = true;
            this.btnFoto.Click += new System.EventHandler(this.btnFoto_Click);
            // 
            // txbFoto
            // 
            this.txbFoto.Enabled = false;
            this.txbFoto.Location = new System.Drawing.Point(10, 183);
            this.txbFoto.Name = "txbFoto";
            this.txbFoto.Size = new System.Drawing.Size(222, 20);
            this.txbFoto.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Foto";
            // 
            // cbbSexo
            // 
            this.cbbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSexo.FormattingEnabled = true;
            this.cbbSexo.Items.AddRange(new object[] {
            "Masculino",
            "Feminino",
            "Outro"});
            this.cbbSexo.Location = new System.Drawing.Point(171, 130);
            this.cbbSexo.Name = "cbbSexo";
            this.cbbSexo.Size = new System.Drawing.Size(99, 21);
            this.cbbSexo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Sexo";
            // 
            // dtpNascimento
            // 
            this.dtpNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNascimento.Location = new System.Drawing.Point(10, 132);
            this.dtpNascimento.Name = "dtpNascimento";
            this.dtpNascimento.Size = new System.Drawing.Size(98, 20);
            this.dtpNascimento.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data de nascimento";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAdicionar);
            this.groupBox2.Controls.Add(this.mskFone);
            this.groupBox2.Location = new System.Drawing.Point(310, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(138, 82);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fones";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(18, 48);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(96, 23);
            this.btnAdicionar.TabIndex = 1;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // mskFone
            // 
            this.mskFone.Location = new System.Drawing.Point(18, 22);
            this.mskFone.Mask = "(00) 00000-0000";
            this.mskFone.Name = "mskFone";
            this.mskFone.Size = new System.Drawing.Size(96, 20);
            this.mskFone.TabIndex = 0;
            // 
            // grbFoto
            // 
            this.grbFoto.Controls.Add(this.picFoto);
            this.grbFoto.Enabled = false;
            this.grbFoto.Location = new System.Drawing.Point(311, 145);
            this.grbFoto.Name = "grbFoto";
            this.grbFoto.Size = new System.Drawing.Size(137, 135);
            this.grbFoto.TabIndex = 3;
            this.grbFoto.TabStop = false;
            this.grbFoto.Text = "Foto";
            // 
            // picFoto
            // 
            this.picFoto.Location = new System.Drawing.Point(26, 24);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(78, 95);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 0;
            this.picFoto.TabStop = false;
            this.picFoto.DoubleClick += new System.EventHandler(this.picFoto_DoubleClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBusca);
            this.groupBox4.Controls.Add(this.txbBusca);
            this.groupBox4.Controls.Add(this.cbbBusca);
            this.groupBox4.Location = new System.Drawing.Point(455, 57);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(112, 139);
            this.groupBox4.TabIndex = 4;
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
            // dgvPessoas
            // 
            this.dgvPessoas.AllowUserToAddRows = false;
            this.dgvPessoas.AllowUserToDeleteRows = false;
            this.dgvPessoas.AllowUserToOrderColumns = true;
            this.dgvPessoas.AllowUserToResizeColumns = false;
            this.dgvPessoas.AllowUserToResizeRows = false;
            this.dgvPessoas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPessoas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPessoas.Location = new System.Drawing.Point(12, 291);
            this.dgvPessoas.Name = "dgvPessoas";
            this.dgvPessoas.ReadOnly = true;
            this.dgvPessoas.RowHeadersVisible = false;
            this.dgvPessoas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPessoas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPessoas.Size = new System.Drawing.Size(436, 105);
            this.dgvPessoas.TabIndex = 5;
            this.dgvPessoas.Click += new System.EventHandler(this.dgvPessoas_Click);
            this.dgvPessoas.DoubleClick += new System.EventHandler(this.dgvPessoas_DoubleClick);
            // 
            // dgvFones
            // 
            this.dgvFones.AllowUserToAddRows = false;
            this.dgvFones.AllowUserToDeleteRows = false;
            this.dgvFones.AllowUserToOrderColumns = true;
            this.dgvFones.AllowUserToResizeColumns = false;
            this.dgvFones.AllowUserToResizeRows = false;
            this.dgvFones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFones.Location = new System.Drawing.Point(455, 291);
            this.dgvFones.Name = "dgvFones";
            this.dgvFones.ReadOnly = true;
            this.dgvFones.RowHeadersVisible = false;
            this.dgvFones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvFones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFones.Size = new System.Drawing.Size(112, 105);
            this.dgvFones.TabIndex = 6;
            this.dgvFones.DoubleClick += new System.EventHandler(this.dgvFones_DoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(455, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Fones";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 410);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(583, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(118, 17);
            this.status.Text = "toolStripStatusLabel1";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 432);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvFones);
            this.Controls.Add(this.dgvPessoas);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grbFoto);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbCadastro);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de pessoas";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grbCadastro.ResumeLayout(false);
            this.grbCadastro.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grbFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPessoas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFones)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSalvar;
        private System.Windows.Forms.ToolStripButton toolAlterar;
        private System.Windows.Forms.ToolStripButton toolAlterarFoto;
        private System.Windows.Forms.ToolStripButton toolExcluir;
        private System.Windows.Forms.ToolStripButton toolUsuarios;
        private System.Windows.Forms.ToolStripButton toolCancelar;
        private System.Windows.Forms.ToolStripButton toolTrocaSenha;
        private System.Windows.Forms.GroupBox grbCadastro;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpNascimento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbSexo;
        private System.Windows.Forms.Button btnFoto;
        private System.Windows.Forms.TextBox txbFoto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox mskFone;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.GroupBox grbFoto;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbbBusca;
        private System.Windows.Forms.Button btnBusca;
        private System.Windows.Forms.TextBox txbBusca;
        private System.Windows.Forms.DataGridView dgvPessoas;
        private System.Windows.Forms.DataGridView dgvFones;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
    }
}