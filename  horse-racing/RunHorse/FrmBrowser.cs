using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shell;
using Common;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.Drawing.Printing;
using BussinesLogic;
using DataEntities;
using System.Globalization;

namespace RunHorse
{
    public partial class FrmBrowser : Form, IFrmBrowserView
    {
        private FrmBrowserPresenter Presenter { get; set; }
        private BLVentas objVen = null;
        private Seguridad objS = null;
        public IfrmPrincipalView Opener { get; set; }
        public FrmBrowser()
        {
            objVen = new BLVentas();
            objS = new Seguridad();
            InitializeComponent();
            webBrowser1.Navigating += new WebBrowserNavigatingEventHandler(Form1_Navigating);
            Presenter = new FrmBrowserPresenter(this);
        }

        private void Form1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string url = e.Url.ToString();
            if (url == "https://www.offtrackbetting.com/member/ticket")
            {
                webBrowser1.Url = new Uri("https://bet.offtrackbetting.com/start");
            }
        }

        public void Document_Click(object sender, HtmlElementEventArgs e)
        {
            //Obtien HtmlDocument
            HtmlDocument doc = sender as HtmlDocument;

            //Comprueba si don y doc.ActiveElement no son nulos
            if ((doc != null) && doc.ActiveElement != null)
            {
                if (doc.ActiveElement.Id == "placeBet")
                {
                    MessageBox.Show(string.Format("Id {0}, Name {1}", doc.ActiveElement.Id, doc.ActiveElement.Name));
                    this.webBrowser1.Document.Click -= new HtmlElementEventHandler(Document_Click);
                }
            }
            //Quita el evento para que la proxima vez que se pulse no salte dos veces
            this.webBrowser1.Document.Click -= new HtmlElementEventHandler(Document_Click);

        }



        public void Body_MouseDown(Object sender, HtmlElementEventArgs e)
        {
            switch (e.MouseButtonsPressed)
            {
                case MouseButtons.Left:
                    HtmlElement element = this.webBrowser1.Document.GetElementFromPoint(e.ClientMousePosition);
                    if (element.InnerText == "Full History")
                    {
                        MessageBox.Show("Para acceder a esta opción ingrese por el menú Archivo", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (element != null && element.Id != null && "SPAN".Equals(element.TagName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (element.Id.Contains("cancelHistory"))
                        {
                            MessageBox.Show("Para cancelar esta apuesta comuniquese con el Administrador del Sistema", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if ("A".Equals(element.TagName, StringComparison.OrdinalIgnoreCase) && element.InnerText == "Account Wagering Statement")
                    {
                        MessageBox.Show("No puede acceder a esta área.", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (element != null && element.Id != null && "A".Equals(element.TagName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (element.Id == "placeBet")
                        {
                            string a = element.Id;
                        }
                        if (element.Id == "eventlink")
                        {
                            MessageBox.Show("Para cancelar esta apuesta comuniquese con el Administrador del Sistema", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (element.Id.Contains("cancelReceipt"))
                        {

                            string info = webBrowser1.Document.GetElementById("betInfoTabReceipts").InnerHtml;
                            string[] Datos = info.Split(new Char[] { '\r', '\n' });
                            List<string> DatosV = new List<string>();
                            CultureInfo ci = new CultureInfo("en-US");
                            string fecha = DateTime.Today.ToString("MMM dd, yyyy");
                            foreach (string td in Datos)
                            {
                                if (td.Contains("<TD>") || td.Contains("Serial") || td.ToUpper().Contains(DateTime.Today.ToString("MMM dd, yyyy", ci).ToUpper()) || td.Contains("BET"))

                                    DatosV.Add(td.Replace("<TD>", "").Replace("</TD>", "").Replace("<TD align=right>", "").Replace("<SPAN>", "").Replace("</SPAN>", "").Replace("</TR>", "").Replace("<B>", "").Replace("</B>", "").Replace("</TR>", ""));
                            }
                            this.NumTicket = DatosV[4].Replace("Serial #: ", "");
                            if (objVen.EsVentaPropia(this.NumTicket, GlobalVars.idUsuario))
                            {
                                this.Presenter.CancelarApuesta();
                                this.Opener.ActualizarValorRestante();
                            }
                            else
                                MessageBox.Show("No puede cancelar un ticket que no ha sido impreso o no fue impreso por usted.\r\nPara cancelar este ticket comuniquese con el administrador del sistema", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (element != null && "BUTTON".Equals(element.TagName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (element.InnerText == "OK")
                        {
                            string a = webBrowser1.Document.GetElementById("bet_selection").InnerText;
                            string b = webBrowser1.Document.GetElementById("myAccountBalance").InnerText;
                            string c = webBrowser1.Document.GetElementById("YourTicketTotal").InnerText;
                            b = b.Replace("$", "").Replace(",", "").Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
                            c = c.Replace("$", "").Replace(",", "").Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
                            decimal ValorApuestaC = Convert.ToDecimal(c);
                            decimal ValorRestante = Convert.ToDecimal(b);
                            decimal ValorApuestaUsuario = objS.CupoDisponible(GlobalVars.idUsuario);
                            decimal ValorApuestaEntidad = objS.CupoDisponibleEntidad();
                            if (ValorApuestaC == 0)
                            {
                                MessageBox.Show("No se puede hacer una apuesta por USD$0.00. Espere un momento.", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            if (a != "" && a != null)
                            {
                                if (ValorApuestaEntidad >= ValorApuestaC)
                                {
                                    if (ValorApuestaUsuario >= ValorApuestaC)
                                    {
                                        if (ValorRestante >= ValorApuestaC)
                                        {
                                            this.ValorApuesta = ValorApuestaC;
                                            this.Presenter.GuardarApuesta();
                                            this.Opener.ActualizarValorRestante();
                                            this.menuItemImprimir.Enabled = false;
                                            this.PuedeImprimir = false;
                                            this.timer1.Enabled = true;
                                            this.timer1.Start();
                                        }
                                        else
                                        {
                                            //object[] args = { "El valor de la apuesta supera el monto disponible" };
                                            //webBrowser1.Document.InvokeScript("alert", args);
                                            MessageBox.Show("El valor de la apuesta supera el monto disponible", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        //object[] args = { "El valor de la apuesta supera el restante de su\r\ncupo disponible para apuestas" };
                                        //webBrowser1.Document.InvokeScript("alert", args);
                                        MessageBox.Show("El valor de la apuesta supera el restante de su\r\ncupo disponible para apuestas", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    //object[] args = { "El valor de la apuesta supera el restante del \r\ncupo disponible para apuestas de la entidad" };
                                    //webBrowser1.Document.InvokeScript("alert", args);
                                    MessageBox.Show("El valor de la apuesta supera el restante del \r\ncupo disponible para apuestas de la entidad", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }


                        }

                    }
                    break;
            }
        }

        private void FrmBrowser_Load(object sender, EventArgs e)
        {
            Presenter.Inicializar();
            this.webBrowser1.Url = new Uri(this.urlInicio);
        }

        string _urlInicio;
        public string urlInicio
        {
            get
            {
                return _urlInicio;
            }
            set
            {
                _urlInicio = value;
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            for (int i = 0; i < this.webBrowser1.Document.Links.Count; i++)
            {
                if (webBrowser1.Document.Links[i].InnerText == "Scratches & Changes" || webBrowser1.Document.Links[i].InnerHtml == "Preferences"
                        || webBrowser1.Document.Links[i].InnerHtml == "Store" || webBrowser1.Document.Links[i].InnerHtml == "Fund"
                        || webBrowser1.Document.Links[i].InnerHtml == "Help" || webBrowser1.Document.Links[i].InnerHtml == "Account Wagering Statement"
                        || webBrowser1.Document.Links[i].InnerHtml == "Full History")
                {
                    webBrowser1.Document.Links[i].Style = "display: none;";
                }
            }

            if (webBrowser1.Url.ToString() == this.urlInicio + "/")
            {
                if (webBrowser1.Document.GetElementById("accountNumber") != null)
                {
                    webBrowser1.Document.GetElementById("accountNumber").InnerText = Utilidades.DecryptKey(UtilPresenter.ObtenerValorParametro("USUARIO_SITIO_1"));
                    webBrowser1.Document.GetElementById("pin").InnerText = Utilidades.DecryptKey(UtilPresenter.ObtenerValorParametro("PWD_SITIO_1"));
                    webBrowser1.Document.Forms[0].InvokeMember("submit");
                }
            }

            this.webBrowser1.Document.Body.MouseDown -= new HtmlElementEventHandler(Body_MouseDown);
            this.webBrowser1.Document.Body.MouseDown += new HtmlElementEventHandler(Body_MouseDown);
            ((WebBrowser)sender).Document.Window.Error +=
        new HtmlElementErrorEventHandler(Window_Error);
        }

        private void SuppressScriptErrorsOnly(WebBrowser browser)
        {
            // Ensure that ScriptErrorsSuppressed is set to false.
            browser.ScriptErrorsSuppressed = true;

            // Handle DocumentCompleted to gain access to the Document object.
            browser.DocumentCompleted +=
                new WebBrowserDocumentCompletedEventHandler(
                    webBrowser1_DocumentCompleted);
        }

        private void Window_Error(object sender,
    HtmlElementErrorEventArgs e)
        {
            // Ignore the error and suppress the error dialog box. 
            e.Handled = true;
        }


        private void menuItemImprimir_Click(object sender, EventArgs e)
        {
            if (webBrowser1.Document.GetElementById("betInfoTabReceipts") != null)
            {
                string info = webBrowser1.Document.GetElementById("betInfoTabReceipts").InnerHtml;
                string[] Datos = info.Split(new Char[] { '\r', '\n' });
                List<string> DatosV = new List<string>();
                CultureInfo ci = new CultureInfo("en-US");
                string fecha = DateTime.Today.ToString("MMM dd, yyyy", ci);
                foreach (string td in Datos)
                {
                    if (td.Contains("<TD>") || td.Contains("Serial") || td.ToUpper().Contains(DateTime.Today.ToString("MMM dd, yyyy", ci).ToUpper()) || td.Contains("BET") || td.Contains("Bet Rejected"))
                        DatosV.Add(td.Replace("<TD>", "").Replace("</TD>", "").Replace("<TD align=right>", "").Replace("<SPAN>", "").Replace("</SPAN>", "").Replace("</TR>", "").Replace("<B>", "").Replace("</B>", "").Replace("</TR>", "").Replace("<SPAN class=rejected>", ""));
                }
                if (DatosV[1] == "BET CANCELED")
                {
                    MessageBox.Show("El Ticket no se puede imprimir la apuesta fue Cancelada", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (DatosV[1].ToUpper() == "BET REJECTED")
                {
                    objVen.EliminarPorId(this.idUltimaVenta);
                    this.Opener.ActualizarValorRestante();
                    MessageBox.Show("El Ticket no se puede imprimir la apuesta fue Rechazada", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                this.NumTicket = DatosV[4].Replace("Serial #: ", "");
                this.Carrera = DatosV[3];
                this.TipoApuesta = DatosV[5];
                this.Seleccion = DatosV[6];

                this.Presenter.TicketExiste();
                if (this.TicketExiste)
                {
                    MessageBox.Show("El Ticket ya fue Impreso, La impresión fue Cancelada", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (this.NumTicket == null || this.NumTicket == "")
                {
                    MessageBox.Show("No se puede imprimir el ticket aún, intentelo nuevamente", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                ventas venta = objVen.ObtenerVentaporId(this.idUltimaVenta);
                venta.Valor = decimal.Parse(DatosV[7].Replace("Total: ", "").Replace("$", "").Replace(",", "").Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator));
                this.Presenter.ActualizarTicketVenta();
                entidad ent = objS.ObtenerEntidad();
                if (venta.Valor.Value != decimal.Parse(DatosV[7].Replace("Total: ", "").Replace("$", "").Replace(",", "").Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator)))
                {
                    MessageBox.Show("No se puede imprimir un Ticket vendido por otro usuario", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                DatosV.Add(venta.ValorCop.Value.ToString("C2"));
                DatosV.Add(venta.ValorAdm.Value.ToString("C2"));
                DatosV.Add(venta.IVA.Value.ToString("C2"));
                DatosV.Add(venta.NroFactura.Value.ToString());
                DatosV.Add((venta.ValorCop.Value + venta.ValorAdm.Value + venta.IVA.Value).ToString("C2"));
                DatosV.Add(this.TRM.ToString("C2"));
                DatosV.Add(ent.Nit);
                DatosV.Add(ent.Nombre);
                DatosV.Add(ent.Eslogan);
                ImprimirInforme(DatosV);
                this.Presenter.ActualizarTicketVenta();
            }
        }

        private void ImprimirInforme(List<string> Datos)
        {
            DataTable dt = new DataTable("Ticket");
            dt.Columns.Add("CARRERA", typeof(string));
            dt.Columns.Add("APUESTA", typeof(string));
            dt.Columns.Add("SELECCION", typeof(string));
            dt.Columns.Add("FECHA", typeof(string));
            dt.Columns.Add("SERIAL", typeof(string));
            dt.Columns.Add("TOTAL", typeof(string));
            dt.Columns.Add("ESTADO", typeof(string));
            dt.Columns.Add("VENDEDOR", typeof(string));
            dt.Columns.Add("NIT", typeof(string));
            dt.Columns.Add("NOMBRE", typeof(string));
            dt.Columns.Add("ESLOGAN", typeof(string));
            dt.Columns.Add("IVA", typeof(string));
            dt.Columns.Add("VALOR_COP", typeof(string));
            dt.Columns.Add("COSTOS_ADM", typeof(string));
            dt.Columns.Add("VALORTOTAL", typeof(string));
            dt.Columns.Add("TRM", typeof(string));
            dt.Columns.Add("NUMERO", typeof(string));

            DataRow dr = dt.NewRow();
            dr["CARRERA"] = Datos[3];
            dr["APUESTA"] = Datos[5];
            dr["SELECCION"] = Datos[6];
            dr["FECHA"] = Datos[2];
            dr["SERIAL"] = Datos[4];
            dr["TOTAL"] = Datos[7];
            dr["ESTADO"] = Datos[0] + " " + Datos[1];
            dr["VENDEDOR"] = GlobalVars.NombreUsuario;
            dr["NIT"] = Datos[14];
            dr["NOMBRE"] = Datos[15];
            dr["ESLOGAN"] = Datos[16];
            dr["IVA"] = Datos[10];
            dr["VALOR_COP"] = Datos[8];
            dr["COSTOS_ADM"] = Datos[9];
            dr["TRM"] = Datos[13];
            dr["NUMERO"] = Datos[11];
            dr["VALORTOTAL"] = Datos[12];

            dt.Rows.Add(dr);


            ReportDocument rpt = new ReportDocument();
            string rutarpt = Application.StartupPath + "\\Reportes\\rptTicket.rpt";
            rpt.Load(rutarpt);
            rpt.SetDataSource(dt);
            PrinterSettings getprinterName = new PrinterSettings();
            rpt.PrintOptions.PrinterName = getprinterName.PrinterName;
            rpt.PrintToPrinter(1, true, 1, 1);
        }

        decimal _ValorApuesta;
        public decimal ValorApuesta
        {
            get
            {
                return _ValorApuesta;
            }
            set
            {
                _ValorApuesta = value;
            }
        }

        public Guid IdUsuario
        {
            get { return GlobalVars.idUsuario; }
        }


        public Guid idUltimaVenta
        {
            get
            {
                return objS.UltimaVenta(GlobalVars.idUsuario);
            }
            set
            {
                usuario u = objS.ObtenerUsuarioporId(GlobalVars.idUsuario);
                u.IdUltimaVenta = value;
                objS.Actualizar(u);
            }
        }

        private string _NumTicket;
        public string NumTicket
        {
            get
            {
                return _NumTicket;
            }
            set
            {
                _NumTicket = value;
            }
        }

        private bool _TicketExiste;
        public bool TicketExiste
        {
            get
            {
                return _TicketExiste;
            }
            set
            {
                _TicketExiste = value;
            }
        }

        public decimal IVA
        {
            get
            {
                return decimal.Parse(UtilPresenter.ObtenerValorParametro("IVA")) / 100;
            }
        }

        public decimal TRM
        {
            get
            {
                return decimal.Parse(UtilPresenter.ObtenerValorParametro("VALOR_TRM"));
            }
        }

        private decimal _ValorCOP;
        public decimal ValorCOP
        {
            get
            {
                return _ValorCOP;
            }
            set
            {
                _ValorCOP = value;
            }
        }

        public decimal ValoAdm
        {
            get
            {
                return decimal.Parse(UtilPresenter.ObtenerValorParametro("VALOR_ADM"));
            }
        }

        private string _Seleccion;
        public string Seleccion
        {
            get
            {
                return _Seleccion;
            }
            set
            {
                _Seleccion = value;
            }
        }

        private string _TipoApuesta;
        public string TipoApuesta
        {
            get
            {
                return _TipoApuesta;
            }
            set
            {
                _TipoApuesta = value;
            }
        }

        private string _Carrera;
        public string Carrera
        {
            get
            {
                return _Carrera;
            }
            set
            {
                _Carrera = value;
            }
        }

        private bool _PuedeImprimir = true;
        public bool PuedeImprimir
        {
            get
            {
                return _PuedeImprimir;
            }
            set
            {
                _PuedeImprimir = value;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string info = webBrowser1.Document.GetElementById("betInfoTabReceipts").InnerHtml;
            string[] Datos = info.Split(new Char[] { '\r', '\n' });
            List<string> DatosV = new List<string>();
            CultureInfo ci = new CultureInfo("en-US");
            string fecha = DateTime.Today.ToString("MMM dd, yyyy", ci);
            foreach (string td in Datos)
            {
                if (td.Contains("<TD>") || td.Contains("Serial") || td.ToUpper().Contains(DateTime.Today.ToString("MMM dd, yyyy", ci).ToUpper()) || td.Contains("BET") || td.Contains("Bet Rejected"))
                    DatosV.Add(td.Replace("<TD>", "").Replace("</TD>", "").Replace("<TD align=right>", "").Replace("<SPAN>", "").Replace("</SPAN>", "").Replace("</TR>", "").Replace("<B>", "").Replace("</B>", "").Replace("</TR>", "").Replace("<SPAN class=rejected>", ""));
            }
            if (DatosV.Count > 0)
                if (DatosV[4].Replace("Serial #: ", "") != this.NumTicket)
                {
                    PuedeImprimir = true;
                    this.menuItemImprimir.Enabled = true;
                    this.timer1.Stop();
                    this.timer1.Enabled = false;
                }

        }
    }
}
