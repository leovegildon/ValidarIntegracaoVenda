namespace ConsultaVendaFirebird
{
    partial class FormPai
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPai));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblBemVindo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblData = new System.Windows.Forms.Label();
            this.timerHoraExibicao = new System.Windows.Forms.Timer(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasFiscaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaEmMassaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.consultaÚnicaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaÚnicaPorLojaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaÚnicaPorLojaUFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaÚnicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detalheDaVendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviçosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1013, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.vendasFiscaisToolStripMenuItem,
            this.toolStripSeparator3,
            this.serviçosToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.sobreToolStripMenuItem_Click);
            // 
            // lblBemVindo
            // 
            this.lblBemVindo.AutoSize = true;
            this.lblBemVindo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblBemVindo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBemVindo.Location = new System.Drawing.Point(648, 5);
            this.lblBemVindo.Name = "lblBemVindo";
            this.lblBemVindo.Size = new System.Drawing.Size(55, 16);
            this.lblBemVindo.TabIndex = 3;
            this.lblBemVindo.Text = "Usuario";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(470, 5);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(123, 16);
            this.lblData.TabIndex = 8;
            this.lblData.Text = "00/00/0000 00:00:00";
            // 
            // timerHoraExibicao
            // 
            this.timerHoraExibicao.Tick += new System.EventHandler(this.timerHoraExibicao_Tick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pictureBox3.Image = global::ConsultaVendaFirebird.Properties.Resources._151770;
            this.pictureBox3.Location = new System.Drawing.Point(443, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::ConsultaVendaFirebird.Properties.Resources.fundoLogin1;
            this.pictureBox2.Location = new System.Drawing.Point(0, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1013, 636);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pictureBox1.Image = global::ConsultaVendaFirebird.Properties.Resources.user_default1;
            this.pictureBox1.Location = new System.Drawing.Point(620, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Image = global::ConsultaVendaFirebird.Properties.Resources.door_out;
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // vendasFiscaisToolStripMenuItem
            // 
            this.vendasFiscaisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaEmMassaToolStripMenuItem,
            this.toolStripSeparator2,
            this.consultaÚnicaToolStripMenuItem1,
            this.detalheDaVendaToolStripMenuItem});
            this.vendasFiscaisToolStripMenuItem.Image = global::ConsultaVendaFirebird.Properties.Resources.nfce;
            this.vendasFiscaisToolStripMenuItem.Name = "vendasFiscaisToolStripMenuItem";
            this.vendasFiscaisToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.vendasFiscaisToolStripMenuItem.Text = "Vendas Fiscais";
            this.vendasFiscaisToolStripMenuItem.Click += new System.EventHandler(this.vendasFiscaisToolStripMenuItem_Click);
            // 
            // consultaEmMassaToolStripMenuItem
            // 
            this.consultaEmMassaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultaEmMassaToolStripMenuItem.Image = global::ConsultaVendaFirebird.Properties.Resources.database_refresh;
            this.consultaEmMassaToolStripMenuItem.Name = "consultaEmMassaToolStripMenuItem";
            this.consultaEmMassaToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.consultaEmMassaToolStripMenuItem.Text = "Consulta em Massa";
            this.consultaEmMassaToolStripMenuItem.Click += new System.EventHandler(this.consultaEmMassaToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
            // 
            // consultaÚnicaToolStripMenuItem1
            // 
            this.consultaÚnicaToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaÚnicaPorLojaToolStripMenuItem,
            this.consultaÚnicaPorLojaUFToolStripMenuItem,
            this.consultaÚnicaToolStripMenuItem});
            this.consultaÚnicaToolStripMenuItem1.Image = global::ConsultaVendaFirebird.Properties.Resources.find;
            this.consultaÚnicaToolStripMenuItem1.Name = "consultaÚnicaToolStripMenuItem1";
            this.consultaÚnicaToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.consultaÚnicaToolStripMenuItem1.Text = "Consulta Única";
            // 
            // consultaÚnicaPorLojaToolStripMenuItem
            // 
            this.consultaÚnicaPorLojaToolStripMenuItem.Image = global::ConsultaVendaFirebird.Properties.Resources.book_open;
            this.consultaÚnicaPorLojaToolStripMenuItem.Name = "consultaÚnicaPorLojaToolStripMenuItem";
            this.consultaÚnicaPorLojaToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.consultaÚnicaPorLojaToolStripMenuItem.Text = "Consulta Única por Loja";
            this.consultaÚnicaPorLojaToolStripMenuItem.Click += new System.EventHandler(this.consultaÚnicaPorLojaToolStripMenuItem_Click_1);
            // 
            // consultaÚnicaPorLojaUFToolStripMenuItem
            // 
            this.consultaÚnicaPorLojaUFToolStripMenuItem.Image = global::ConsultaVendaFirebird.Properties.Resources.book_open;
            this.consultaÚnicaPorLojaUFToolStripMenuItem.Name = "consultaÚnicaPorLojaUFToolStripMenuItem";
            this.consultaÚnicaPorLojaUFToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.consultaÚnicaPorLojaUFToolStripMenuItem.Text = "Consulta Única por Loja [UF]";
            this.consultaÚnicaPorLojaUFToolStripMenuItem.Click += new System.EventHandler(this.consultaÚnicaPorLojaUFToolStripMenuItem_Click);
            // 
            // consultaÚnicaToolStripMenuItem
            // 
            this.consultaÚnicaToolStripMenuItem.Image = global::ConsultaVendaFirebird.Properties.Resources.find;
            this.consultaÚnicaToolStripMenuItem.Name = "consultaÚnicaToolStripMenuItem";
            this.consultaÚnicaToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.consultaÚnicaToolStripMenuItem.Text = "Consulta Única por Servidor";
            this.consultaÚnicaToolStripMenuItem.Click += new System.EventHandler(this.consultaÚnicaToolStripMenuItem_Click_1);
            // 
            // detalheDaVendaToolStripMenuItem
            // 
            this.detalheDaVendaToolStripMenuItem.Image = global::ConsultaVendaFirebird.Properties.Resources.book_open;
            this.detalheDaVendaToolStripMenuItem.Name = "detalheDaVendaToolStripMenuItem";
            this.detalheDaVendaToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.detalheDaVendaToolStripMenuItem.Text = "Detalhe da Venda";
            this.detalheDaVendaToolStripMenuItem.Click += new System.EventHandler(this.detalheDaVendaToolStripMenuItem_Click);
            // 
            // serviçosToolStripMenuItem
            // 
            this.serviçosToolStripMenuItem.Image = global::ConsultaVendaFirebird.Properties.Resources.find;
            this.serviçosToolStripMenuItem.Name = "serviçosToolStripMenuItem";
            this.serviçosToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.serviçosToolStripMenuItem.Text = "Serviços";
            this.serviçosToolStripMenuItem.Click += new System.EventHandler(this.serviçosToolStripMenuItem_Click);
            // 
            // FormPai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 660);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblBemVindo);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormPai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validador de Integração <Loja >> Retaguarda> ::: LE BISCUIT :::";
            this.Load += new System.EventHandler(this.FormPai_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.Label lblBemVindo;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem vendasFiscaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaEmMassaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaÚnicaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultaÚnicaPorLojaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaÚnicaPorLojaUFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaÚnicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detalheDaVendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviçosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Timer timerHoraExibicao;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}