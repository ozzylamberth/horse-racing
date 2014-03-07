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

namespace RunHorse
{
    public partial class frmCupo : Form
    {
        private Seguridad objS = null;
        public frmCupo()
        {
            objS = new Seguridad();
            InitializeComponent();
        }

        private void frmCupo_Load(object sender, EventArgs e)
        {
            this.cmbUsuario.DataSource = objS.ObtenerUsuarios();
            this.cmbUsuario.ValueMember = "Id";
            this.cmbUsuario.DisplayMember = "Nombre";
            this.cmbUsuario.Refresh();
            usuario u = objS.ObtenerUsuarioporId((Guid)this.cmbUsuario.SelectedValue);
            this.txtCupo.Text = u.CupoDiario.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCupo.Text == "")
                MessageBox.Show("Debe proporcionar el cupo a asignar", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    usuario u = objS.ObtenerUsuarioporId((Guid)this.cmbUsuario.SelectedValue);
                    u.CupoDiario = decimal.Parse(this.txtCupo.Text);
                    objS.Actualizar(u);
                    MessageBox.Show("Se asignó el cupo de forma exitosa", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {

                    MessageBox.Show("ocurrio un error al asignar el cupo", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                usuario u = objS.ObtenerUsuarioporId((Guid)this.cmbUsuario.SelectedValue);
                this.txtCupo.Text = u.CupoDiario.ToString();
            }
            catch (Exception)
            {


            }
        }

        private void cmbUsuario_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
