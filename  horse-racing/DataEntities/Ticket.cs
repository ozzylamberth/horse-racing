using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntities
{
    public class Ticket
    {
        private Guid _Usuario;
        public Guid Usuario
        {
            get
            {
                return _Usuario;
            }
            set
            {
                _Usuario = value;
            }
        }

        private decimal? _Ventas;
        public decimal? Ventas
        {
            get
            {
                return _Ventas;
            }
            set
            {
                _Ventas = value == null ? 0 : value;
            }
        }

        private decimal? _VentasCOP;
        public decimal? VentasCOP
        {
            get
            {
                return _VentasCOP;
            }
            set
            {
                _VentasCOP = value == null ? 0 : value;
            }
        }

        private decimal? _ValorPagado;
        public decimal? ValorPagado
        {
            get
            {
                return _ValorPagado;
            }
            set
            {
                _ValorPagado = value == null ? 0 : value;
            }
        }

        private string _Nombre;
        public string Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                _Nombre = value;
            }
        }
    }
}
