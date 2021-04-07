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
using System.Data.OracleClient;
using System.Configuration;

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
    public partial class ConsultaPorUF : Form
    {
        public ConsultaPorUF()
        {
            InitializeComponent();
        }


        

        List<string> Lojas = new List<string>();
        List<string> Centros = new List<string>();
        List<string> Uf = new List<string>();
        List<string> Estados = new List<string>();
        string[] lojasArray;
        string[] centrosArray;
        string[] UfArray;
        string[] EstadoArray;
        string excecao = "OK";
        string valor;
        string centro, loja, host_servidor, vendaOracle;
        decimal diferenca;
        decimal totalRetail = 0, totalFirebird = 0, diferencaLabel = 0;
        string localBanco;
        public string ipServidorLoja;

        public string IpServidorLoja
        {
            get { return ipServidorLoja; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtTotalRetail.Text = "R$0,00";
            txtTotalFirebird.Text = "R$0,00";
            txtDiferenca.Text = "R$0,00";
            totalFirebird = 0;
            totalRetail = 0;
            diferenca = 0;
            vendaOracle = "0";
            DataTable Tbl = new DataTable();
            Tbl.Columns.Add("Data e Hora", typeof(string));
            Tbl.Columns.Add("Data Venda", typeof(string));
            Tbl.Columns.Add("Centro", typeof(string));
            Tbl.Columns.Add("Loja", typeof(string));
            Tbl.Columns.Add("VendaRetail", typeof(string));
            Tbl.Columns.Add("VendaFirebird", typeof(string));
            Tbl.Columns.Add("Diferença", typeof(string));
            Tbl.Columns.Add("Exceção", typeof(string));
            Tbl.Columns.Add("IpServidor", typeof(string));
            DataRow Linha;
            //MessageBox.Show(comboBox1.SelectedIndex.ToString());

            //CASO O COMBO (TODAS) ESTEJA MARCADO, PEGAR AS LOJAS DA UF SELECIONADA
            if (checkBoxTodas.Checked == true)
            {

                OracleConnection conn2 = new OracleConnection("Data Source="+localBanco+"/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
                OracleCommand oCmd2 = new OracleCommand();
                string query2 = "SELECT s.loja_sap_pk CENTRO, " +
                               "u.tund_fantasia LOJA, " +
                               "s.host_servidor " +
                               "FROM tloja_sap s " +
                               "join TUND_UNIDADE u on s.loja_proton_uk = u.tund_unidade_pk " +
                               "where s.loja_sap_pk = :CENTROORA";
                oCmd2.CommandText = query2;
                oCmd2.CommandType = CommandType.Text;
                oCmd2.Parameters.AddWithValue(":CENTROORA", centrosArray[comboBox1.SelectedIndex]);
                oCmd2.Connection = conn2;
                //MessageBox.Show("Abriu a consulta passando " + centros[i] + " Como parâmetro");
                conn2.Open();
                OracleDataReader ler1 = oCmd2.ExecuteReader();
                while (ler1.Read())
                {
                    centro = ler1.GetValue(0).ToString();
                    loja = ler1.GetValue(1).ToString();
                    host_servidor = ler1.GetValue(2).ToString();
                }
                //MessageBox.Show("Retornou Centro :" + centro + " Loja: " + loja + " IP Servidor: " + host_servidor);
                conn2.Close();
            }
            else
            {
                //PEGANDO OS DADOS DAS LOJAS A SEREM CONSULTADAS
                OracleConnection conn1 = new OracleConnection("Data Source="+localBanco+"/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
                OracleCommand oCmd1 = new OracleCommand();
                string query1 = "SELECT s.loja_sap_pk CENTRO, " +
                               "u.tund_fantasia LOJA, " +
                               "s.host_servidor " +
                               "FROM tloja_sap s " +
                               "join TUND_UNIDADE u on s.loja_proton_uk = u.tund_unidade_pk " +
                               "where s.loja_sap_pk = :CENTROORA";
                oCmd1.CommandText = query1;
                oCmd1.CommandType = CommandType.Text;
                oCmd1.Parameters.AddWithValue(":CENTROORA", centrosArray[comboBox1.SelectedIndex]);
                oCmd1.Connection = conn1;
                //MessageBox.Show("Abriu a consulta passando " + centros[i] + " Como parâmetro");
                try
                {
                    conn1.Open();
                    OracleDataReader ler1 = oCmd1.ExecuteReader();
                    while (ler1.Read())
                    {
                        centro = ler1.GetValue(0).ToString();
                        loja = ler1.GetValue(1).ToString();
                        host_servidor = ler1.GetValue(2).ToString();
                    }
                    //MessageBox.Show("Retornou Centro :" + centro + " Loja: " + loja + " IP Servidor: " + host_servidor);
                    conn1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao tentar conectar na base de dados.\nVerifique a conexão com o Oracle e tente novamente.\n\n"
                                    + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            //CONSULTA NO ORACLE
            OracleConnection conn = new OracleConnection("Data Source="+localBanco+"/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd = new OracleCommand();
            //wait.lblProgresso.Text = i.ToString();
            string query = "SELECT sum(t.valor_liquido) venda " +
                                "FROM TTRANSACAO t " +
                                "join tloja_sap s " +
                                "on t.numero_loja_uk = s.loja_proton_uk " +
                                "WHERE TRUNC(t.data_hora_transacao_uk) between :DATAORA1 and  :DATAORA2 " +
                                "and t.tipo in ('P', 'N', 'S', 'M') " +
                                "and t.cancelada = 'N' " +
                                "and not exists " +
                                "(select * " +
                                "from ttransacao tt " +
                                "where tt.numero_loja_uk = t.numero_loja_uk " +
                                "and tt.numero_transacao_uk = t.numero_transacao_uk " +
                                "and tt.numero_pdv_uk = t.numero_pdv_uk " +
                                "and tt.numero_serie_impressora_uk = t.numero_serie_impressora_uk " +
                                "and tt.data_hora_transacao_uk = t.data_hora_transacao_uk " +
                                "and tt.tipo = t.tipo " +
                                "and tt.cancelada = 'S') " +
                                "and s.loja_sap_pk = :CENTROORA";

            oCmd.CommandText = query;
            oCmd.CommandType = CommandType.Text;
            oCmd.Parameters.AddWithValue(":DATAORA1", maskedTextBox1.Text);
            oCmd.Parameters.AddWithValue(":DATAORA2", maskedTextBox2.Text);
            oCmd.Parameters.AddWithValue(":CENTROORA", centrosArray[comboBox1.SelectedIndex]);
            oCmd.Connection = conn;
            try
            {
                conn.Open();
                OracleDataReader ler = oCmd.ExecuteReader();
                while (ler.Read())
                {
                    vendaOracle = ler.GetValue(0).ToString();
                }
                //::::::::::::::::::::::::::::::::::::::::::::::::::::
                // TRATAMENTO DE EXCEÇÃO DO ORACLE
                //::::::::::::::::::::::::::::::::::::::::::::::::::::
                //Caso não tenha havido venda no dia consultado
                //na loja consultada, o Oracle retorna 'null' e
                //dessa forma na conversão para decimal abaixo irá,
                //ocorrer uma exceção. Para isso, o if abaixo irá
                //converter o valor para 0 caso retorne 'null' na
                //consulta do firebird.
                //::::::::::::::::::::::::::::::::::::::::::::::::::::
                if (vendaOracle == "")
                {
                    vendaOracle = "0";
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar conectar na base de dados.\nVerifique a conexão com o Oracle e tente novamente.\n\n"
                                + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //CONSULTA NO FIREBIRD
            try
            {
                FbConnection fbConn = new FbConnection("DataSource=" + host_servidor + "; Database=" + "C:\\proton\\pdv-server\\dat\\DBSRV.gdb" + "; User=SYSDBA; Password=masterkey; Connection lifetime=15");
                FbCommand cmd = new FbCommand();
                fbConn.Open();
                cmd.Connection = fbConn;
                cmd.CommandText = "select sum(a.tped_valor_liquido_pedido) " +
                                  "from tped_pedido_venda a " +
                                  "where a.tped_data_pedido between '" + maskedTextBox1.Text + "' and '" + maskedTextBox2.Text + "'" +
                                  "and a.tped_status_pedido <> 'CA' " +
                                  "and a.tped_tipo_venda in ('N','P','S','M')";
                FbDataReader ler = cmd.ExecuteReader();
                while (ler.Read())
                {
                    valor = ler.GetValue(0).ToString();
                }
                //::::::::::::::::::::::::::::::::::::::::::::::::::::
                // TRATAMENTO DE EXCEÇÃO DO FIREBIRD
                //::::::::::::::::::::::::::::::::::::::::::::::::::::
                //Caso não tenha havido venda no dia consultado
                //na loja consultada, o firebird retorna 'null' e
                //dessa forma na conversão para decimal abaixo irá,
                //ocorrer uma exceção. Para isso, o if abaixo irá
                //converter o valor para 0 caso retorne 'null' na
                //consulta do firebird.
                //::::::::::::::::::::::::::::::::::::::::::::::::::::
                if (valor == "")
                {
                    valor = "0";
                }
                fbConn.Close();
                diferenca = Convert.ToDecimal(valor) - Convert.ToDecimal(vendaOracle);
            }
            catch (Exception ex)
            {
                excecao = ex.Message;
                diferenca = 0; //Caso não consiga conexão com o firebird, não pode exibir diferença negativa
            }

            Linha = Tbl.NewRow();
            Linha["Data e Hora"] = DateTime.Now;
            Linha["Data Venda"] = "De " + maskedTextBox1.Text + " Até " + maskedTextBox2.Text ;
            Linha["Centro"] = centrosArray[comboBox1.SelectedIndex];
            Linha["Loja"] = loja;
            Linha["VendaRetail"] = vendaOracle;// Math.Truncate(Convert.ToDecimal(valor));
            Linha["VendaFirebird"] = Math.Round(Convert.ToDecimal(valor), 2);
            Linha["Diferença"] = Math.Round(diferenca, 2);
            Linha["Exceção"] = excecao;
            Linha["IpServidor"] = host_servidor;
            Tbl.Rows.Add(Linha);
            totalRetail = Convert.ToDecimal(vendaOracle);
            totalFirebird = Convert.ToDecimal(valor);
            diferencaLabel = diferenca;

            //venda.WriteLine(DateTime.Now + " " + centrosArray[comboBox1.SelectedIndex] + " " + valor);

            dataGridView1.DataSource = Tbl;

            excecao = "OK";
            txtTotalRetail.Text = "R$" + Math.Round(totalRetail, 2).ToString();
            txtDiferenca.Text = "R$" + Math.Round(diferenca, 2).ToString();
            txtTotalFirebird.Text = "R$" + Math.Round(totalFirebird, 2).ToString();

            ipServidorLoja = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void ConsultaPorUF_Load(object sender, EventArgs e)
        {
            localBanco = ConfigINI.LerINI(@"configuracoes.ini", "[LocalBanco]");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboUF.DropDownStyle = ComboBoxStyle.DropDownList;
            OracleConnection conn1 = new OracleConnection("Data Source="+localBanco+"/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd1 = new OracleCommand();
            string query1 = "select distinct " +
                            "c.tloc_uf_fk, " +
                            "c.tloc_uf_fk || ' - ' || f.tloc_nome as UF " +
                            "from " +
                            "tund_unidade u " +
                            "join tloc_cidade_cep c on u.tund_cidade_cep_fk = c.tloc_cidade_cep_pk " +
                            "join tloja_sap s on u.tund_unidade_pk = s.loja_proton_uk " +
                            "join tloc_uf f on c.tloc_uf_fk = f.tloc_uf_pk " +
                            "AND s.ativa_difusao = 'S' " +
                            "and s.loja_sap_pk not like ('9%') " +
                            "order by 1";
            oCmd1.CommandText = query1;
            oCmd1.CommandType = CommandType.Text;
            oCmd1.Connection = conn1;

            conn1.Open();
            OracleDataReader ler1 = oCmd1.ExecuteReader();

            while (ler1.Read())
            {
                string UF = ler1.GetValue(0).ToString();
                string ESTADO = ler1.GetValue(1).ToString();
                Uf.Add(UF);
                Estados.Add(ESTADO);
            }

            conn1.Close();

            comboUF.DataSource = Estados;
            UfArray = Uf.ToArray();
            EstadoArray = Estados.ToArray();
        }

        private void comboUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerIndiceComboUF.Interval = 1000;
            timerIndiceComboUF.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lojas.Clear();
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            OracleConnection conn1 = new OracleConnection("Data Source="+localBanco+"/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd1 = new OracleCommand();
            string query1 = "select " +
                            "s.loja_sap_pk as SAP, " +
                            "s.loja_sap_pk || ' - ' || u.tund_fantasia as NOME " +
                            "from " +
                            "tund_unidade u " +
                            "join tloc_cidade_cep c on u.tund_cidade_cep_fk = c.tloc_cidade_cep_pk " +
                            "join tloja_sap s on u.tund_unidade_pk = s.loja_proton_uk " +
                            "join tloc_uf f on c.tloc_uf_fk = f.tloc_uf_pk " +
                            "where c.tloc_uf_fk = :UF " +
                            "AND s.ativa_difusao = 'S' " +
                            "and s.loja_sap_pk not like ('9%') " +
                            "order by 1";
            oCmd1.CommandText = query1;
            oCmd1.CommandType = CommandType.Text;
            oCmd1.Parameters.AddWithValue(":UF", UfArray[comboUF.SelectedIndex]);
            oCmd1.Connection = conn1;

            conn1.Open();
            OracleDataReader ler1 = oCmd1.ExecuteReader();

            while (ler1.Read())
            {
                string CENTRO = ler1.GetValue(0).ToString();
                string LOJA = ler1.GetValue(1).ToString();
                Lojas.Add(LOJA);
                Centros.Add(CENTRO);
            }

            conn1.Close();

            comboBox1.DataSource = Lojas;
            lojasArray = Lojas.ToArray();
            centrosArray = Centros.ToArray();
        }

        private void timerIndiceComboUF_Tick(object sender, EventArgs e)
        {
            Lojas.Clear();
            Centros.Clear();
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            OracleConnection conn1 = new OracleConnection("Data Source="+localBanco+"/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd1 = new OracleCommand();
            string query1 = "select " +
                            "s.loja_sap_pk as SAP, " +
                            "s.loja_sap_pk || ' - ' || u.tund_fantasia as NOME " +
                            "from " +
                            "tund_unidade u " +
                            "join tloc_cidade_cep c on u.tund_cidade_cep_fk = c.tloc_cidade_cep_pk " +
                            "join tloja_sap s on u.tund_unidade_pk = s.loja_proton_uk " +
                            "join tloc_uf f on c.tloc_uf_fk = f.tloc_uf_pk " +
                            "where c.tloc_uf_fk = :UF " +
                            "AND s.ativa_difusao = 'S' " +
                            "and s.loja_sap_pk not like ('9%') " +
                            "order by 1";
            oCmd1.CommandText = query1;
            oCmd1.CommandType = CommandType.Text;
            oCmd1.Parameters.AddWithValue(":UF", UfArray[comboUF.SelectedIndex]);
            oCmd1.Connection = conn1;

            conn1.Open();
            OracleDataReader ler1 = oCmd1.ExecuteReader();

            while (ler1.Read())
            {
                string CENTRO = ler1.GetValue(0).ToString();
                string LOJA = ler1.GetValue(1).ToString();
                Lojas.Add(LOJA);
                Centros.Add(CENTRO);
            }

            conn1.Close();

            comboBox1.DataSource = Lojas;
            lojasArray = Lojas.ToArray();
            centrosArray = Centros.ToArray();
            timerIndiceComboUF.Stop();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyData == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void checkBoxTodas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTodas.Checked == true)
            { 
                comboBox1.Enabled = false; 
            }
            if (checkBoxTodas.Checked == false)
            { 
                comboBox1.Enabled = true; 
            }
        }

        private void btnVerNaoIntegrados_Click(object sender, EventArgs e)
        {
            FormOperacoesNaoIntegradascs operacoes = new FormOperacoesNaoIntegradascs(dataGridView1.CurrentRow.Cells[8].Value.ToString(), 
                                                                                      dataGridView1.CurrentRow.Cells[3].Value.ToString(), 
                                                                                      maskedTextBox1.Text, 
                                                                                      maskedTextBox2.Text);
            operacoes.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}
