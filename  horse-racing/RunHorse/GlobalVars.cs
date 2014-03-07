using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RunHorse
{
    public static class GlobalVars
    {
        private static Guid _idUltimaVenta;
        public static Guid idUltimaVenta
        {
            get
            {
                return _idUltimaVenta;
            }
            set
            {
                _idUltimaVenta = value;
            }
        }

        private static Guid _idUsuario;
        public static Guid idUsuario
        {
            get
            {
                return _idUsuario;
            }
            set
            {
                _idUsuario = value;
            }
        }

        private static decimal _cupoDiario;
        public static decimal cupoDiario
        {
            get
            {
                return _cupoDiario;
            }
            set
            {
                _cupoDiario = value;
            }
        }

        private static string _nombreUsuario;
        public static string NombreUsuario
        {
            get
            {
                return _nombreUsuario;
            }
            set
            {
                _nombreUsuario = value;
            }
        }
    }
}
