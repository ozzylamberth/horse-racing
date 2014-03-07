using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataEntities;
using BussinesLogic;

namespace RunHorse
{
    public partial class frmCupoEntidad : Form
    {
        private Seguridad objS = null;
        public frmCupoEntidad()
        {
            InitializeComponent();
            objS = new Seguridad();
        }

        private void frmCupoEntidad_Load(object sender, EventArgs e)
        {
            entidad ent = objS.ObtenerEntidad();
            this.txtCupo.Text = ent.CupoDisponible.Value.ToString();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                entidad ent = objS.ObtenerEntidad();
                ent.CupoDisponible = this.txtCupo.DecimalValue;
                objS.ActualiarCupoEntidad(ent);
                MessageBox.Show("Se asignó el cúpo de forma exitosa", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}
