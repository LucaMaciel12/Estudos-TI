namespace _06_Calendario
{
    partial class frmCalendario
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
            this.mthCalendario = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.txbData = new System.Windows.Forms.TextBox();
            this.lstCompromisso = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbId = new System.Windows.Forms.TextBox();
            this.txbCompromisso = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbDataInicio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbDataFim = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbHoraInicio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbHoraFim = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbLocal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mthCalendario
            // 
            this.mthCalendario.CalendarDimensions = new System.Drawing.Size(3, 1);
            this.mthCalendario.Location = new System.Drawing.Point(18, 49);
            this.mthCalendario.Name = "mthCalendario";
            this.mthCalendario.TabIndex = 0;
            this.mthCalendario.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mthCalendario_DateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Agenda de compromissos";
            // 
            // txbData
            // 
            this.txbData.Location = new System.Drawing.Point(607, 14);
            this.txbData.Name = "txbData";
            this.txbData.Size = new System.Drawing.Size(100, 20);
            this.txbData.TabIndex = 2;
            // 
            // lstCompromisso
            // 
            this.lstCompromisso.FormattingEnabled = true;
            this.lstCompromisso.Location = new System.Drawing.Point(23, 223);
            this.lstCompromisso.Name = "lstCompromisso";
            this.lstCompromisso.Size = new System.Drawing.Size(684, 82);
            this.lstCompromisso.TabIndex = 3;
            this.lstCompromisso.SelectedIndexChanged += new System.EventHandler(this.lstCompromisso_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID:";
            // 
            // txbId
            // 
            this.txbId.Enabled = false;
            this.txbId.Location = new System.Drawing.Point(26, 332);
            this.txbId.Name = "txbId";
            this.txbId.Size = new System.Drawing.Size(100, 20);
            this.txbId.TabIndex = 5;
            // 
            // txbCompromisso
            // 
            this.txbCompromisso.Location = new System.Drawing.Point(143, 332);
            this.txbCompromisso.Name = "txbCompromisso";
            this.txbCompromisso.Size = new System.Drawing.Size(341, 20);
            this.txbCompromisso.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Compromisso:";
            // 
            // txbDataInicio
            // 
            this.txbDataInicio.Location = new System.Drawing.Point(26, 377);
            this.txbDataInicio.Name = "txbDataInicio";
            this.txbDataInicio.Size = new System.Drawing.Size(100, 20);
            this.txbDataInicio.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Data início:";
            // 
            // txbDataFim
            // 
            this.txbDataFim.Location = new System.Drawing.Point(143, 377);
            this.txbDataFim.Name = "txbDataFim";
            this.txbDataFim.Size = new System.Drawing.Size(100, 20);
            this.txbDataFim.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 361);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Data fim:";
            // 
            // txbHoraInicio
            // 
            this.txbHoraInicio.Location = new System.Drawing.Point(264, 377);
            this.txbHoraInicio.Name = "txbHoraInicio";
            this.txbHoraInicio.Size = new System.Drawing.Size(100, 20);
            this.txbHoraInicio.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(261, 361);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Hora início:";
            // 
            // txbHoraFim
            // 
            this.txbHoraFim.Location = new System.Drawing.Point(384, 377);
            this.txbHoraFim.Name = "txbHoraFim";
            this.txbHoraFim.Size = new System.Drawing.Size(100, 20);
            this.txbHoraFim.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(381, 361);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Hora fim:";
            // 
            // txbLocal
            // 
            this.txbLocal.Location = new System.Drawing.Point(26, 424);
            this.txbLocal.Name = "txbLocal";
            this.txbLocal.Size = new System.Drawing.Size(458, 20);
            this.txbLocal.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 408);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Local:";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(527, 328);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 46);
            this.btnLimpar.TabIndex = 18;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(632, 328);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(75, 46);
            this.btnCadastrar.TabIndex = 19;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Location = new System.Drawing.Point(527, 398);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 46);
            this.btnAlterar.TabIndex = 20;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Location = new System.Drawing.Point(632, 398);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 46);
            this.btnExcluir.TabIndex = 21;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // frmCalendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 457);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.txbLocal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txbHoraFim);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbHoraInicio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbDataFim);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbDataInicio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbCompromisso);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstCompromisso);
            this.Controls.Add(this.txbData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mthCalendario);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCalendario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendário de compromissos";
            this.Load += new System.EventHandler(this.frmCalendario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mthCalendario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbData;
        private System.Windows.Forms.ListBox lstCompromisso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.TextBox txbCompromisso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbDataInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbDataFim;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbHoraInicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbHoraFim;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbLocal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
    }
}

