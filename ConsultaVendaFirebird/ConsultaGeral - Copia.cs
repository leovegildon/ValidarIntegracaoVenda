using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Data.OracleClient;
using System.Threading;

namespace ConsultaVendaFirebird
{
    public partial class ConsultaGeral : Form
    {
        public ConsultaGeral()
        {
            InitializeComponent();
        }
        
        //==========================
        //   VARIÁVEIS GLOBAIS
        //==========================
        
        string[] relacaoIP;
        string[] centros;
        string excecao = "OK";
        string valor;
        string centro, loja, host_servidor, vendaOracle;
        decimal diferenca;
        decimal totalRetail = 0, totalFirebird = 0, diferencaLabel = 0;
        double progresso = 0;
        int progressoBar = 0;
        List<string> Lojas = new List<string>();
        List<string> Centros = new List<string>();
        string[] lojasArray;
        string[] centrosArray;
        
        //Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
        
    
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = 0;
            backgroundWorker1.RunWorkerAsync();
            pictureBox2.Visible = true;
            totalRetail = 0;
            totalFirebird = 0;
            diferencaLabel = 0;
            txtTotalRetail.Text = "R$0,00";
            txtTotalFirebird.Text = "R$0,00";
            txtDiferenca.Text = "R$0,00";
        }

        //========================================================================================================
        //                                                                                                        
        //    S U P E R  S C R I P T  D E  C O N S U L T A  F I R E B I R D  E  O R A C L E  D A T A B A S E 
        //
        //========================================================================================================
        //
        // Consulta os valores de vendas por centro na base do Retail e servidores de loja um a um e retorna
        // os valores sumarizados comparando-os afim de identificar diferenças entre eles.
        //
        //========================================================================================================
        
        
        public void Processamento()
        {
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

            
           
           //Devido aos controles estarem em outra thread, devem ser chamados via BeginInvoke
            btnConsultar.BeginInvoke(
           new Action(() =>
           {
               btnConsultar.Enabled = false;
           }
            ));

            txtData.BeginInvoke(
           new Action(() =>
           {
               maskedTextBox1.Enabled = false;
           }
            ));
            dataGridView1.BeginInvoke(
            new Action(() =>
            {
                dataGridView1.Visible = false;
            }
             ));

            txtPrimeiroCentro.BeginInvoke(
       new Action(() =>
       {
           txtPrimeiroCentro.Text = lojasArray[0];
       }
        ));
            txtUltimoCentro.BeginInvoke(
       new Action(() =>
       {
           txtUltimoCentro.Text = lojasArray[lojasArray.Length - 1];
       }
        ));

            System.IO.StreamWriter venda = new System.IO.StreamWriter("VENDA.txt", true); //Log da venda

            //============================
            // INICIO DO LAÇO FOR
            //============================
            for (int i = 0; i < centrosArray.Length; i++)
            {
                progresso = ((i + 1) * 100) / centrosArray.Length;
                progressoBar = Convert.ToInt32(progresso);
                this.backgroundWorker1.ReportProgress(progressoBar);
               lblPorcentagem.BeginInvoke(
                new Action(() =>
                {
                     lblPorcentagem.Text = progressoBar + "%";
                }
                   ));
               txtCentroAtual.BeginInvoke(
      new Action(() =>
      {
          txtCentroAtual.Text = lojasArray[i];
      }
       ));

                valor = "0.00";
                vendaOracle = "0.00";
                diferenca = 0;
                host_servidor = "";
                //MessageBox.Show("Abriu a consulta dos dados da loja " + centrosArray[i] + " Como parâmetro");

                //PEGANDO OS DADOS DAS LOJAS A SEREM CONSULTADAS
                OracleConnection conn1 = new OracleConnection("Data Source=10.101.1.26/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
                OracleCommand oCmd1 = new OracleCommand();
                string query1 = "SELECT s.loja_sap_pk CENTRO, " +
                               "u.tund_fantasia LOJA, " +
                               "s.host_servidor " +
                               "FROM tloja_sap s " +
                               "join TUND_UNIDADE u on s.loja_proton_uk = u.tund_unidade_pk " +
                               "where s.loja_sap_pk = :CENTROORA";
                oCmd1.CommandText = query1;
                oCmd1.CommandType = CommandType.Text;
                oCmd1.Parameters.AddWithValue(":CENTROORA", centrosArray[i]);
                oCmd1.Connection = conn1;
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

                //CONSULTA NO ORACLE
                OracleConnection conn = new OracleConnection("Data Source=10.101.1.26/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
                OracleCommand oCmd = new OracleCommand();

                //wait.lblProgresso.Text = i.ToString();
                MessageBox.Show("Abriu a consulta da venda no Oracle passando: " + centrosArray[i] + " Como centro e: " + maskedTextBox1.Text + " Como data");
                string query = "SELECT LOJA_SAP_PK CENTRO," +
                                "tund_fantasia LOJA, " +
                                "l.host_servidor, " +
                                "sum(t.valor_liquido) venda " +
                                "FROM TTRANSACAO t, tloja_sap l, TUND_UNIDADE u " +
                                "WHERE TRUNC(t.data_hora_transacao_uk) = " + maskedTextBox1.Text + " " +
                                " and t.tipo in ('P', 'N', 'S', 'M') " +
                                "and t.cancelada = 'N' " +
                                "and not exists " +
                                "(select * " +
                                "from ttransacao tt " +
                                "where tt.numero_loja_uk = t.numero_loja_uk " +
                                "and tt.numero_transacao_uk = t.numero_transacao_uk " +
                                "and tt.numero_pdv_uk = t.numero_pdv_uk " +
                                "and tt.numero_serie_impressora_uk = " +
                                "t.numero_serie_impressora_uk " +
                                "and tt.data_hora_transacao_uk = t.data_hora_transacao_uk " +
                                "and tt.tipo = t.tipo " +
                                "and tt.cancelada = 'S') " +
                                "AND l.loja_proton_uk = t.numero_loja_uk " +
                                "AND u.tund_unidade_pk = l.loja_proton_uk " +
                                "and l.loja_sap_pk = " + centrosArray[i] + " " +
                                "GROUP BY LOJA_SAP_PK, tund_fantasia, l.host_servidor " +
                                "ORDER BY 1, tund_fantasia";
                oCmd.CommandText = query;
                MessageBox.Show("Passou a query");
                oCmd.CommandType = CommandType.Text;
                //oCmd.Parameters.AddWithValue(":DATAORA", maskedTextBox1.Text);
                //oCmd.Parameters.AddWithValue(":CENTROORA", centrosArray[i]);
                MessageBox.Show("Passou os parametros da query");

                //MessageBox.Show("Consultou a venda passando Data: " + maskedTextBox1.Text + "Centro: " + centros[i]);
                oCmd.Connection = conn;
                try
                {
                    conn.Open();
                    MessageBox.Show("Abriu a sessão no banco");
                    OracleDataReader ler = oCmd.ExecuteReader();
                    MessageBox.Show("Rodou a query");
                    while (ler.Read())
                    {
                        vendaOracle = ler.GetValue(3).ToString();
                    }
                    MessageBox.Show("Retornou " + vendaOracle + " Como valor");
                    conn.Close();
                    //MessageBox.Show("Retornou a venda: R$" + vendaOracle);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao tentar conectar na base de dados.\nVerifique a conexão com o Oracle e tente novamente.\n\n"
                                    + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //vendaOracle = "0";

                //CONSULTA NO FIREBIRD
                try
                {
                    FbConnection fbConn = new FbConnection("DataSource=" + host_servidor + "; Database=" + "C:\\proton\\pdv-server\\dat\\DBSRV.gdb" + "; User=SYSDBA; Password=masterkey; Connection lifetime=15");
                    FbCommand cmd = new FbCommand();
                    fbConn.Open();
                    cmd.Connection = fbConn;
                    cmd.CommandText = "select sum(a.tped_valor_liquido_pedido) " +
                                      "from tped_pedido_venda a "+
                                      "where a.tped_data_pedido = '" + maskedTextBox1.Text + "' " +
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
                    if(valor == "")
                    { 
                        valor = "0";
                    }
                    fbConn.Close();
                    diferenca = Convert.ToDecimal(valor) - Convert.ToDecimal(vendaOracle);
                }
                catch(Exception ex)
                {
                    excecao = ex.Message;
                    diferenca = 0; //Caso não consiga conexão com o firebird, não pode exibir diferença negativa
                }

                Linha = Tbl.NewRow();
                Linha["Data e Hora"] = DateTime.Now;
                Linha["Data Venda"] = maskedTextBox1.Text;
                Linha["Centro"] = centrosArray[i];
                Linha["Loja"] = loja;
                Linha["VendaRetail"] = vendaOracle;// Math.Truncate(Convert.ToDecimal(valor));
                Linha["VendaFirebird"] = Math.Round(Convert.ToDecimal(valor), 2);
                Linha["Diferença"] = Math.Round(diferenca, 2);
                Linha["Exceção"] = excecao;
                Linha["IpServidor"] = host_servidor;
                Tbl.Rows.Add(Linha);
                totalRetail = totalRetail + Convert.ToDecimal(vendaOracle);
                totalFirebird = totalFirebird + Convert.ToDecimal(valor);
                diferencaLabel = diferencaLabel + diferenca;

                venda.WriteLine(DateTime.Now + " " + centrosArray[i] + " " + valor);

                

                excecao = "OK";
                
            }//Fim For
                dataGridView1.BeginInvoke(
                   new Action(() =>
                   {
                       dataGridView1.DataSource = Tbl;
                   }
                    ));

            
             venda.Dispose();

             txtTotalFirebird.BeginInvoke(
           new Action(() =>
           {
               txtTotalFirebird.Text = "R$" + Math.Round(totalFirebird, 2).ToString();
           }
            ));
             txtTotalRetail.BeginInvoke(
           new Action(() =>
           {
               txtTotalRetail.Text = "R$" + Math.Round(totalRetail, 2).ToString();
           }
            ));
             txtDiferenca.BeginInvoke(
           new Action(() =>
           {
               txtDiferenca.Text = "R$" + Math.Round(diferencaLabel, 2).ToString();
           }
            ));


             lblPercentDiferenca.BeginInvoke(
            new Action(() =>
            {
                lblPercentDiferenca.Text = Convert.ToString((diferenca/totalFirebird)*100);
            }
             ));

             btnExcel.BeginInvoke(
            new Action(() =>
            {
                btnExcel.Enabled = true;
            }
             ));

             btnConsultar.BeginInvoke(
            new Action(() =>
            {
                btnConsultar.Enabled = true;
            }
             ));

             txtData.BeginInvoke(
            new Action(() =>
            {
                maskedTextBox1.Enabled = true;
            }
             ));
            pictureBox2.BeginInvoke(
            new Action(() =>
            {
             pictureBox2.Visible = false;
            }
             ));

            dataGridView1.BeginInvoke(
            new Action(() =>
            {
                dataGridView1.Visible = true;
            }
             ));
    
        }//Fim metódo Processamento()

        private void ConsultaGeral_Load(object sender, EventArgs e)
        {
            //centros = System.IO.File.ReadAllLines("centros.txt");

            OracleConnection conn1 = new OracleConnection("Data Source=10.101.1.26/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd1 = new OracleCommand();
            string query1 = "SELECT S.LOJA_SAP_PK, " +
                            "s.loja_sap_pk || ' - ' || u.tund_fantasia LOJA," +
                           "s.host_servidor " +
                           "FROM tloja_sap s " +
                           "join TUND_UNIDADE u on s.loja_proton_uk = u.tund_unidade_pk " +
                           "where s.ativa_difusao = 'S' " +
                           "order by 1";
            oCmd1.CommandText = query1;
            oCmd1.CommandType = CommandType.Text;
            oCmd1.Connection = conn1;

            conn1.Open();
            OracleDataReader ler1 = oCmd1.ExecuteReader();

            while (ler1.Read())
            {
                string LOJA = ler1.GetValue(1).ToString();
                Lojas.Add(LOJA);
                string CENTRO = ler1.GetValue(0).ToString();
                Centros.Add(CENTRO);
            }
            //MessageBox.Show("Retornou Centro :" + centro + " Loja: " + loja + " IP Servidor: " + host_servidor);
            conn1.Close();

            lojasArray = Lojas.ToArray();
            centrosArray = Centros.ToArray();
            
        }

        //==========================================================================================
        //                        E X P O R T A R  P A R A  E X C E L 
        // =========================================================================================
        private void btnExcel_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.Rows.Count > 0)
            //{
            //    try
            //    {
            //        XcelApp.Application.Workbooks.Add(Type.Missing);
            //        for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            //        {
            //            XcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            //        }
            //        //
            //        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //        {
            //            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            //            {
            //                XcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
            //            }
            //        }
            //        //
            //        XcelApp.Columns.AutoFit();
            //        //
            //        XcelApp.Visible = true;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Erro : " + ex.Message);
            //        XcelApp.Quit();
            //    }
            //}
        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtData_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyData == Keys.Enter)
            {
                btnConsultar_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e) {}

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Processamento();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyData == Keys.Enter && maskedTextBox1.Text.Length == 10)
            {
                btnConsultar_Click(sender, e);
            }

            if(maskedTextBox1.Text.Length == 9)
            {
                btnConsultar.Enabled = true;
            }
            else
            {
                btnConsultar.Enabled = false;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            
            dataGridView1.BeginInvoke(
       new Action(() =>
       {
           dataGridView1.Refresh();
       }
        ));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(maskedTextBox1.Text.Length.ToString());
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
