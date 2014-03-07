using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using DataEntities;

namespace BussinesLogic
{
    public class BLParametros
    {
        private apuestasEntities context = null;
        public BLParametros()
        {
            context = BLAbstract.Instance.Context;
        }
        public string ValorParametro(string nombre)
        {
            return context.parametros_app.FirstOrDefault(p => p.Nombre == nombre).Valor;
        }

        public parametros_app ObtenerParametro(string nombre)
        {
            return context.parametros_app.FirstOrDefault(p => p.Nombre == nombre);
        }

        public void Actualizar(parametros_app p)
        {
            context.parametros_app.ApplyChanges(p);
            context.SaveChanges();
        }
    }
}
