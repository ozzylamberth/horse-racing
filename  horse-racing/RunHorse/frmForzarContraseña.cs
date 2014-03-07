using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLogic;
using DataEntities;
using Common;

namespace RunHorse
{
    public partial class frmForzarContraseña : Form
    {
        private Seguridad objS = null;
        public frmForzarContraseña()
        {
            InitializeComponent();
            objS = new Seguridad();
        }

        private void frmForzarContraseña_Load(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = objS.ObtenerUsuarios();
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.DisplayMember = "Nombre";
            this.comboBox1.Refresh();
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (txtNewPwd.Text == "")
            {
                MessageBox.Show("La contraseña no puede estar vacia.", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            usuario u = objS.ObtenerUsuarioporId((Guid)this.comboBox1.SelectedValue);            
            if (u != null)
            {
                u.Contraseña = Utilidades.EncodePassword(u.UserName + this.txtNewPwd.Text);
                objS.Actualizar(u);
                MessageBox.Show("Se actualizó la contraseña con éxito", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
