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
    public partial class frmContraseñaSitio : Form
    {
        private BLParametros objP = null;
        public frmContraseñaSitio()
        {
            InitializeComponent();
            objP = new BLParametros();
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (txtNewPwd.Text == "" || txtPwdActual.Text == "")
            {
                MessageBox.Show("La contraseña no puede estar vacia.", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            parametros_app p = objP.ObtenerParametro("PWD_SITIO_1");
            if (Utilidades.DecryptKey(p.Valor)== this.txtPwdActual.Text)
            {
                p.Valor = Utilidades.EncryptKey(this.txtNewPwd.Text);
                objP.Actualizar(p);
                MessageBox.Show("Se actualizó la contraseña con éxito", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("La contraseña no corresponde con su contraseña actual.", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
