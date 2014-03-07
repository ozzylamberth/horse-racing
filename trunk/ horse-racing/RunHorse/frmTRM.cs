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
    public partial class frmTRM : Form
    {
        private BLParametros objP = null;
        public frmTRM()
        {
            InitializeComponent();
            objP = new BLParametros();
        }

        private void frmTRM_Load(object sender, EventArgs e)
        {
            parametros_app p = objP.ObtenerParametro("VALOR_TRM");
            txtCupo.Text = p.Valor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                parametros_app p = objP.ObtenerParametro("VALOR_TRM");
                p.Valor = txtCupo.Text;
                objP.Actualizar(p);
                MessageBox.Show("Se actualizó la TRM con éxito", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}
