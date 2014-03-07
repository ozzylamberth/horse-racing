using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntities;
using DataAccess;

namespace BussinesLogic
{
    public class BLMenu
    {
        private apuestasEntities context = null;
        public BLMenu()
        {
            context = BLAbstract.Instance.Context;
        }
        public List<menu> ListarMenuPadre()
        {
            return context.menu.Where(m => m.Id == m.PadreId).ToList();
        }

        public List<menu> ListarMenusHijos(int idPadre)
        {
            return context.menu.Where(m => m.PadreId == idPadre && m.Id != m.PadreId).ToList();
        }

        public bool IsUserInRol(Guid idUsuario, int idMenu)
        {
            return context.menu.Include("usuario").FirstOrDefault(m => m.Id == idMenu).usuario.FirstOrDefault(u => u.Id == idUsuario) != null;
        }
    }
}
