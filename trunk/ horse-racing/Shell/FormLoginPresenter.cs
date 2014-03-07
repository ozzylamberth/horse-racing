using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BussinesLogic;
using DataEntities;
using System.Windows.Forms;

namespace Shell
{
    public class FormLoginPresenter
    {
        private IFormLoginView View = null;
        private Seguridad objS = null;
        public FormLoginPresenter(IFormLoginView view)
        {
            View = view;
            objS = new Seguridad();
        }

        public void AutenticarUsuario()
        {
            usuario User = objS.Autenticacion(this.View.User, this.View.Pwd);
            if (User != null)
            {
                this.View.loginResult = User != null;
                this.View.idUsuario = User.Id;
                this.View.NombreUsuario = User.Nombre;
                this.View.cupoDiario = User.CupoDiario.Value;
            }
            else
                MessageBox.Show("Usuario o Contraseña incorrectos", "Horse Racing Soft 1.0", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
