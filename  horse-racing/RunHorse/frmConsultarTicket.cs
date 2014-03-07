using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLogic;
using DataEntities;
using System.Globalization;

namespace RunHorse
{
    public partial class frmConsultarTicket : Form
    {
        private BLVentas objV = null;
        private Seguridad objS = null;
        private ventas v = null;
        public frmConsultarTicket()
        {
            InitializeComponent();
            objV = new BLVentas();
            objS = new Seguridad();
        }

        private void frmConsultarTicket_Load(object sender, EventArgs e)
        {



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Debe diligenciar el número del ticket", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            v = objV.ObtenerVentaporTicket(textBox1.Text);
            if (v != null)
            {
                entidad ent = objS.ObtenerEntidad();
                string[] ventaTit = { ent.Nombre, ent.Eslogan, "NIT. " + ent.Nit, "Factura No. " + v.NroFactura };
                string[] ventaC1 = { v.Estado, v.Fecha.Value.ToString("MMM dd, yyyy", new CultureInfo("en-US")), v.Carrera, "Serial #: " + v.NumTicket, v.TipoApuesta, v.Seleccion, "", "", "____________________________________" };
                txtTitulo.Lines = ventaTit;
                txtCuerpo.Lines = ventaC1;
                txtTotalUSD.Text = "(USD)" + v.Valor.Value.ToString("C2");
                txtTRM.Text = (v.ValorCop.Value / v.Valor.Value).ToString();
                txtSubtotal.Text = v.ValorCop.Value.ToString();
                txtIVA.Text = v.IVA.Value.ToString();
                txtCostoAdm.Text = v.ValorAdm.Value.ToString();
                txtTOTAL.Text = (v.ValorCop.Value + v.IVA.Value + v.ValorAdm.Value).ToString("C2");
                txtVendedor.Text = v.NombreUsuario;
                MostrarLabel(true);
                if (v.Estado == "PAGADO")
                {
                    MessageBox.Show("El premio ya fue pagado para esta Apuesta", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.button1.Enabled = false;
                    this.numericTextBox1.Enabled = false;
                }
                else
                {
                    this.button1.Enabled = true;
                    this.numericTextBox1.Enabled = true;
                }
            }
            else
            {
                MostrarLabel(false);
                txtTitulo.Text = "";
                txtCuerpo.Text = "";
                txtTotalUSD.Text = "";
                txtTRM.Text = "";
                txtSubtotal.Text = "";
                txtIVA.Text = "";
                txtCostoAdm.Text = "";
                txtTOTAL.Text = "";
                txtVendedor.Text = "";
                MessageBox.Show("No se encontraron tickets que coincidan con el número proporcionado", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MostrarLabel(bool v)
        {
            this.label1.Visible = v;
            this.label2.Visible = v;
            this.label3.Visible = v;
            this.label4.Visible = v;
            this.label5.Visible = v;
        }

        private void txtTitulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (numericTextBox1.Text == "")
                {
                    MessageBox.Show("Debe registrar el valor del premio", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                v.ValorPagado = numericTextBox1.DecimalValue;
                v.Estado = "PAGADO";
                v.FechaPago = DateTime.Today;
                objV.Actualizar(v);
                this.button1.Enabled = false;
                this.numericTextBox1.Enabled = false;
                MessageBox.Show("Se pagó el premio con exito", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
