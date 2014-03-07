using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Skybound.Gecko.DOM;
using Skybound.Gecko;
using Common;
using Shell;

namespace RunHorse
{
    public partial class FormHistory : Form
    {
        public FormHistory()
        {
            InitializeComponent();
            Skybound.Gecko.Xpcom.Initialize(@"C:\Program Files (x86)\xulrunner");
            geckoWebBrowser1.Navigating += new Skybound.Gecko.GeckoNavigatingEventHandler(Form1_Navigating);
        }

        private void Form1_Navigating(object sender, GeckoNavigatingEventArgs e)
        {
            string url = e.Uri.ToString();
            if (url == "https://bet.offtrackbetting.com/video" || url == "https://bet.offtrackbetting.com/accountwageringstatement" || url == "https://bet.offtrackbetting.com/results" ||
                url == "https://bet.offtrackbetting.com/results" || url == "https://bet.offtrackbetting.com/scratches" || url == "https://bet.offtrackbetting.com/shop" || url == "https://bet.offtrackbetting.com/preferences" ||
                url == "https://bet.offtrackbetting.com/funding")
            {
                MessageBox.Show("No puede acceder a esta área.", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                geckoWebBrowser1.Navigate("https://bet.offtrackbetting.com/history");
            }
            else if (url == "https://www.offtrackbetting.com/member/ticket")
            {
                geckoWebBrowser1.Navigate("https://bet.offtrackbetting.com/history");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.geckoWebBrowser1.Navigate("https://www.offtrackbetting.com/");

        }

        private void geckoWebBrowser1_Click(object sender, EventArgs e)
        {

        }

        private void geckoWebBrowser1_DocumentCompleted(object sender, EventArgs e)
        {
            for (int i = 0; i < this.geckoWebBrowser1.Document.Links.Count(); i++)
            {
                if (geckoWebBrowser1.Document.Links[i].InnerHtml == "Scratches &amp; Changes" || geckoWebBrowser1.Document.Links[i].InnerHtml == "Preferences"
                    || geckoWebBrowser1.Document.Links[i].InnerHtml == "Store" || geckoWebBrowser1.Document.Links[i].InnerHtml == "Fund"
                    || geckoWebBrowser1.Document.Links[i].InnerHtml == "Help" || geckoWebBrowser1.Document.Links[i].InnerHtml == "Account Wagering Statement"
                    || geckoWebBrowser1.Document.Links[i].InnerHtml == "Live Video &amp; Race Replays" || geckoWebBrowser1.Document.Links[i].InnerHtml == "Results")
                {
                    geckoWebBrowser1.Document.Links[i].SetAttribute("style", "display: none;");
                    //
                }
            }
            if (geckoWebBrowser1.Url.ToString() == "https://www.offtrackbetting.com/")
            {
                if (geckoWebBrowser1.Document.GetElementById("accountNumber") != null)
                {
                    GeckoInputElement username = new GeckoInputElement(geckoWebBrowser1.Document.GetElementsByName("accountNumber")[0].DomObject);
                    GeckoInputElement password = new GeckoInputElement(geckoWebBrowser1.Document.GetElementsByName("pin")[0].DomObject);
                    GeckoInputElement login = new GeckoInputElement(geckoWebBrowser1.Document.GetElementsByName("login")[0].DomObject);
                    username.Value = Utilidades.DecryptKey(UtilPresenter.ObtenerValorParametro("USUARIO_SITIO_1"));
                    password.Value = Utilidades.DecryptKey(UtilPresenter.ObtenerValorParametro("PWD_SITIO_1"));
                    login.click();
                }
            }

        }

        private void geckoWebBrowser1_DomClick(object sender, GeckoDomEventArgs e)
        {
            GeckoElement element = e.Target;
            if (e.Target.Id.Contains("eventlink"))
            {
                e.Handled = true;
                element.SetAttribute("style", "display: none;");
                MessageBox.Show("Para cancelar esta apuesta comuniquese con el Administrador del Sistema", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void geckoWebBrowser1_DomMouseDown(object sender, GeckoDomMouseEventArgs e)
        {
            GeckoElement element = e.Target;
            if (e.Target.Id.Contains("eventlink"))
            {
                e.Handled = true;
                element.SetAttribute("style", "display: none;");
                MessageBox.Show("Para cancelar esta apuesta comuniquese con el Administrador del Sistema", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }      
        }
    }
}
