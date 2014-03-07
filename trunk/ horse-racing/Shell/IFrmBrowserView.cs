using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shell
{
    public interface IFrmBrowserView
    {
        string urlInicio { get; set; }
        decimal ValorApuesta { get; set; }
        Guid IdUsuario { get; }
        Guid idUltimaVenta { get; set; }
        string NumTicket { get; set; }
        bool TicketExiste { get; set; }
        decimal IVA { get; }
        decimal TRM { get; }
        decimal ValorCOP { get; set; }
        decimal ValoAdm { get; }
        string Seleccion { get; set; }
        string TipoApuesta { get; set; }
        string Carrera { get; set; }
    }
}
