using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntities;
using BussinesLogic;
using System.Windows.Forms;
using Common;

namespace Shell
{
    public class FrmUsuariosPresenter
    {
        private IFrmUsuariosView View = null;
        private Seguridad objS = null;
        public FrmUsuariosPresenter(IFrmUsuariosView view)
        {
            View = view;
            objS = new Seguridad();
        }

        public void Guardar()
        {
            try
            {
                usuario u = null;
                perfiles perfil = null;
                switch (this.View.Operacion)
                {
                    case "Nuevo":
                        if (!objS.UsuarioExiste(this.View.User))
                        {
                            u = new usuario();
                            u.Id = Guid.NewGuid();
                            u.Nombre = this.View.Nombre;
                            u.UserName = this.View.User;
                            u.Contraseña = Utilidades.EncodePassword(this.View.User + this.View.Pwd);
                            u.CupoDiario = 0;
                            u.Email = this.View.Email;
                            u.Estado = this.View.Estado;
                            u.IdPerfil = this.View.IdPerfil;
                            perfil = objS.ObtenerPerfilporId(this.View.IdPerfil);
                            foreach (menu m in perfil.menu)
                            {
                                u.menu.Add(m);
                            }
                            objS.Guardar(u);
                        }
                        else
                            MessageBox.Show("El Usuario ya existe. Este nombre debe ser único", "Horse Racing Soft 1.0", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case "Editar":
                        u = objS.ObtenerUsuarioporId(this.View.Id);
                        u.Nombre = this.View.Nombre;
                        u.UserName = this.View.User;
                        u.Email = this.View.Email;
                        u.Estado = this.View.Estado;
                        u.IdPerfil = this.View.IdPerfil;
                        objS.EliminarMenu(u.Id);
                        perfil = objS.ObtenerPerfilporId(this.View.IdPerfil);
                        foreach (menu m in perfil.menu)
                        {
                            u.menu.Add(m);
                        }
                        objS.Actualizar(u);
                        break;
                }
                this.View.LError = false;
            }
            catch (Exception ex)
            {
                this.View.LError = true;
                MessageBox.Show("Se produjo un error al crear el usuario\r\n Contacte el área de Soporte para solucionarlo", "Horse Racing Soft 1.0", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void CargarUsuarios()
        {
            this.View.CargarUsuario = objS.ObtenerUsuarios();
        }

        public void CargarPerfiles()
        {
            this.View.CargarPerfiles = objS.ObtenerPerfiles();
        }

        public void CargarModificar()
        {
            usuario u = objS.ObtenerUsuarioporId(this.View.Id);
            this.View.Nombre = u.Nombre;
            this.View.User = u.UserName;
            this.View.Pwd = u.Contraseña;
            this.View.Email = u.Email;
            this.View.Estado = u.Estado.Value;
            this.View.IdPerfil = u.IdPerfil.Value;
        }
    }
}
