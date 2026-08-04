namespace _01_ConversorDeMedidas
{
    partial class frmPrincipal
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
            this.label2 = new System.Windows.Forms.Label();
            this.txbCelsius = new System.Windows.Forms.TextBox();
            this.txbFahrenheit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTemperatura = new System.Windows.Forms.Button();
            this.txbCentimetros = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbResultado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rdbMilimetros = new System.Windows.Forms.RadioButton();
            this.rdbPolegadas = new System.Windows.Forms.RadioButton();
            this.txbKg = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbLibras = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPeso = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conversor de medidas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Digite os graus em Celsius";
            // 
            // txbCelsius
            // 
            this.txbCelsius.Location = new System.Drawing.Point(49, 107);
            this.txbCelsius.Name = "txbCelsius";
            this.txbCelsius.Size = new System.Drawing.Size(127, 20);
            this.txbCelsius.TabIndex = 2;
            // 
            // txbFahrenheit
            // 
            this.txbFahrenheit.Enabled = false;
            this.txbFahrenheit.Location = new System.Drawing.Point(49, 175);
            this.txbFahrenheit.Name = "txbFahrenheit";
            this.txbFahrenheit.Size = new System.Drawing.Size(127, 20);
            this.txbFahrenheit.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Graus em Fahrenheit";
            // 
            // btnTemperatura
            // 
            this.btnTemperatura.Location = new System.Drawing.Point(189, 133);
            this.btnTemperatura.Name = "btnTemperatura";
            this.btnTemperatura.Size = new System.Drawing.Size(75, 38);
            this.btnTemperatura.TabIndex = 5;
            this.btnTemperatura.Text = "Converter";
            this.btnTemperatura.UseVisualStyleBackColor = true;
            this.btnTemperatura.Click += new System.EventHandler(this.btnTemperatura_Click);
            // 
            // txbCentimetros
            // 
            this.txbCentimetros.Location = new System.Drawing.Point(49, 285);
            this.txbCentimetros.Name = "txbCentimetros";
            this.txbCentimetros.Size = new System.Drawing.Size(127, 20);
            this.txbCentimetros.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Digite a medida em CM";
            // 
            // txbResultado
            // 
            this.txbResultado.Location = new System.Drawing.Point(49, 344);
            this.txbResultado.Name = "txbResultado";
            this.txbResultado.Size = new System.Drawing.Size(127, 20);
            this.txbResultado.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Resultado";
            // 
            // rdbMilimetros
            // 
            this.rdbMilimetros.AutoSize = true;
            this.rdbMilimetros.Location = new System.Drawing.Point(189, 303);
            this.rdbMilimetros.Name = "rdbMilimetros";
            this.rdbMilimetros.Size = new System.Drawing.Size(71, 17);
            this.rdbMilimetros.TabIndex = 10;
            this.rdbMilimetros.TabStop = true;
            this.rdbMilimetros.Text = "Milimetros";
            this.rdbMilimetros.UseVisualStyleBackColor = true;
            this.rdbMilimetros.CheckedChanged += new System.EventHandler(this.rdbMilimetros_CheckedChanged);
            // 
            // rdbPolegadas
            // 
            this.rdbPolegadas.AutoSize = true;
            this.rdbPolegadas.Location = new System.Drawing.Point(189, 326);
            this.rdbPolegadas.Name = "rdbPolegadas";
            this.rdbPolegadas.Size = new System.Drawing.Size(75, 17);
            this.rdbPolegadas.TabIndex = 11;
            this.rdbPolegadas.TabStop = true;
            this.rdbPolegadas.Text = "Polegadas";
            this.rdbPolegadas.UseVisualStyleBackColor = true;
            this.rdbPolegadas.CheckedChanged += new System.EventHandler(this.rdbPolegadas_CheckedChanged);
            // 
            // txbKg
            // 
            this.txbKg.Location = new System.Drawing.Point(49, 450);
            this.txbKg.Name = "txbKg";
            this.txbKg.Size = new System.Drawing.Size(127, 20);
            this.txbKg.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 434);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Digite o peso em Kg";
            // 
            // txbLibras
            // 
            this.txbLibras.Enabled = false;
            this.txbLibras.Location = new System.Drawing.Point(49, 505);
            this.txbLibras.Name = "txbLibras";
            this.txbLibras.Size = new System.Drawing.Size(127, 20);
            this.txbLibras.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 489);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Peso em Libras";
            // 
            // btnPeso
            // 
            this.btnPeso.Location = new System.Drawing.Point(189, 464);
            this.btnPeso.Name = "btnPeso";
            this.btnPeso.Size = new System.Drawing.Size(75, 38);
            this.btnPeso.TabIndex = 16;
            this.btnPeso.Text = "Converter";
            this.btnPeso.UseVisualStyleBackColor = true;
            this.btnPeso.Click += new System.EventHandler(this.btnPeso_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 556);
            this.Controls.Add(this.btnPeso);
            this.Controls.Add(this.txbLibras);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbKg);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rdbPolegadas);
            this.Controls.Add(this.rdbMilimetros);
            this.Controls.Add(this.txbResultado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbCentimetros);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTemperatura);
            this.Controls.Add(this.txbFahrenheit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbCelsius);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conversor de medidas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbCelsius;
        private System.Windows.Forms.TextBox txbFahrenheit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTemperatura;
        private System.Windows.Forms.TextBox txbCentimetros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbResultado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdbMilimetros;
        private System.Windows.Forms.RadioButton rdbPolegadas;
        private System.Windows.Forms.TextBox txbKg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbLibras;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPeso;
    }
}

