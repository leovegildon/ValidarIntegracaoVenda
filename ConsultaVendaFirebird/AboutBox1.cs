using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutBox1_Load(object sender, EventArgs e)
        {

        }
    }
}
