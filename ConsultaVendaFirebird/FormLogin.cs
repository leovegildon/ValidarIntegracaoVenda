using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices;
using System.Data.OracleClient;
using System.Net;

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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        bool isValid;
        string nome, departamento;
        string nomedoDominio;
        string localBanco;
        string hostName = Dns.GetHostName();

        FormPai pai = new FormPai();
        private void button1_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "" && txtSenha.Text == "")
            {
                MessageBox.Show("Um ou mais campos obrigatórios não foram informados\n\n*Usuário\n*Senha", "Falha no Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtUsuario.Text == "" )
            {
                MessageBox.Show("Um ou mais campos obrigatórios não foram informados\n\n *Usuário", "Falha no Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtSenha.Text == "")
            {
                MessageBox.Show("Um ou mais campos obrigatórios não foram informados\n\n *Senha", "Falha no Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                DirectoryEntry lebiscuit = new DirectoryEntry("LDAP://"+nomedoDominio);
                DirectorySearcher busca = new DirectorySearcher(lebiscuit, "(&(objectClass=user)(objectCategory=person))");
                //busca.PropertiesToLoad.Add("department");
                busca.PropertiesToLoad.Add("cn");
                busca.PropertiesToLoad.Add("sAMAccountName");
                busca.PropertiesToLoad.Add("mail");
                busca.Sort.PropertyName = "sAMAccountName";
                busca.Filter = "(&(objectCategory=user)(objectClass=person)(samaccountname=" + txtUsuario.Text + "))"; ;
                foreach (SearchResult oRes in busca.FindAll())
                {
                    nome = oRes.Properties["cn"][0].ToString();
                    //departamento = oRes.Properties["department"][0].ToString();
                }
                
                pai.nome = nome;
                pai.usuarioLogado = txtUsuario.Text;
                pai.hostName = hostName;
                //MessageBox.Show(departamento);

                //if (departamento.Contains("TI_PROJETOS"))
                //{

                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, nomedoDominio))
                {
                    try
                    {
                        isValid = pc.ValidateCredentials(txtUsuario.Text, txtSenha.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    if (isValid == true)
                    {
                        timer1.Interval = 1000;
                        timer1.Start();
                        //groupBox1.Visible = false;
                        //label3.Visible = false;
                        //label4.Visible = false;
                        //lblBemVindoNome.Text = "Bem-Vindo " + nome.Substring(0,30);
                        //lblBemVindoNome.Visible = true;
                    }
                    if (isValid == false)
                    {
                        MessageBox.Show("Não foi possível acessar o sistema.\nVerifique suas credenciais e tente novamente", 
                            "Credenciais inválidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSenha.Text = "";
                    }

                }
                //}
                //else
                //{
                //    MessageBox.Show("Somente usuários da área de TI podem utilizar este programa.", "Acesso não permitido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    Application.Exit();
                //}
                
            }

            OracleConnection conn2 = new OracleConnection("Data Source=" + localBanco + "/INTEGRACAOSP;User Id=pdvuser;Password=pdv1234;Integrated Security=no");
            OracleCommand oCmd2 = new OracleCommand();
            string query2 = "INSERT INTO TLOG_VALIDADOR (TLOG_DATA, TLOG_USUARIO, TLOG_HOST, TLOG_OBS) VALUES (:DATAHORA, :USUARIO, :HOST, :OBS)";
            oCmd2.CommandText = query2;
            oCmd2.CommandType = CommandType.Text;
            oCmd2.Parameters.AddWithValue("DATAHORA", DateTime.Now);
            oCmd2.Parameters.AddWithValue("USUARIO", txtUsuario.Text);
            oCmd2.Parameters.AddWithValue("HOST", hostName);
            oCmd2.Parameters.AddWithValue("OBS", "Usuário logado!");
            oCmd2.Connection = conn2;
            conn2.Open();
            OracleDataReader ler2 = oCmd2.ExecuteReader();
            conn2.Close();

            //Gravando o usuário logado na variável publica da classe do formulário pai que será acessado pelos outros formulários
            //para gravar no log.

            //FormPai pai = new FormPai();


        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                    button1_Click(sender, e);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            nomedoDominio = ConfigINI.LerINI(@"configuracoes.ini", "[NomeDoDominio]");
            localBanco = ConfigINI.LerINI(@"configuracoes.ini", "[LocalBanco]");
            FormCloseButtonDisabler.DisableCloseButton(this.Handle.ToInt32());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pai.Show();
            this.Hide();
            timer1.Stop();
        }
    }
}
