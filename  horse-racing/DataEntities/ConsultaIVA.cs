using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntities
{
    public class ConsultaIVA
    {
        private DateTime _Fecha;
        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }
            set
            {
                _Fecha = value;
            }
        }

        private decimal _Valor;
        public decimal Valor
        {
            get
            {
                return _Valor;
            }
            set
            {
                _Valor = value;
            }
        }
    }
}
