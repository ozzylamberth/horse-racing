using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shell;

namespace RunHorse
{
    public partial class frmLogin : Form, IFormLoginView
    {

        FormLoginPresenter Presenter { get; set; }
        public frmLogin()
        {
            InitializeComponent();
            this.Presenter = new FormLoginPresenter(this);
        }        

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            
            if (this.UserName != "" && this.Pwd != "")
            {
                this.Presenter.AutenticarUsuario();
                if (loginResult)
                {
                    this.DialogResult = DialogResult.OK;

                }
            }
            else
                MessageBox.Show("Debe proporsionar su Usuario y Contraseña para Iniciar Sesion", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public string _UserName;
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }
        bool _loginResult;
        public bool loginResult
        {
            get
            {
                return _loginResult;
            }
            set
            {
                _loginResult=value;
            }
        }

        public string User
        {
            get
            {
                return this.txtUsuario.Text;
            }
            set
            {
                this.txtUsuario.Text = value;
            }
        }

        public string Pwd
        {
            get
            {
                return this.txtContraseña.Text;
            }
            set
            {
                this.txtContraseña.Text=value;
            }
        }


        public Guid idUsuario
        {
            get
            {
                return GlobalVars.idUsuario;
            }
            set
            {
                GlobalVars.idUsuario=value;
            }
        }

        public string NombreUsuario
        {
            get
            {
                return GlobalVars.NombreUsuario;
            }
            set
            {
                GlobalVars.NombreUsuario=value;
            }
        }


        public decimal cupoDiario
        {
            get
            {
                return GlobalVars.cupoDiario;
            }
            set
            {
                GlobalVars.cupoDiario = value;
            }
        }
    }
}
