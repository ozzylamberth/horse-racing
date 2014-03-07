using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BussinesLogic;
using DataEntities;
using System.Windows.Forms;

namespace Shell
{
    public class FrmBrowserPresenter
    {
        private IFrmBrowserView View = null;
        private BLVentas objV = null;
        public FrmBrowserPresenter(IFrmBrowserView view)
        {
            View = view;
            objV = new BLVentas();
        }

        public void Inicializar()
        {
            this.View.urlInicio = UtilPresenter.ObtenerValorParametro("URL_SITIO_1");
        }

        public void GuardarApuesta()
        {

            try
            {
                ventas venta = new ventas();
                venta.Fecha = DateTime.Today;
                venta.Id = Guid.NewGuid();
                venta.Usuario_Id = this.View.IdUsuario;
                venta.Valor = this.View.ValorApuesta;
                venta.ValorCop = this.View.ValorApuesta * this.View.TRM;
                venta.IVA = this.View.ValorApuesta * this.View.TRM * this.View.IVA;
                venta.ValorAdm = this.View.ValoAdm * this.View.ValorApuesta;
                venta.ValorPagado = 0;
                venta.FechaPago = DateTime.Today;
                objV.Guardar(venta);
                this.View.idUltimaVenta = venta.Id;                
            }
            catch (Exception ex)
            {
               
            }
        }

        public void CancelarApuesta()
        {
            objV.Eliminar(this.View.NumTicket);
        }

        public void TicketExiste()
        {
            this.View.TicketExiste = objV.TicketImpreso(this.View.NumTicket);
        }

        public void ActualizarTicketVenta()
        {
            ventas venta = objV.ObtenerVentaporId(this.View.idUltimaVenta);
            venta.NumTicket = this.View.NumTicket;
            venta.Seleccion = this.View.Seleccion;
            venta.TipoApuesta = this.View.TipoApuesta;
            venta.Carrera = this.View.Carrera;
            venta.Estado = "IMPRESO";
            objV.Actualizar(venta);
        }
    }
}
