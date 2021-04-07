using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string valor;

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            string baseDados = "";
            if(radioServidor.Checked == true)
            {
                baseDados = "C:\\proton\\pdv-server\\dat\\DBSRV.gdb";
            }
            if (radioPDV.Checked == true)
            {
                baseDados = "C:\\proton\\pdv-client\\dat\\DBMOV.gdb";
            }

            FbConnection fbConn = new FbConnection("DataSource=" + txtEstacao.Text + "; Database=" + baseDados + "; User=SYSDBA; Password=masterkey");

            FbCommand cmd = new FbCommand();
            try { 
            fbConn.Open();
            cmd.Connection = fbConn;
            cmd.CommandText = "select sum(a.tped_valor_liquido_pedido) from tped_pedido_venda a " +
                              "where a.tped_data_pedido = '"+maskedTextBox1.Text+"' " +
                              "and a.tped_status_pedido <> 'CA' " +
                              "and a.tped_tipo_venda in ('N','P','S','M')";
            FbDataReader ler = cmd.ExecuteReader();
            while (ler.Read())
            {
                valor = ler.GetValue(0).ToString();
            }
            fbConn.Close();
        }
        catch(Exception ex)
            {
                MessageBox.Show("Ocorreu um erro não previsto na aplicação."+
                              "\nUtilize a informação abaixo para facilitar o suporte.\n\n"+
                              "::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\n\n" + 
                              ex.Message + "\n\n"+ 
                              "::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::", 
                              "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lblVenda.Text = "R$"+valor;
            lblVenda.Visible = true;

        }

        private void txtEstacao_KeyPress(object sender, KeyPressEventArgs e){}
        private void txtData_KeyPress(object sender, KeyPressEventArgs e){}

        private void txtEstacao_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyData == Keys.Enter)
            {
                btnConsultar_Click(sender, e);
            }
        }

        private void txtData_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyData == Keys.Enter)
            {
                btnConsultar_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultaGeral consultaGeral = new ConsultaGeral();
            consultaGeral.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
