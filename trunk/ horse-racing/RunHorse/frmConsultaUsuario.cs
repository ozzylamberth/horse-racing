using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLogic;

namespace RunHorse
{
    public partial class frmConsultaUsuario : Form
    {
        private BLVentas objV = null;
        public frmConsultaUsuario()
        {
            InitializeComponent();
            objV = new BLVentas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
                MessageBox.Show("La fecha de Inicio debe ser anterio o igual a la fecha final", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                this.dataGridView1.DataSource = objV.VentasporUsuario(this.dateTimePicker1.Value.Date, this.dateTimePicker2.Value.Date);
                this.dataGridView1.Refresh();
                dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            }
        }

        private void frmConsultaUsuario_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.Columns["dgvTxtVentas"].DefaultCellStyle.Format = "c2";
            this.dataGridView1.Columns["dgvTxtVentasCOP"].DefaultCellStyle.Format = "c2";
            this.dataGridView1.Columns["txtGvPagos"].DefaultCellStyle.Format = "c2";
        }
    }
}
