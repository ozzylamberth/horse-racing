using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntities;
using BussinesLogic;

namespace Shell
{
    public class frmPrincipalPresenter
    {
        private IfrmPrincipalView View = null;
        private BLVentas objV = null;
        private BLMenu objM = null;
        private Seguridad objS = null;
        public frmPrincipalPresenter(IfrmPrincipalView view)
        {
            View = view;
            objV = new BLVentas();
            objM = new BLMenu();
            objS = new Seguridad();
        }

        public void ValorVentas()
        {
            this.View.valorVentasDia = objS.CupoDisponible(this.View.idUsuario);
        }

        public void ListarPadres()
        {
            this.View.menuPadres = objM.ListarMenuPadre();
        }

        public void ListarHijos()
        {
            this.View.menuHijos = objM.ListarMenusHijos(this.View.idMenuPadre);
        }

        public void UsuarioenRol(int idMenu)
        {
            this.View.isUserinRol = objM.IsUserInRol(this.View.idUsuario, idMenu);
        }
    }
}
