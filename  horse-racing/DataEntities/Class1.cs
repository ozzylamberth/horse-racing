using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntities
{
    public partial class ventas
    {
        string _NombreUsuario="";
        public string NombreUsuario
        {
            get
            {
                if (_NombreUsuario != "")
                    return _NombreUsuario;
                return this.usuario.Nombre;
            }
            set
            {
                _NombreUsuario = value;
            }
        }
    }
}
