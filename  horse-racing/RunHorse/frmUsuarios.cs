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
    public partial class frmUsuarios : Form, IFrmUsuariosView
    {
        private FrmUsuariosPresenter Presenter { get; set; }
        public frmUsuarios()
        {
            InitializeComponent();
            Presenter = new FrmUsuariosPresenter(this);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            this.Presenter.CargarUsuarios();
            this.Presenter.CargarPerfiles();
            Limpiar(this.groupBox2);
            Habilitar(this.groupBox2, false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar(this.groupBox2);
            Habilitar(this.groupBox2, true);
            this.Operacion = "Nuevo";
        }

        public void Limpiar(GroupBox gr)
        {
            foreach (Control c in gr.Controls)
            {
                if (c is TextBox)
                    c.Text = "";
                if (c is ComboBox)
                    ((ComboBox)c).SelectedIndex = 0;
            }
        }

        public void Habilitar(GroupBox gr, bool valor)
        {
            foreach (Control c in gr.Controls)
            {
                c.Enabled = valor;
                if (c.Name == "btnNuevo")
                    c.Enabled = !valor;
                if (c.Name == "btnGuardar")
                    c.Enabled = valor;
            }
        }

        private Guid _Id;
        public Guid Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.txtNombre.Text;
            }
            set
            {
                this.txtNombre.Text = value;
            }
        }

        public string User
        {
            get
            {
                return this.txtUser.Text;
            }
            set
            {
                this.txtUser.Text = value;
            }
        }

        public string Pwd
        {
            get
            {
                return this.txtPwd.Text;
            }
            set
            {
                this.txtPwd.Text = value;
            }
        }

        public string Email
        {
            get
            {
                return this.txtEmail.Text;
            }
            set
            {
                this.txtEmail.Text = value;
            }
        }

        public bool Estado
        {
            get
            {
                return this.cmbEstado.SelectedIndex == 0;
            }
            set
            {
                this.cmbEstado.SelectedIndex = value == true ? 0 : 1;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.txtNombre.Text == "" || this.txtUser.Text == "" || this.txtPwd.Text == "")
            {
                MessageBox.Show("Los campos marcados con (*) son obligatorios", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Presenter.Guardar();
            if (!this.LError)
            {
                MessageBox.Show("Se realizó la operación exitosamente", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Presenter.CargarUsuarios();
                this.Habilitar(this.groupBox2, false);
                this.Limpiar(this.groupBox2);
            }
        }

        private string _Operacion;
        public string Operacion
        {
            get
            {
                return _Operacion;
            }
            set
            {
                _Operacion = value;
            }
        }


        public object CargarUsuario
        {
            set
            {
                this.dgvUsuarios.AutoGenerateColumns = false;
                this.dgvUsuarios.DataSource = value;
                this.dgvUsuarios.Refresh();
            }
        }

        private bool _LError;
        public bool LError
        {
            get
            {
                return _LError;
            }
            set
            {
                _LError = value;
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 5:
                    this.Id = Guid.Parse(dgvUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.Operacion = "Editar";
                    this.Presenter.CargarModificar();
                    this.Habilitar(groupBox2, true);
                    this.txtUser.Enabled = false;
                    this.txtPwd.Enabled = false;
                    break;
            }
        }


        public object CargarPerfiles
        {
            set
            {
                this.cmbPerfiles.DataSource = value;
                this.cmbPerfiles.ValueMember = "Id";
                this.cmbPerfiles.DisplayMember = "Nombre";
                this.cmbPerfiles.Refresh();
            }
        }

        
        public Guid IdPerfil
        {
            get
            {
                return Guid.Parse(this.cmbPerfiles.SelectedValue.ToString());
            }
            set
            {
                this.cmbPerfiles.SelectedValue = value;
            }
        }
    }
}