namespace ConsultaVendaFirebird
{
    partial class TestePopularCombo
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.Dados = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDiferenca = new System.Windows.Forms.TextBox();
            this.txtTotalFirebird = new System.Windows.Forms.TextBox();
            this.txtTotalRetail = new System.Windows.Forms.TextBox();
            this.lblDiferenca = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalFirebird = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalRetail = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVerNaoIntegrados = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Dados.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(331, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(371, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SeaGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Honeydew;
            this.button1.Location = new System.Drawing.Point(12, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(987, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Consultar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(283, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loja:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 324);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(987, 77);
            this.dataGridView1.TabIndex = 1;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox1.Location = new System.Drawing.Point(371, 17);
            this.maskedTextBox1.Mask = "00,00,0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(99, 29);
            this.maskedTextBox1.TabIndex = 1;
            this.maskedTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox1_KeyDown);
            // 
            // Dados
            // 
            this.Dados.BackColor = System.Drawing.Color.Transparent;
            this.Dados.Controls.Add(this.label5);
            this.Dados.Controls.Add(this.maskedTextBox2);
            this.Dados.Controls.Add(this.label2);
            this.Dados.Controls.Add(this.maskedTextBox1);
            this.Dados.Controls.Add(this.label1);
            this.Dados.Controls.Add(this.comboBox1);
            this.Dados.Location = new System.Drawing.Point(12, 11);
            this.Dados.Name = "Dados";
            this.Dados.Size = new System.Drawing.Size(987, 113);
            this.Dados.TabIndex = 0;
            this.Dados.TabStop = false;
            this.Dados.Text = "Dados";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(518, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Até";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox2.Location = new System.Drawing.Point(560, 16);
            this.maskedTextBox2.Mask = "00,00,0000";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(99, 29);
            this.maskedTextBox2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(329, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "De";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtDiferenca);
            this.groupBox2.Controls.Add(this.txtTotalFirebird);
            this.groupBox2.Controls.Add(this.txtTotalRetail);
            this.groupBox2.Controls.Add(this.lblDiferenca);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblTotalFirebird);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblTotalRetail);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 171);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 122);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Totais";
            // 
            // txtDiferenca
            // 
            this.txtDiferenca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiferenca.Location = new System.Drawing.Point(112, 67);
            this.txtDiferenca.Name = "txtDiferenca";
            this.txtDiferenca.ReadOnly = true;
            this.txtDiferenca.Size = new System.Drawing.Size(129, 22);
            this.txtDiferenca.TabIndex = 2;
            // 
            // txtTotalFirebird
            // 
            this.txtTotalFirebird.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalFirebird.Location = new System.Drawing.Point(112, 45);
            this.txtTotalFirebird.Name = "txtTotalFirebird";
            this.txtTotalFirebird.ReadOnly = true;
            this.txtTotalFirebird.Size = new System.Drawing.Size(129, 22);
            this.txtTotalFirebird.TabIndex = 1;
            // 
            // txtTotalRetail
            // 
            this.txtTotalRetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRetail.Location = new System.Drawing.Point(112, 23);
            this.txtTotalRetail.Name = "txtTotalRetail";
            this.txtTotalRetail.ReadOnly = true;
            this.txtTotalRetail.Size = new System.Drawing.Size(129, 22);
            this.txtTotalRetail.TabIndex = 0;
            // 
            // lblDiferenca
            // 
            this.lblDiferenca.AutoSize = true;
            this.lblDiferenca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferenca.Location = new System.Drawing.Point(277, 60);
            this.lblDiferenca.Name = "lblDiferenca";
            this.lblDiferenca.Size = new System.Drawing.Size(61, 20);
            this.lblDiferenca.TabIndex = 12;
            this.lblDiferenca.Text = "R$0,00";
            this.lblDiferenca.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Diferença:";
            // 
            // lblTotalFirebird
            // 
            this.lblTotalFirebird.AutoSize = true;
            this.lblTotalFirebird.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFirebird.Location = new System.Drawing.Point(277, 40);
            this.lblTotalFirebird.Name = "lblTotalFirebird";
            this.lblTotalFirebird.Size = new System.Drawing.Size(61, 20);
            this.lblTotalFirebird.TabIndex = 2;
            this.lblTotalFirebird.Text = "R$0,00";
            this.lblTotalFirebird.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Total Firebird:";
            // 
            // lblTotalRetail
            // 
            this.lblTotalRetail.AutoSize = true;
            this.lblTotalRetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRetail.Location = new System.Drawing.Point(277, 20);
            this.lblTotalRetail.Name = "lblTotalRetail";
            this.lblTotalRetail.Size = new System.Drawing.Size(61, 20);
            this.lblTotalRetail.TabIndex = 1;
            this.lblTotalRetail.Text = "R$0,00";
            this.lblTotalRetail.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total Retail:";
            // 
            // btnVerNaoIntegrados
            // 
            this.btnVerNaoIntegrados.BackColor = System.Drawing.Color.SeaGreen;
            this.btnVerNaoIntegrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerNaoIntegrados.ForeColor = System.Drawing.Color.Honeydew;
            this.btnVerNaoIntegrados.Location = new System.Drawing.Point(820, 284);
            this.btnVerNaoIntegrados.Name = "btnVerNaoIntegrados";
            this.btnVerNaoIntegrados.Size = new System.Drawing.Size(179, 34);
            this.btnVerNaoIntegrados.TabIndex = 10;
            this.btnVerNaoIntegrados.Text = "Ver não integrados";
            this.btnVerNaoIntegrados.UseVisualStyleBackColor = false;
            this.btnVerNaoIntegrados.Click += new System.EventHandler(this.btnVerNaoIntegrados_Click);
            // 
            // TestePopularCombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = global::ConsultaVendaFirebird.Properties.Resources.fundoLogin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1005, 577);
            this.Controls.Add(this.btnVerNaoIntegrados);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Dados);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "TestePopularCombo";
            this.Text = "Consulta Unica Por Loja";
            this.Load += new System.EventHandler(this.TestePopularCombo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Dados.ResumeLayout(false);
            this.Dados.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.GroupBox Dados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDiferenca;
        private System.Windows.Forms.TextBox txtTotalFirebird;
        private System.Windows.Forms.TextBox txtTotalRetail;
        private System.Windows.Forms.Label lblDiferenca;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalFirebird;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalRetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVerNaoIntegrados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
    }
}