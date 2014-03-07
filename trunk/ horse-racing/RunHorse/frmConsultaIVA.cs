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
    public partial class frmConsultaIVA : Form
    {
        private BLVentas objV = null;
        public frmConsultaIVA()
        {
            InitializeComponent();
            objV = new BLVentas();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dateTimePicker1.Value.Date > this.dateTimePicker2.Value.Date)
                MessageBox.Show("La fecha de Inicio debe ser anterio o igual a la fecha final", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                this.dataGridView1.DataSource = objV.VentasIVA(this.dateTimePicker1.Value.Date, this.dateTimePicker2.Value.Date);
        }
    }
}
