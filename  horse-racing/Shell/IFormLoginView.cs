using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shell
{
    public interface IFormLoginView
    {
        bool loginResult { get; set; }
        string User { get; set; }
        string Pwd { get; set; }
        string UserName { get; set; }
        Guid idUsuario { get; set; }
        string NombreUsuario { get; set; }
        decimal cupoDiario { get; set; }
    }
}
