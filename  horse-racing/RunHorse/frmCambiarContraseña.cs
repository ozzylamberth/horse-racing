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
    public partial class frmCambiarContraseña : Form
    {
        private Seguridad objS = null;
        public frmCambiarContraseña()
        {
            InitializeComponent();
            objS = new Seguridad();
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (txtNewPwd.Text == "" || txtPwdActual.Text == "")
            {
                MessageBox.Show("La contraseña no puede estar vacia.", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            usuario u = objS.ObtenerUsuarioporId(GlobalVars.idUsuario);
            usuario ua = objS.Autenticacion(u.UserName, this.txtPwdActual.Text);
            if (ua != null)
            {
                u.Contraseña = Utilidades.EncodePassword(u.UserName + this.txtNewPwd.Text);
                objS.Actualizar(u);
                MessageBox.Show("Se actualizó la contraseña con éxito", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("La contraseña no corresponde con su contraseña actual.", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}