using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

                /*
              `7MMF'      `7MM"""YMM    .g8""8q.   `7MMF'   `7MF'`7MM"""YMM    .g8"""bgd  `7MMF'`7MMF'      `7MM"""Yb.     .g8""8q.   
                MM          MM    `7  .dP'    `YM.   `MA     ,V    MM    `7  .dP'     `M    MM    MM          MM    `Yb. .dP'    `YM. 
                MM          MM   d    dM'      `MM    VM:   ,V     MM   d    dM'       `    MM    MM          MM     `Mb dM'      `MM 
                MM          MMmmMM    MM        MM     MM.  M'     MMmmMM    MM             MM    MM          MM      MM MM        MM 
                MM      ,   MM   Y  , MM.      ,MP     `MM A'      MM   Y  , MM.    `7MMF'  MM    MM      ,   MM     ,MP MM.      ,MP 
                MM     ,M   MM     ,M `Mb.    ,dP'      :MM;       MM     ,M `Mb.     MM    MM    MM     ,M   MM    ,dP' `Mb.    ,dP' 
              .JMMmmmmMMM .JMMmmmmMMM   `"bmmd"'         VF      .JMMmmmmMMM   `"bmmmdPY  .JMML..JMMmmmmMMM .JMMmmmdP'     `"bmmd"'   
                                                  ___   _        _                             
                                                 / __| (_)  ___ | |_   ___   _ __    __ _   ___
                                                 \__ \ | | (_-< |  _| / -_) | '  \  / _` | (_-<
                                                 |___/ |_| /__/  \__| \___| |_|_|_| \__,_| /__/*/

                //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                //                                 L E O V E G I L D O  S I S T E M A S 
                //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                //      S I S T E M A  V A L I D A D O R  D E  I N T E G R A Ç Ã O  -  L O J A S  L E  B I S C U I T 
                //Desenvolvido em: Março de 2018
                //Desenvolvedor: Leovegildo Neto
                //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

namespace ConsultaVendaFirebird
{
    public partial class FormPai : Form
    {
        public FormPai()
        {
            InitializeComponent();
        }


        public string nome = "Não Autenticado";
        public string usuarioLogado;
        public string hostName;
        string localBanco;
        private void consultaÚnicaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void abre_form_filho(Form formulario)
        {

            formulario.MdiParent = this;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.WindowState = FormWindowState.Maximized;
            formulario.Show();
        }

        private void consultaEmMassaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaGeral formConsultaGeral = new ConsultaGeral();
            abre_form_filho(formConsultaGeral);
            pictureBox2.Visible = false;

            //LOG DE ACESSO ///////////////////////////////////////////////////////////////////////////////
            OracleConnection conn2 = new OracleConnection("Data Source=" + localBanco + "/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd2 = new OracleCommand();
            string query2 = "INSERT INTO TLOG_VALIDADOR (TLOG_DATA, TLOG_USUARIO, TLOG_HOST, TLOG_OBS) VALUES (:DATAHORA, :USUARIO, :HOST, :OBS)";
            oCmd2.CommandText = query2;
            oCmd2.CommandType = CommandType.Text;
            oCmd2.Parameters.AddWithValue("DATAHORA", DateTime.Now);
            oCmd2.Parameters.AddWithValue("USUARIO", usuarioLogado);
            oCmd2.Parameters.AddWithValue("HOST", hostName);
            oCmd2.Parameters.AddWithValue("OBS", "Acessou a consulta em massa.");
            oCmd2.Connection = conn2;
            conn2.Open();
            OracleDataReader ler2 = oCmd2.ExecuteReader();
            conn2.Close();
            ////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //LOG DE ACESSO ///////////////////////////////////////////////////////////////////////////////
            OracleConnection conn2 = new OracleConnection("Data Source=" + localBanco + "/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd2 = new OracleCommand();
            string query2 = "INSERT INTO TLOG_VALIDADOR (TLOG_DATA, TLOG_USUARIO, TLOG_HOST, TLOG_OBS) VALUES (:DATAHORA, :USUARIO, :HOST, :OBS)";
            oCmd2.CommandText = query2;
            oCmd2.CommandType = CommandType.Text;
            oCmd2.Parameters.AddWithValue("DATAHORA", DateTime.Now);
            oCmd2.Parameters.AddWithValue("USUARIO", usuarioLogado);
            oCmd2.Parameters.AddWithValue("HOST", hostName);
            oCmd2.Parameters.AddWithValue("OBS", "Encerrou a aplicação.");
            oCmd2.Connection = conn2;
            conn2.Open();
            OracleDataReader ler2 = oCmd2.ExecuteReader();
            conn2.Close();
            ////////////////////////////////////////////////////////////////////////////////////////////////

            Application.Exit();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();

            //LOG DE ACESSO ///////////////////////////////////////////////////////////////////////////////
            OracleConnection conn2 = new OracleConnection("Data Source=" + localBanco + "/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd2 = new OracleCommand();
            string query2 = "INSERT INTO TLOG_VALIDADOR (TLOG_DATA, TLOG_USUARIO, TLOG_HOST, TLOG_OBS) VALUES (:DATAHORA, :USUARIO, :HOST, :OBS)";
            oCmd2.CommandText = query2;
            oCmd2.CommandType = CommandType.Text;
            oCmd2.Parameters.AddWithValue("DATAHORA", DateTime.Now);
            oCmd2.Parameters.AddWithValue("USUARIO", usuarioLogado);
            oCmd2.Parameters.AddWithValue("HOST", hostName);
            oCmd2.Parameters.AddWithValue("OBS", "Acessou Ajuda > Sobre.");
            oCmd2.Connection = conn2;
            try
            {
                conn2.Open();
                OracleDataReader ler2 = oCmd2.ExecuteReader();
                conn2.Close();
            }
            catch(Exception ex)
            {
                //...
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void FormPai_Load(object sender, EventArgs e)
        {
            timerHoraExibicao.Interval = 1000;
            timerHoraExibicao.Start();
            
            localBanco = ConfigINI.LerINI(@"configuracoes.ini", "[LocalBanco]");
            FormCloseButtonDisabler.DisableCloseButton(this.Handle.ToInt32());
            lblBemVindo.Text = nome;
            timer1.Interval = 100;
            timer1.Start();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ConsultaGeral>().Count() == 0 && 
                Application.OpenForms.OfType<Form1>().Count() == 0 && 
                Application.OpenForms.OfType<TestePopularCombo>().Count() == 0 &&
                Application.OpenForms.OfType<ConsultaPorUF>().Count() == 0 &&
                Application.OpenForms.OfType<VisualizaDetalheVenda>().Count() == 0 &&
                Application.OpenForms.OfType<FormServicosMain>().Count() == 0) 
            {
                pictureBox2.Visible = true;
            }
        }

        private void consultaÚnicaPorLojaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultaÚnicaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void consultaÚnicaPorLojaUFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaPorUF formConsultaPorLojaUF = new ConsultaPorUF();
            abre_form_filho(formConsultaPorLojaUF);
            pictureBox2.Visible = false;

            //LOG DE ACESSO ///////////////////////////////////////////////////////////////////////////////
            OracleConnection conn2 = new OracleConnection("Data Source=" + localBanco + "/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd2 = new OracleCommand();
            string query2 = "INSERT INTO TLOG_VALIDADOR (TLOG_DATA, TLOG_USUARIO, TLOG_HOST, TLOG_OBS) VALUES (:DATAHORA, :USUARIO, :HOST, :OBS)";
            oCmd2.CommandText = query2;
            oCmd2.CommandType = CommandType.Text;
            oCmd2.Parameters.AddWithValue("DATAHORA", DateTime.Now);
            oCmd2.Parameters.AddWithValue("USUARIO", usuarioLogado);
            oCmd2.Parameters.AddWithValue("HOST", hostName);
            oCmd2.Parameters.AddWithValue("OBS", "Acessou a consulta única por loja [UF].");
            oCmd2.Connection = conn2;
            conn2.Open();
            OracleDataReader ler2 = oCmd2.ExecuteReader();
            conn2.Close();
            ////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void consultaÚnicaPorLojaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TestePopularCombo formConsultaPorLoja = new TestePopularCombo();
            abre_form_filho(formConsultaPorLoja);
            pictureBox2.Visible = false;

            //LOG DE ACESSO ///////////////////////////////////////////////////////////////////////////////
            OracleConnection conn2 = new OracleConnection("Data Source=" + localBanco + "/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd2 = new OracleCommand();
            string query2 = "INSERT INTO TLOG_VALIDADOR (TLOG_DATA, TLOG_USUARIO, TLOG_HOST, TLOG_OBS) VALUES (:DATAHORA, :USUARIO, :HOST, :OBS)";
            oCmd2.CommandText = query2;
            oCmd2.CommandType = CommandType.Text;
            oCmd2.Parameters.AddWithValue("DATAHORA", DateTime.Now);
            oCmd2.Parameters.AddWithValue("USUARIO", usuarioLogado);
            oCmd2.Parameters.AddWithValue("HOST", hostName);
            oCmd2.Parameters.AddWithValue("OBS", "Acessou a consulta única por loja.");
            oCmd2.Connection = conn2;
            conn2.Open();
            OracleDataReader ler2 = oCmd2.ExecuteReader();
            conn2.Close();
            ////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void consultaÚnicaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form1 formConsultaUnica = new Form1();
            abre_form_filho(formConsultaUnica);
            pictureBox2.Visible = false;

            //LOG DE ACESSO ///////////////////////////////////////////////////////////////////////////////
            OracleConnection conn2 = new OracleConnection("Data Source=" + localBanco + "/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd2 = new OracleCommand();
            string query2 = "INSERT INTO TLOG_VALIDADOR (TLOG_DATA, TLOG_USUARIO, TLOG_HOST, TLOG_OBS) VALUES (:DATAHORA, :USUARIO, :HOST, :OBS)";
            oCmd2.CommandText = query2;
            oCmd2.CommandType = CommandType.Text;
            oCmd2.Parameters.AddWithValue("DATAHORA", DateTime.Now);
            oCmd2.Parameters.AddWithValue("USUARIO", usuarioLogado);
            oCmd2.Parameters.AddWithValue("HOST", hostName);
            oCmd2.Parameters.AddWithValue("OBS", "Acessou a consulta única por servidor.");
            oCmd2.Connection = conn2;
            conn2.Open();
            OracleDataReader ler2 = oCmd2.ExecuteReader();
            conn2.Close();
            ////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void detalheDaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisualizaDetalheVenda detalheVenda = new VisualizaDetalheVenda();
            abre_form_filho(detalheVenda);
            pictureBox2.Visible = false;

            //LOG DE ACESSO ///////////////////////////////////////////////////////////////////////////////
            OracleConnection conn2 = new OracleConnection("Data Source=" + localBanco + "/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd2 = new OracleCommand();
            string query2 = "INSERT INTO TLOG_VALIDADOR (TLOG_DATA, TLOG_USUARIO, TLOG_HOST, TLOG_OBS) VALUES (:DATAHORA, :USUARIO, :HOST, :OBS)";
            oCmd2.CommandText = query2;
            oCmd2.CommandType = CommandType.Text;
            oCmd2.Parameters.AddWithValue("DATAHORA", DateTime.Now);
            oCmd2.Parameters.AddWithValue("USUARIO", usuarioLogado);
            oCmd2.Parameters.AddWithValue("HOST", hostName);
            oCmd2.Parameters.AddWithValue("OBS", "Acessou a consulta de detalhes da venda.");
            oCmd2.Connection = conn2;
            conn2.Open();
            OracleDataReader ler2 = oCmd2.ExecuteReader();
            conn2.Close();
            ////////////////////////////////////////////////////////////////////////////////////////////////

        }

        private void vendasFiscaisToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormServicosMain servicos = new FormServicosMain();
            abre_form_filho(servicos);
            pictureBox2.Visible = false;
            //LOG DE ACESSO ///////////////////////////////////////////////////////////////////////////////
            OracleConnection conn2 = new OracleConnection("Data Source=" + localBanco + "/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd2 = new OracleCommand();
            string query2 = "INSERT INTO TLOG_VALIDADOR (TLOG_DATA, TLOG_USUARIO, TLOG_HOST, TLOG_OBS) VALUES (:DATAHORA, :USUARIO, :HOST, :OBS)";
            oCmd2.CommandText = query2;
            oCmd2.CommandType = CommandType.Text;
            oCmd2.Parameters.AddWithValue("DATAHORA", DateTime.Now);
            oCmd2.Parameters.AddWithValue("USUARIO", usuarioLogado);
            oCmd2.Parameters.AddWithValue("HOST", hostName);
            oCmd2.Parameters.AddWithValue("OBS", "Acessou a conciliação de serviços.");
            oCmd2.Connection = conn2;
            conn2.Open();
            OracleDataReader ler2 = oCmd2.ExecuteReader();
            conn2.Close();
            ////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void timerHoraExibicao_Tick(object sender, EventArgs e)
        {
            lblData.Text = DateTime.Now.ToString();
        }
    }
}
