using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shell
{
    public interface IFrmUsuariosView
    {
        Guid Id { get; set; }
        string Nombre { get; set; }
        string User { get; set; }
        string Pwd { get; set; }
        string Email { get; set; }
        bool Estado { get; set; }
        string Operacion { get; set; }
        object CargarUsuario { set; }
        bool LError { get; set; }
        object CargarPerfiles { set; }
        Guid IdPerfil { get; set; }
    }
}
