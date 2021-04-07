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


                /*********************************************
                 * TABELA DE ESTADOS DE TRANSAÇÃO SITEF
                 * *******************************************
                 * 
                1	Aguardando Resposta Host
                2	Pendente Confirmacao
                4	Transacao Efetuada
                5	Trn Cancel Timeout Host
                6	Trn Cancel Pdv
                132	Efetuada Local
                134	Cancelada Local
                135	Estornada Trn
                136	Cancelada Automatica
                35	Off-line Aguardando Envio Host
                36	Off-line Aguardando Resposta Host
                37	Off-line Negada pelo Host
                38	Off-line Confirmada Manualmente
                49	Aguardando Envio Desf Host
                50	Aguardando Resposta Desf Host
                51	Desfazimento Confirmado
                52	Desfazimento Pendência Visa
                53	Desfazimento Confirmado Manualmente
                68	Resgate Premio
                999	Exige Dados(concluido)
                998	Exige Dados(abortado)
                3	Transacao Negada
                133	Estorno Parcial
                ***********************************************/


namespace ConsultaVendaFirebird
{
    public partial class FormServicosMain : Form
    {
        public FormServicosMain()
        {
            InitializeComponent();
        }

        class ServicosFatura
        {
            public string LojaSAP { get; set; }
            public string LojaSiTef { get; set; }
            public string PDVSiTef { get; set; }
            public string IP { get; set; }
            public string Data { get; set; }
            public string Estado { get; set; }
            public string Cupom { get; set; }
            public string Valor { get; set; }
            public string NSU { get; set; }
        }

        class ServicosRecarga
        {
            public string LojaSAP { get; set; }
            public string LojaSiTef { get; set; }
            public string PDVSiTef { get; set; }
            public string Data { get; set; }
            public string Estado { get; set; }
            public string Cupom { get; set; }
            public string Valor { get; set; }
            public string NSU { get; set; }
            public string Operadora { get; set; }
            public string Telefone { get; set; }
        }

        List<string> Lojas = new List<string>();
        List<string> Centros = new List<string>();
        List<ServicosFatura> ListaFatura = new List<ServicosFatura>();
        List<ServicosRecarga> ListaRecarga = new List<ServicosRecarga>();
        string[] lojasArray;
        string[] centrosArray;
        string excecao = "OK";
        string valor;
        string centro, loja, host_servidor, vendaOracle;
        decimal diferenca;
        decimal totalRetail = 0, totalFirebird = 0, diferencaLabel = 0;
        string localBanco;

        void ConsultaFatura()
        {
            localBanco = ConfigINI.LerINI(@"configuracoes.ini", "[LocalBanco]");
            comboLoja.DropDownStyle = ComboBoxStyle.DropDownList;
            OracleConnection conn1 = new OracleConnection("Data Source=" + localBanco + "/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd1 = new OracleCommand();
            string query1 = "select sp.loja_sap_pk as LOJA, " +
                           "s.codlojasitef, " +
                           "s.idt_terminal as PDV, " +
                           "s.ipterminal, " +
                           "s.data_trn as DATA, " +
                           "case when s.estado_trn = '2' " +
                             "then 'PENDENTE' " +
                               "when s.estado_trn = '4' " +
                             "then 'EFETUADA PDV' " +
                             "when s.estado_trn = '132' " +
                             "then 'EFETUADA LOCAL' " +
                               "end " +
                             "as ESTADO, " +
                           "s.cuponfiscal, " +
                           "s.VALOR_TRN/100 AS VALOR, " +
                           "s.nsu_sitef as NSU_SITEF " +
                           "from logtef@banco_sitef s " +
                           "join tloja_proton_sitef l " +
                        "on s.codlojasitef = '00000' || l.loja_sitef " +
                     "join tloja_sap sp " +
                        "on l.loja_proton = sp.loja_proton_uk " +
                        "where s.data_trn between '" + maskedDataIni.Text.Substring(6, 4) + maskedDataIni.Text.Substring(3, 2) + maskedDataIni.Text.Substring(0, 2) + "' and '" + maskedDataFim.Text.Substring(6, 4) + maskedDataFim.Text.Substring(3, 2) + maskedDataFim.Text.Substring(0, 2) + "' " +
                    "and s.idt_rede = '247' " +
                    "and s.cdmodoentrada <> '-1' " +
                    "and s.idt_produto = '-1' " +
                    "and s.estado_trn not in ('1', '3', '5', '6', '134') " +
                    "and s.codigo_resp = '00' " +
                    "and not exists (select * " +
                              "from ttransacao t " +
                              "join tloja_proton_sitef l " +
                                "on t.numero_loja_uk = l.loja_proton " +
                             "where t.nsu_servico = s.nsu_sitef " +
                               "and trunc(t.data_hora_transacao_uk) between '" + maskedDataIni.Text.Substring(0, 2) + maskedDataIni.Text.Substring(3, 2) + maskedDataIni.Text.Substring(6, 4) + "' and '" + maskedDataFim.Text.Substring(0, 2) + maskedDataFim.Text.Substring(3, 2) + maskedDataFim.Text.Substring(6, 4) + "' " +
                               "and '00000' || l.loja_sitef = s.codlojasitef " +
                               "and t.tipo = 'SR') ";
            oCmd1.CommandText = query1;
            oCmd1.CommandType = CommandType.Text;
            oCmd1.Connection = conn1;

            conn1.Open();
            OracleDataReader ler1 = oCmd1.ExecuteReader();

            while (ler1.Read())
            {
                ListaFatura.Add(new ServicosFatura() { LojaSAP = ler1.GetValue(0).ToString(), 
                                                   LojaSiTef = ler1.GetValue(1).ToString(),
                                                   PDVSiTef = ler1.GetValue(2).ToString(),
                                                   IP = ler1.GetValue(3).ToString(),
                                                   Data = ler1.GetValue(4).ToString(),
                                                   Estado = ler1.GetValue(5).ToString(),
                                                   Cupom = ler1.GetValue(6).ToString(),
                                                   Valor = ler1.GetValue(7).ToString(),
                                                   NSU = ler1.GetValue(8).ToString()
                                                });
            }

            conn1.Close();
        }

        void ConsultaRecarga()
        {
            localBanco = ConfigINI.LerINI(@"configuracoes.ini", "[LocalBanco]");
            comboLoja.DropDownStyle = ComboBoxStyle.DropDownList;
            OracleConnection conn1 = new OracleConnection("Data Source=" + localBanco + "/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd1 = new OracleCommand();
            string query1 = "select sp.loja_sap_pk, " +
                               "s.codlojasitef, " +
                               "s.idt_terminal, " +
                               "s.data_trn, " +
                               "case when s.estado_trn = '2' " +
                             "then 'PENDENTE' " +
                               "when s.estado_trn = '4' " +
                             "then 'EFETUADA PDV' " +
                             "when s.estado_trn = '132' " +
                             "then 'EFETUADA LOCAL' " +
                               "end " +
                             "as ESTADO, " +
                               "s.cuponfiscal, " +
                               "s.valor_trn/100 as VALOR, " +
                               "s.nsu_sitef as NSU_SITEF, " +
                               "s.nome_filial as OPERADORA, " +
                               "'(' || s.area || ')' || s.telefone as TELEFONE " +
                          "from logrecargacel@banco_sitef s " +
                          "join tloja_proton_sitef l " +
                            "on s.codlojasitef = '00000' || l.loja_sitef " +
                          "join tloja_sap sp " +
                            "on l.loja_proton = sp.loja_proton_uk " +
                         "where s.estado_trn in (2, 4, 132) " +
                           "and s.codigo_resp = '00' " +
                           "and s.data_trn between '" + maskedDataIni.Text.Substring(6, 4) + maskedDataIni.Text.Substring(3, 2) + maskedDataIni.Text.Substring(0, 2) + "' and '" + maskedDataFim.Text.Substring(6, 4) + maskedDataFim.Text.Substring(3, 2) + maskedDataFim.Text.Substring(0, 2) + "' " +
                           "and s.codlojasitef <> 'GRP_3024' " +
                           "and not exists (select " +
                                  "* " +
                                  "from ttransacao t " +
                                  "join tloja_proton_sitef l " +
                                    "on t.numero_loja_uk = l.loja_proton " +
                                 "where t.nsu_servico = s.nsu_sitef " +
                                   "and to_char(trunc(t.data_hora_transacao_uk), " +
                                               "'YYYYMMDD') = s.data_trn " +
                                   "and '00000' || l.loja_sitef = s.codlojasitef " +
                                   "and t.tipo = 'R')";
            oCmd1.CommandText = query1;
            oCmd1.CommandType = CommandType.Text;
            oCmd1.Connection = conn1;

            conn1.Open();
            OracleDataReader ler1 = oCmd1.ExecuteReader();

            while (ler1.Read())
            {
                ListaRecarga.Add(new ServicosRecarga()
                {
                    LojaSAP = ler1.GetValue(0).ToString(),
                    LojaSiTef = ler1.GetValue(1).ToString(),
                    PDVSiTef = ler1.GetValue(2).ToString(),
                    Data = ler1.GetValue(3).ToString(),
                    Estado = ler1.GetValue(4).ToString(),
                    Cupom = ler1.GetValue(5).ToString(),
                    Valor = ler1.GetValue(6).ToString(),
                    NSU = ler1.GetValue(7).ToString(),
                    Operadora = ler1.GetValue(8).ToString(),
                    Telefone = ler1.GetValue(9).ToString()
                });
            }

            conn1.Close();
        }

        private void FormServicosMain_Load(object sender, EventArgs e)
        {
            comboServico.DropDownStyle = ComboBoxStyle.DropDownList;

            //Populando o combo das lojas
            localBanco = ConfigINI.LerINI(@"configuracoes.ini", "[LocalBanco]");
            comboLoja.DropDownStyle = ComboBoxStyle.DropDownList;
            OracleConnection conn1 = new OracleConnection("Data Source=" + localBanco + "/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
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
                string CENTRO = ler1.GetValue(0).ToString();
                string LOJA = ler1.GetValue(1).ToString();
                Lojas.Add(LOJA);
                Centros.Add(CENTRO);
            }

            conn1.Close();

            comboLoja.DataSource = Lojas;
            lojasArray = Lojas.ToArray();
            centrosArray = Centros.ToArray();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("where s.data_trn between '" + maskedDataIni.Text.Substring(6, 4) + maskedDataIni.Text.Substring(3, 2) + maskedDataIni.Text.Substring(0, 2) + "' and '" + maskedDataFim.Text.Substring(6, 4) + maskedDataFim.Text.Substring(3, 2) + maskedDataFim.Text.Substring(0, 2) + "' ");
            //MessageBox.Show("and trunc(t.data_hora_transacao_uk) between '" + maskedDataIni.Text.Substring(0, 2) + maskedDataIni.Text.Substring(3, 2) + maskedDataIni.Text.Substring(6, 4) + "' and '" + maskedDataFim.Text.Substring(0, 2) + maskedDataFim.Text.Substring(3, 2) + maskedDataFim.Text.Substring(6, 4) + "' ");
            if(maskedDataIni.TextLength != 10)
            {
                MessageBox.Show("Informe a data inicial.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (maskedDataFim.TextLength != 10)
            {
                MessageBox.Show("Informe a data final.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            else
            {

                if (comboServico.SelectedIndex == 0)
                {
                    dataGridOperacoesNao.DataSource = null;
                    ListaRecarga.Clear();
                    dataGridOperacoesNao.Visible = false;
                    pictureBox2.Visible = true;
                    backgroundRecarga.RunWorkerAsync();
                }
                else if (comboServico.SelectedIndex == 1)
                {
                    MessageBox.Show("Ainda não implementado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (comboServico.SelectedIndex == 2)
                {
                    MessageBox.Show("Ainda não implementado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (comboServico.SelectedIndex == 3)
                {
                    dataGridOperacoesNao.DataSource = null;
                    ListaFatura.Clear();
                    dataGridOperacoesNao.Visible = false;
                    pictureBox2.Visible = true;
                    backgroundWorkerFatura.RunWorkerAsync();
                }
            }
         
        }

        private void backgroundWorkerFatura_DoWork(object sender, DoWorkEventArgs e)
        {
                   btnConsultar.BeginInvoke(
                    new Action(() =>
                    {
                        btnConsultar.Enabled = false;
                        btnConsultar.Text = "Consultando Base...";
                    }
                     ));

            ConsultaFatura();
        }

        private void backgroundWorkerFatura_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridOperacoesNao.DataSource = ListaFatura;
            dataGridOperacoesNao.AutoResizeColumn(5);
            dataGridOperacoesNao.Visible = true;
            pictureBox2.Visible = false;
            btnConsultar.BeginInvoke(
             new Action(() =>
             {
                 btnConsultar.Enabled = true;
                 btnConsultar.Text = "Consultar";
             }
              ));
        }

        private void backgroundRecarga_DoWork(object sender, DoWorkEventArgs e)
        {
            btnConsultar.BeginInvoke(
                   new Action(() =>
                   {
                       btnConsultar.Enabled = false;
                       btnConsultar.Text = "Consultando Base...";
                   }
                    ));

            ConsultaRecarga();
        }

        private void backgroundRecarga_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridOperacoesNao.DataSource = ListaRecarga;
            dataGridOperacoesNao.AutoResizeColumn(5);
            dataGridOperacoesNao.Visible = true;
            pictureBox2.Visible = false;
            btnConsultar.BeginInvoke(
             new Action(() =>
             {
                 btnConsultar.Enabled = true;
                 btnConsultar.Text = "Consultar";
             }
              ));
        }

        private void backgroundRecarga_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}
