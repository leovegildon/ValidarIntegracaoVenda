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
    public partial class VisualizaDetalheVenda : Form
    {
        public VisualizaDetalheVenda()
        {
            InitializeComponent();
        }

        

        List<string> Lojas = new List<string>();
        List<string> Centros = new List<string>();
        List<CapaVenda> ListaCapaVenda = new List<CapaVenda>();
        List<ItensVenda> ListaItensVenda = new List<ItensVenda>();
        List<FormasdePagamento> ListaFormasdePagamento = new List<FormasdePagamento>();
        string vendaOracle;
        string[] lojasArray;
        string[] centrosArray;
        string IDVENDA = "0", CUPOM, SAP_, PDV_, CPF_, BRUTO, DESCONTO, LIQUIDO, CHNFCE;
        string localBanco;

        class CapaVenda
        {
            public string ID { get; set; }
            public string Cupom { get; set; }
            public string SAP { get; set; }
            public string PDV { get; set; }
            public string CPF { get; set; }
            public string Bruto { get; set; }
            public string Desconto { get; set; }
            public string Liquido { get; set; }
            public string ChaveNFCe { get; set; }
        }

        class ItensVenda
        {
            public string Num { get; set; }
            public string Codigo { get; set; }
            public string Descricao { get; set; }
            public string Quant { get; set; }
            public string Unitario { get; set; }
            public string Desconto { get; set; }
            public string Total { get; set; }
        }

        class FormasdePagamento
        {
            public string COD { get; set; }
            public string Tipo { get; set; }
            public string Cartao { get; set; }
            public string NSU { get; set; }
            public string Troca { get; set; }
            public string Rede { get; set; }
            public string Parcelas { get; set; }
            public string Recebido { get; set; }
            public string Troco { get; set; }
        }

        private void VisualizaDetalheVenda_Load(object sender, EventArgs e)
        {
            localBanco = ConfigINI.LerINI(@"configuracoes.ini", "[LocalBanco]");
            comboLojas.DropDownStyle = ComboBoxStyle.DropDownList;
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

            comboLojas.DataSource = Lojas;
            lojasArray = Lojas.ToArray();
            centrosArray = Centros.ToArray();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtDataIni.TextLength != 10)
            {
                MessageBox.Show("Informe o período.");
            }
            else
            {
                dataGridCapa.DataSource = null;
                dataGridCapa.Rows.Clear();
                dataGridCapa.Columns.Clear();
                ListaCapaVenda.Clear();

                //CAPA

                OracleConnection conn = new OracleConnection("Data Source=" + localBanco + "/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
                OracleCommand oCmd = new OracleCommand();
                string query = "SELECT t.id_pk, t.numero_transacao_uk, " +
                                "c.tcxa_numecf_nfce, c.tcxa_nome, t.documento_consumidor, t.valor_bruto, " +
                                "t.valor_desconto, t.valor_liquido, n.cod_acesso_nfe " +
                                    "FROM TTRANSACAO t " +
                                    "join tloja_sap s " +
                                    "on t.numero_loja_uk = s.loja_proton_uk " +
                                    "join tcxa_caixa c on t.numero_pdv_uk = c.tcxa_caixa_pk " +
                                    "and t.numero_serie_impressora_uk = c.tcxa_numero_serial_ecf " +
                                    "left join ttransacao_nfce n " +
                                    "on t.id_pk = n.transacao_fk_uk " +
                                    "WHERE TRUNC(t.data_hora_transacao_uk) between :DATAINI and :DATAFIM " +
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
                oCmd.Parameters.AddWithValue(":DATAINI", txtDataIni.Text);
                oCmd.Parameters.AddWithValue(":DATAFIM", txtDataFim.Text);
                oCmd.Parameters.AddWithValue(":CENTROORA", centrosArray[comboLojas.SelectedIndex]);
                oCmd.Connection = conn;

                conn.Open();
                OracleDataReader ler = oCmd.ExecuteReader();
                while (ler.Read())
                {
                    IDVENDA = ler.GetValue(0).ToString();
                    CUPOM = ler.GetValue(1).ToString();
                    SAP_ = ler.GetValue(2).ToString();
                    PDV_ = ler.GetValue(3).ToString();
                    CPF_ = ler.GetValue(4).ToString();
                    BRUTO = ler.GetValue(5).ToString();
                    DESCONTO = ler.GetValue(6).ToString();
                    LIQUIDO = ler.GetValue(7).ToString();
                    CHNFCE = ler.GetValue(8).ToString();

                    //Forma burra de preencher o list. Ajustar depois para a melhor prática, conforme
                    //foi feito na lista dos meios de pagamento e itens da venda.
                    ListaCapaVenda.Add(new CapaVenda() { ID = IDVENDA, Cupom = CUPOM, SAP = SAP_, PDV = PDV_, CPF = CPF_, Bruto = BRUTO, Desconto = DESCONTO, Liquido = LIQUIDO, ChaveNFCe = CHNFCE });
                }
                conn.Close();

                dataGridCapa.DataSource = ListaCapaVenda;
                dataGridCapa.AutoResizeColumn(1);

                //Total da venda. Para preencher a label do total da venda.

                OracleConnection conn3 = new OracleConnection("Data Source=" + localBanco + "/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
                OracleCommand oCmd3 = new OracleCommand();
                //wait.lblProgresso.Text = i.ToString();
                string query3 = "SELECT sum(t.valor_liquido) venda " +
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

                oCmd3.CommandText = query3;
                oCmd3.CommandType = CommandType.Text;
                oCmd3.Parameters.AddWithValue(":DATAORA1", txtDataIni.Text);
                oCmd3.Parameters.AddWithValue(":DATAORA2", txtDataFim.Text);
                oCmd3.Parameters.AddWithValue(":CENTROORA", centrosArray[comboLojas.SelectedIndex]);
                oCmd3.Connection = conn3;

                conn3.Open();
                OracleDataReader ler3 = oCmd3.ExecuteReader();
                while (ler3.Read())
                {
                    vendaOracle = ler3.GetValue(0).ToString();
                }

                if (vendaOracle == "")
                {
                    vendaOracle = "0";
                }
                lblTotalVenda.Text = vendaOracle;
                conn.Close();
            }
        }

        private void dataGridCapa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridRecebimentos.DataSource = null;
            dataGridItens.DataSource = null;
            dataGridRecebimentos.Rows.Clear();
            dataGridItens.Rows.Clear();
            dataGridRecebimentos.Columns.Clear();
            dataGridItens.Columns.Clear();
            ListaFormasdePagamento.Clear();
            ListaItensVenda.Clear();

            //Formas de pagamento

            OracleConnection conn = new OracleConnection("Data Source=" + localBanco + "/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd = new OracleCommand();
            string query = "select " +
                            "r.numero_recebimento_uk as COD, " +
                            "case  " +
                              "when r.tipo_recebimento = 0 " +
                                "then 'TROCA' " +
                                    "when r.tipo_recebimento = 8 " +
                                "then 'LE CASAMENTO' " +
                                    "when r.tipo_recebimento = 13 " +
                                "then 'VALE DESCONTO' " +
                                    "when r.tipo_recebimento = 14 " +
                                "then 'SINISTRO CELULAR' " +
                              "when r.tipo_recebimento = 1 " +
                                "then 'DINHEIRO' " +
                                  "WHEN r.tipo_recebimento = 7 " +
                                    "then 'CARTAO' " +
                                      "WHEN r.tipo_recebimento = 6 " +
                                        "then 'BOLETO' " +
                                          "else '0' " +
                                          "end as TIPO, " +
                            "c.ttes_nome as CARTAO, " +
                            "r.nsu as NSU, " +
                            "r.numero_troca as TROCA, " +
                            "d.ttes_nome as REDE, " +
                            "r.numero_parcela as PARCELA, " +
                            "r.valor_recebido as RECEBIDO, " +
                            "r.valor_troco as TROCO " +
                            "from " +
                            "ttransacao t  " +
                            "join ttransacao_recebimentos r on t.id_pk = r.transacao_fk_uk " +
                            "left join ttes_cartao_credito c on r.codigo_cartao_proton = c.ttes_cartao_credito_pk and t.numero_loja_uk = c.ttes_unidade_fk_pk " +
                            "left join ttes_rede_cartao d on r.codigo_rede = d.ttes_rede_cartao_pk " +
                            "where r.transacao_fk_uk = :IDCAPA";

            oCmd.CommandText = query;
            oCmd.CommandType = CommandType.Text;
            oCmd.Parameters.AddWithValue(":IDCAPA", dataGridCapa.CurrentRow.Cells[0].Value.ToString());
            oCmd.Connection = conn;

            conn.Open();
            OracleDataReader ler = oCmd.ExecuteReader();
            while (ler.Read())
            {
                IDVENDA = ler.GetValue(0).ToString();
                ListaFormasdePagamento.Add(new FormasdePagamento() { COD = ler.GetValue(0).ToString(), 
                                                                     Tipo = ler.GetValue(1).ToString(), 
                                                                     Cartao = ler.GetValue(2).ToString(),
                                                                     NSU = ler.GetValue(3).ToString(),
                                                                     Troca = ler.GetValue(4).ToString(),
                                                                     Rede = ler.GetValue(5).ToString(),
                                                                     Parcelas = ler.GetValue(6).ToString(),
                                                                     Recebido = ler.GetValue(7).ToString(),
                                                                     Troco = ler.GetValue(8).ToString() });
            }
            conn.Close();

            dataGridRecebimentos.DataSource = ListaFormasdePagamento;
            dataGridRecebimentos.AutoResizeColumn(2);


            //Itens da venda

            OracleConnection conn2 = new OracleConnection("Data Source=" + localBanco + "/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd2 = new OracleCommand();
            string query2 = "select " +
                                "i.numero_item_uk as NUM, " +
                                "m.tmer_codigo_barras_ukn as CODIGO, " +
                                "m.tmer_nome as DESCRICAO, " +
                                "i.quantidade as QTD, " +
                                "i.valor_unitario as UNITARIO, " +
                                "i.valor_desconto as DESCONTO, " +
                                "sum((i.valor_unitario * i.quantidade) - i.valor_desconto) as TOTAL " +
                                "from ttransacao_item i  " +
                                "join tmer_mercadoria m on i.codigo_primario_uk = m.tmer_codigo_pri_pk " +
                                "and i.codigo_secundario_uk = m.tmer_codigo_sec_pk " +
                                "where i.transacao_fk_uk = :IDCAPA " +
                                "group by i.numero_item_uk, m.tmer_codigo_barras_ukn, m.tmer_nome, i.quantidade, i.valor_unitario, i.valor_desconto " +
                                "order by 1  ";

            oCmd2.CommandText = query2;
            oCmd2.CommandType = CommandType.Text;
            oCmd2.Parameters.AddWithValue(":IDCAPA", dataGridCapa.CurrentRow.Cells[0].Value.ToString());
            oCmd2.Connection = conn2;

            conn2.Open();
            OracleDataReader ler2 = oCmd2.ExecuteReader();
            while (ler2.Read())
            {
                IDVENDA = ler2.GetValue(0).ToString();
                ListaItensVenda.Add(new ItensVenda()
                {
                    Num = ler2.GetValue(0).ToString(),
                    Codigo = ler2.GetValue(1).ToString(),
                    Descricao = ler2.GetValue(2).ToString(),
                    Quant = ler2.GetValue(3).ToString(),
                    Unitario = ler2.GetValue(4).ToString(),
                    Desconto = ler2.GetValue(5).ToString(),
                    Total = ler2.GetValue(6).ToString(),
                });
            }
            conn2.Close();

            dataGridItens.DataSource = ListaItensVenda;
            dataGridItens.AutoResizeColumn(2);

            
        }

        private void txtDataIni_TextChanged(object sender, EventArgs e)
        {
            txtDataFim.Text = txtDataIni.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridCapa.Rows.Count == 0)
            {
                MessageBox.Show("Não existe nenhum registro selecionado.\nSelecione um registro e tente novamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string target = "http://nfe.sefaz.ba.gov.br/servicos/nfce/Modulos/Geral/NFCEC_consulta_chave_acesso.aspx?cod_chave_acesso_param=" + dataGridCapa.CurrentRow.Cells[8].Value.ToString();
                System.Diagnostics.Process.Start(target);
            }
        }
    }
}
