using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

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
    public partial class FormWait : Form
    {
        public FormWait()
        {
            InitializeComponent();
        }

        string statusPing;
        string nomedoDominio;

        private void FormWait_Load(object sender, EventArgs e)
        {
            nomedoDominio = ConfigINI.LerINI(@"configuracoes.ini", "[NomeDoDominio]");
            timerMensagens.Interval = 3000;
            timerConectando.Interval = 2000;
            timerMensagens.Start();
            timerConectando.Start();
        }

        private void timerMensagens_Tick(object sender, EventArgs e)
        {
            try
            {
                Ping pingar = new Ping();
                PingReply pingado = pingar.Send(nomedoDominio);
                statusPing = pingado.Status.ToString();
            }
            catch(Exception ex)
            {
                timerMensagens.Stop();
                MessageBox.Show("Não foi possível acessar o servidor de domínio.\nVerifique o arquivo de configurações ou o acesso ao servidor de domínio.\n\n" + ex.Message,
                "Erro",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (statusPing == "Success")
            {
                FormLogin login = new FormLogin();
                login.Show();
                timerMensagens.Stop();
                this.Hide();
            }

            else
            {
                timerMensagens.Stop();
                MessageBox.Show("Não há servidores de login disponíveis.\nVerificar a conexão com o Active Directory.",
                    "Falha no login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void timerConectando_Tick(object sender, EventArgs e)
        {
            lblConectando.Visible = true;
        }
    }
}
