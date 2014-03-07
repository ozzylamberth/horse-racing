using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BussinesLogic;

namespace Shell
{
    public class UtilPresenter
    {
        private static BLParametros blParametros = null;
        static UtilPresenter()
        {
            blParametros = new BLParametros();
        }

        public static string ObtenerValorParametro(string nombreParametro)
        {
            return blParametros.ValorParametro(nombreParametro);
        }
    }
}
