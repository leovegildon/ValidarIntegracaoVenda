namespace ConsultaVendaFirebird
{
    partial class FormServicosMain
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
            this.Dados = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.maskedDataFim = new System.Windows.Forms.MaskedTextBox();
            this.checkBoxTodas = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboServico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedDataIni = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboLoja = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dataGridOperacoesNao = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerFatura = new System.ComponentModel.BackgroundWorker();
            this.backgroundRecarga = new System.ComponentModel.BackgroundWorker();
            this.Dados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOperacoesNao)).BeginInit();
            this.SuspendLayout();
            // 
            // Dados
            // 
            this.Dados.BackColor = System.Drawing.Color.Transparent;
            this.Dados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Dados.Controls.Add(this.progressBar1);
            this.Dados.Controls.Add(this.pictureBox1);
            this.Dados.Controls.Add(this.label7);
            this.Dados.Controls.Add(this.btnConsultar);
            this.Dados.Controls.Add(this.maskedDataFim);
            this.Dados.Controls.Add(this.checkBoxTodas);
            this.Dados.Controls.Add(this.label5);
            this.Dados.Controls.Add(this.comboServico);
            this.Dados.Controls.Add(this.label2);
            this.Dados.Controls.Add(this.maskedDataIni);
            this.Dados.Controls.Add(this.label1);
            this.Dados.Controls.Add(this.comboLoja);
            this.Dados.Location = new System.Drawing.Point(7, 12);
            this.Dados.Name = "Dados";
            this.Dados.Size = new System.Drawing.Size(986, 113);
            this.Dados.TabIndex = 8;
            this.Dados.TabStop = false;
            this.Dados.Text = "Dados";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(462, 28);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(102, 23);
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(703, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 67);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Até";
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.ForeColor = System.Drawing.Color.Honeydew;
            this.btnConsultar.Location = new System.Drawing.Point(795, 19);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(188, 88);
            this.btnConsultar.TabIndex = 9;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // maskedDataFim
            // 
            this.maskedDataFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedDataFim.Location = new System.Drawing.Point(56, 62);
            this.maskedDataFim.Mask = "00,00,0000";
            this.maskedDataFim.Name = "maskedDataFim";
            this.maskedDataFim.Size = new System.Drawing.Size(99, 29);
            this.maskedDataFim.TabIndex = 8;
            // 
            // checkBoxTodas
            // 
            this.checkBoxTodas.AutoSize = true;
            this.checkBoxTodas.Location = new System.Drawing.Point(642, 72);
            this.checkBoxTodas.Name = "checkBoxTodas";
            this.checkBoxTodas.Size = new System.Drawing.Size(56, 17);
            this.checkBoxTodas.TabIndex = 6;
            this.checkBoxTodas.Text = "Todas";
            this.checkBoxTodas.UseVisualStyleBackColor = true;
            this.checkBoxTodas.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(182, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Serviço:";
            // 
            // comboServico
            // 
            this.comboServico.FormattingEnabled = true;
            this.comboServico.Items.AddRange(new object[] {
            "RECARGA",
            "CARTÃO CONTEÚDO",
            "CARTÃO PRESENTE",
            "PGTO FATURA LB"});
            this.comboServico.Location = new System.Drawing.Point(253, 30);
            this.comboServico.Name = "comboServico";
            this.comboServico.Size = new System.Drawing.Size(203, 21);
            this.comboServico.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "De";
            // 
            // maskedDataIni
            // 
            this.maskedDataIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedDataIni.Location = new System.Drawing.Point(56, 27);
            this.maskedDataIni.Mask = "00,00,0000";
            this.maskedDataIni.Name = "maskedDataIni";
            this.maskedDataIni.Size = new System.Drawing.Size(99, 29);
            this.maskedDataIni.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(182, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loja:";
            this.label1.Visible = false;
            // 
            // comboLoja
            // 
            this.comboLoja.FormattingEnabled = true;
            this.comboLoja.Location = new System.Drawing.Point(253, 86);
            this.comboLoja.Name = "comboLoja";
            this.comboLoja.Size = new System.Drawing.Size(371, 21);
            this.comboLoja.TabIndex = 2;
            this.comboLoja.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.dataGridOperacoesNao);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(986, 443);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operações Não Intgradas";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ConsultaVendaFirebird.Properties.Resources.loading_gif_transparent_10;
            this.pictureBox2.Location = new System.Drawing.Point(336, 89);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(292, 247);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // dataGridOperacoesNao
            // 
            this.dataGridOperacoesNao.AllowUserToAddRows = false;
            this.dataGridOperacoesNao.AllowUserToDeleteRows = false;
            this.dataGridOperacoesNao.AllowUserToOrderColumns = true;
            this.dataGridOperacoesNao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOperacoesNao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridOperacoesNao.Location = new System.Drawing.Point(3, 17);
            this.dataGridOperacoesNao.Name = "dataGridOperacoesNao";
            this.dataGridOperacoesNao.ReadOnly = true;
            this.dataGridOperacoesNao.Size = new System.Drawing.Size(980, 423);
            this.dataGridOperacoesNao.TabIndex = 10;
            this.dataGridOperacoesNao.Visible = false;
            // 
            // backgroundWorkerFatura
            // 
            this.backgroundWorkerFatura.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFatura_DoWork);
            this.backgroundWorkerFatura.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerFatura_RunWorkerCompleted);
            // 
            // backgroundRecarga
            // 
            this.backgroundRecarga.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundRecarga_DoWork);
            this.backgroundRecarga.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundRecarga_ProgressChanged);
            this.backgroundRecarga.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundRecarga_RunWorkerCompleted);
            // 
            // FormServicosMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::ConsultaVendaFirebird.Properties.Resources.fundoLogin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1030, 586);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Dados);
            this.Name = "FormServicosMain";
            this.Text = "Análise de integração de Serviços";
            this.Load += new System.EventHandler(this.FormServicosMain_Load);
            this.Dados.ResumeLayout(false);
            this.Dados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOperacoesNao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Dados;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox maskedDataFim;
        private System.Windows.Forms.CheckBox checkBoxTodas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboServico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedDataIni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboLoja;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridOperacoesNao;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFatura;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.ComponentModel.BackgroundWorker backgroundRecarga;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}