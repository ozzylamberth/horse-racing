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
    public partial class FrmCostosAdministrativos : Form
    {
        private BLParametros objP = null;
        public FrmCostosAdministrativos()
        {
            InitializeComponent();
            objP = new BLParametros();
        }

        private void FrmCostosAdministrativos_Load(object sender, EventArgs e)
        {
            parametros_app p = objP.ObtenerParametro("VALOR_ADM");
            txtCupo.Text = p.Valor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                parametros_app p = objP.ObtenerParametro("VALOR_ADM");
                p.Valor = txtCupo.Text;
                objP.Actualizar(p);
                MessageBox.Show("Se actualizó el costo con éxito", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
