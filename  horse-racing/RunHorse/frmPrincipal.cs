using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shell;
using BussinesLogic;
using DataEntities;

namespace RunHorse
{
    public partial class frmPrincipal : Form, IfrmPrincipalView
    {
        private frmPrincipalPresenter Presenter { get; set; }
        private Seguridad objS = null;
        public frmPrincipal()
        {
            InitializeComponent();
            Presenter = new frmPrincipalPresenter(this);
            objS = new Seguridad();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ActualizarValorRestante();
            this.lbUsuarioActivo.Text += ": " + GlobalVars.NombreUsuario;
            this.CrearMenu(menuStrip1);
        }

        decimal _valorVentasDia;
        public decimal valorVentasDia
        {
            get
            {
                return _valorVentasDia;
            }
            set
            {
                _valorVentasDia = value;
            }
        }


        public Guid idUsuario
        {
            get { return GlobalVars.idUsuario; }
        }

        public void ActualizarValorRestante()
        {
            Presenter.ValorVentas();
            this.lbValor.Text = (this.valorVentasDia).ToString("C2");
        }

        private void CrearMenu(MenuStrip Menu)
        {
            this.Presenter.ListarPadres();
            foreach (DataEntities.menu m in this.menuPadres)
            {
                this.idMenuPadre = m.Id;
                this.Presenter.UsuarioenRol(m.Id);
                if (this.isUserinRol)
                {
                    ToolStripMenuItem menu = new ToolStripMenuItem(m.MenuName);
                    menu.Text = m.MenuText;
                    AddSubMenu(menu);
                    Menu.Items.Add(menu);
                }
            }
        }

        private void AddSubMenu(ToolStripMenuItem Menu)
        {
            this.Presenter.ListarHijos();
            foreach (DataEntities.menu sm in menuHijos)
            {
                this.Presenter.UsuarioenRol(sm.Id);
                if (this.isUserinRol)
                {
                    ToolStripMenuItem subMenu = new ToolStripMenuItem(sm.MenuName);
                    subMenu.Text = sm.MenuText;
                    subMenu.Tag = sm.NombreForm;
                    Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { subMenu });
                    subMenu.Click -= new EventHandler(MenuClick);
                    subMenu.Click += new EventHandler(MenuClick);
                }
                //AddSubMenu(subMenu);
            }
        }

        private void MenuClick(object sender, EventArgs e)
        {
            if (!FormularioEstaAbierto(((ToolStripMenuItem)sender).Tag.ToString()))
            {
                if (((ToolStripMenuItem)sender).Tag.ToString() == "FrmBrowser")
                {
                    FrmBrowser frmB = new FrmBrowser();
                    frmB.MdiParent = this;
                    frmB.WindowState = FormWindowState.Normal;
                    frmB.Opener = this;
                    frmB.Show();
                    frmB.WindowState = FormWindowState.Maximized;
                }
                else if (((ToolStripMenuItem)sender).Text.ToString() == "Cupo Global")
                {
                    entidad ent = objS.ObtenerEntidad();
                    MessageBox.Show("El cupo disponible de la Entidad es de (US)" + ent.CupoDisponible.Value.ToString("C2"), "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string sFormName = "RunHorse." + ((ToolStripMenuItem)sender).Tag.ToString();
                    System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
                    Form frm = (Form)asm.CreateInstance(sFormName);
                    frm.Name = ((ToolStripMenuItem)sender).Tag.ToString();
                    frm.Text = "Horse Racing Soft 2.0 - " + ((ToolStripMenuItem)sender).Text.ToString();
                    frm.MdiParent = this;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Show();
                    frm.WindowState = ((ToolStripMenuItem)sender).Tag.ToString() == "FormHistory" ? FormWindowState.Maximized : FormWindowState.Normal;
                }
            }
        }

        private Boolean FormularioEstaAbierto(String NombreDelFrm)
        {
            if (this.MdiChildren.Length > 0)
            {
                for (int i = 0; i < this.MdiChildren.Length; i++)
                {
                    //MessageBox.Show(NombreDelFrm.Substring(NombreDelFrm.IndexOf("Frm_"), NombreDelFrm.Length - NombreDelFrm.IndexOf("Frm_")));
                    if (this.MdiChildren[i].Name == NombreDelFrm)
                    {
                        MessageBox.Show("El formulario solicitado ya se encuentra abierto", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return true;
                    }
                }
                return false;
            }
            else
                return false;
        }

        private List<DataEntities.menu> _menuPadres;
        public List<DataEntities.menu> menuPadres
        {
            get
            {
                return _menuPadres;
            }
            set
            {
                _menuPadres = value;
            }
        }

        private List<DataEntities.menu> _menuHijos;
        public List<DataEntities.menu> menuHijos
        {
            get
            {
                return _menuHijos;
            }
            set
            {
                _menuHijos = value;
            }
        }

        private int _idMenuPadre;
        public int idMenuPadre
        {
            get
            {
                return _idMenuPadre;
            }
            set
            {
                _idMenuPadre = value;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private bool _isUserinRol;
        public bool isUserinRol
        {
            get
            {
                return _isUserinRol;
            }
            set
            {
                _isUserinRol = value;
            }
        }
    }
}
