using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

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
    public partial class FormOperacoesNaoIntegradascs : Form
    {
        public string dataIni;
        public string dataFim;
        string ipServidor;
        string nomeDaLoja;

        public FormOperacoesNaoIntegradascs(string ipServidorLoja, string nomeLoja, string dataInicial, string dataFinal)
        {
            InitializeComponent();
            ipServidor = ipServidorLoja;
            dataIni = dataInicial;
            dataFim = dataFinal;
            nomeDaLoja = nomeLoja;
        }

        public void ConsultarVenda()
        {
            FbConnection fbConn = new FbConnection("DataSource=" + ipServidor + "; Database=" + "C:\\proton\\pdv-server\\dat\\DBSRV.gdb" + "; User=SYSDBA; Password=masterkey; Connection lifetime=15");
            FbCommand cmd = new FbCommand();
            cmd.Connection = fbConn;
            try
            {
                fbConn.Open();
                cmd.CommandText = "select " +
                                    "a.tped_numero_pedido_pk as Cupom, " +
                                    "a.tped_caixa_fk_pk as PDV, " +
                                    "a.tped_valor_liquido_pedido as Liquido, " +
                                    "a.tped_data_pedido as Data, " +
                                    "a.tped_hora_pedido as Hora, " +
                                    "a.tped_host_pdv as HostPDV, " +
                                    "a.tped_chave_acesso as ChaveAcesso " +
                                    "from tped_pedido_venda a " +
                                    "where a.tped_data_pedido between @DATAINI and @DATAFIM " +
                                    "and a.tped_status_pedido <> 'CA' " +
                                    "and a.tped_tipo_venda in ('N', 'S', 'M') " +
                                    "and a.tped_integrado = 'N'";
                cmd.Parameters.AddWithValue("@DATAINI", dataIni);
                cmd.Parameters.AddWithValue("@DATAFIM", dataFim);
                //FbDataReader ler = cmd.ExecuteReader();
                FbDataAdapter da = new FbDataAdapter(cmd);
                DataTable vendasSemIntegrar = new DataTable();
                da.Fill(vendasSemIntegrar);
                fbConn.Close();
                dataGridView1.DataSource = vendasSemIntegrar;
                dataGridView1.AutoResizeColumn(5);
                dataGridView1.AutoResizeColumn(6);
                lblConsultando.Visible = false;
                pictureBox1.Visible = false;
                dataGridView1.Visible = true;
            }
            catch(Exception ex)
            {
                timer1.Stop();
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void FormOperacoesNaoIntegradascs_Load(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ConsultarVenda();
            timer1.Stop();
            this.Text = "** Operações Sem Integrar **  |  " + nomeDaLoja + " |  De: " + dataIni + " Até: " + dataFim;
        }
    }
}
