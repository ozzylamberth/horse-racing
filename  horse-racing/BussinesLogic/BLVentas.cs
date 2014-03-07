using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using DataEntities;

namespace BussinesLogic
{
    public class BLVentas
    {
        private apuestasEntities context = null;
        private Seguridad objS = null;
        public BLVentas()
        {
            context = BLAbstract.Instance.Context;
            objS = new Seguridad();
        }

        public decimal ventaTotalDia(Guid idUsuario)
        {
            DateTime hoy = DateTime.Today;
            decimal? Valor = context.ventas.Where(v => v.Usuario_Id == idUsuario && v.Fecha == hoy).ToList().Sum(v => v.Valor.Value);
            return Valor.Value;
        }

        public void Guardar(ventas venta)
        {
            venta.NroFactura = context.numerosfacturas.FirstOrDefault(nf => nf.Estado == "A").NumActual + 1;
            context.ventas.AddObject(venta);
            usuario u = objS.ObtenerUsuarioporId(venta.Usuario_Id);
            entidad e = context.entidad.FirstOrDefault();
            numerosfacturas n = context.numerosfacturas.FirstOrDefault(nf => nf.Estado == "A");
            e.CupoDisponible = e.CupoDisponible - venta.Valor;
            u.CupoDiario = u.CupoDiario - venta.Valor;
            n.NumActual += 1;
            context.entidad.ApplyChanges(e);
            context.numerosfacturas.ApplyChanges(n);
            context.usuario.ApplyChanges(u);
            //objS.Actualizar(u);
            context.SaveChanges();
        }

        public ventas ObtenerVentaporId(Guid idVenta)
        {
            return context.ventas.FirstOrDefault(v => v.Id == idVenta);
        }

        public ventas ObtenerVentaporTicket(string numTicket)
        {
            return context.ventas.FirstOrDefault(v => v.NumTicket == numTicket);
        }

        public void Eliminar(string numTicket)
        {
            ventas venta = ObtenerVentaporTicket(numTicket);
            usuario u = objS.ObtenerUsuarioporId(venta.Usuario_Id);
            entidad e = context.entidad.FirstOrDefault();
            u.CupoDiario = u.CupoDiario + venta.Valor;
            e.CupoDisponible += venta.Valor;
            context.ventas.DeleteObject(venta);
            context.entidad.ApplyChanges(e);
            context.usuario.ApplyChanges(u);
            //objS.Actualizar(u);
            context.SaveChanges();
        }

        public void EliminarPorId(Guid Id)
        {
            ventas venta = ObtenerVentaporId(Id);
            if (venta != null)
            {
                context.ventas.DeleteObject(venta);
                usuario u = objS.ObtenerUsuarioporId(venta.Usuario_Id);
                u.CupoDiario = u.CupoDiario + venta.Valor;
                objS.Actualizar(u);
                context.SaveChanges();
            }
        }

        public bool TicketImpreso(string Ticket)
        {
            return context.ventas.FirstOrDefault(v => v.NumTicket == Ticket && v.Estado != null) != null;
        }

        public bool EsVentaPropia(string Ticket, Guid idUsuario)
        {
            return context.ventas.FirstOrDefault(v => v.NumTicket == Ticket && v.Usuario_Id == idUsuario) != null;
        }

        public void Actualizar(ventas venta)
        {
            context.ventas.ApplyChanges(venta);
            context.SaveChanges();
        }

        public string NombreUsuario(Guid idUsuario)
        {
            return context.usuario.FirstOrDefault(u => u.Id == idUsuario).Nombre;
        }

        public List<Ticket> VentasporUsuario(DateTime FI, DateTime FF)
        {
            FF = FF.AddDays(1);
            var vn = from v in context.ventas
                     where ((DateTime)v.Fecha.Value >= FI && v.Fecha <= FF && v.NumTicket != null && v.NumTicket != "")
                     group v by new
                     {
                         v.Usuario_Id
                     } into venta
                     select new Ticket { Usuario = venta.Key.Usuario_Id, Ventas = venta.Sum(p => p.Valor.Value), VentasCOP = venta.Sum(p => p.ValorCop.Value + p.IVA.Value + p.ValorAdm.Value) };

            List<Ticket> Lista = vn.ToList();
            foreach (Ticket t in Lista)
            {
                t.Nombre = NombreUsuario(t.Usuario);
                decimal? vp = ((decimal?)context.ventas.Where(v => v.FechaPago.Value >= FI && v.FechaPago <= FF && v.Usuario_Id == t.Usuario && v.NumTicket != null && v.NumTicket != "").Sum(v => v.ValorPagado.Value)).Value;
                t.ValorPagado = vp == null ? 0 : vp;
            }
            Ticket ti = new Ticket();
            ti.ValorPagado = Lista.Sum(tc => tc.ValorPagado);
            ti.Ventas = Lista.Sum(tc => tc.Ventas);
            ti.VentasCOP = Lista.Sum(tc => tc.VentasCOP);
            ti.Nombre = "TOTAL";
            Lista.Add(ti);
            return Lista;
        }

        public List<ConsultaIVA> VentasIVA(DateTime FI, DateTime FF)
        {
            var vn = from v in context.ventas
                     where ((DateTime)v.Fecha.Value >= FI && v.Fecha <= FF && v.NumTicket != null && v.NumTicket != "")
                     group v by new
                     {
                         v.Fecha
                     } into venta
                     select new ConsultaIVA { Fecha = venta.Key.Fecha.Value, Valor = venta.Sum(p => p.IVA.Value) };

            List<ConsultaIVA> Lista = vn.ToList();
            return Lista;
        }

        public List<ventas> ObtenerVentasGeneral(DateTime FI, DateTime FF)
        {
            List<ventas> Lista = context.ventas.Include("usuario").Where(v => v.Fecha >= FI && v.Fecha <= FF && v.NumTicket != null && v.NumTicket != "").ToList();
            ventas ve = new ventas();
            ve.NombreUsuario = "TOTAL";
            ve.Valor = Lista.Sum(v => v.Valor);
            ve.ValorCop = Lista.Sum(v => v.ValorCop);
            ve.IVA = Lista.Sum(v => v.IVA);
            ve.ValorAdm = Lista.Sum(v => v.ValorAdm);
            Lista.Add(ve);
            return Lista;
        }

        public List<ventas> ObtenerVentasUsuario(DateTime FI, DateTime FF, Guid idUsuario)
        {
            List<ventas> Lista = context.ventas.Where(v => v.Fecha >= FI && v.Fecha <= FF && v.Usuario_Id == idUsuario && v.NumTicket != null && v.NumTicket != "").ToList();
            ventas ve = new ventas();
            ve.NombreUsuario = "TOTAL";
            ve.Valor = Lista.Sum(v => v.Valor);
            ve.ValorCop = Lista.Sum(v => v.ValorCop);
            ve.IVA = Lista.Sum(v => v.IVA);
            ve.ValorAdm = Lista.Sum(v => v.ValorAdm);
            Lista.Add(ve);
            return Lista;
        }

    }
}
