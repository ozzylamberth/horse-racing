using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntities;

namespace Shell
{
    public interface IfrmPrincipalView
    {
        decimal valorVentasDia { get; set; }
        Guid idUsuario { get; }
        void ActualizarValorRestante();
        List<menu> menuPadres { get; set; }
        List<menu> menuHijos { get; set; }
        int idMenuPadre { get; set; }
        bool isUserinRol { get; set; }
    }
}
