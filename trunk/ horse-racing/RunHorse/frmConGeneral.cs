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
    public partial class frmConGeneral : Form
    {
        private BLVentas objV = null;
        public frmConGeneral()
        {
            InitializeComponent();
            objV = new BLVentas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dateTimePicker1.Value.Date > this.dateTimePicker2.Value.Date)
                MessageBox.Show("La fecha de Inicio debe ser anterio o igual a la fecha final", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                this.dataGridView1.DataSource = objV.ObtenerVentasGeneral(this.dateTimePicker1.Value.Date, this.dateTimePicker2.Value.Date);
                this.dataGridView1.Refresh();
                dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            }
        }

        private void frmConGeneral_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.Columns[1].DefaultCellStyle.Format = "c2";
            this.dataGridView1.Columns[2].DefaultCellStyle.Format = "c2";
            this.dataGridView1.Columns[3].DefaultCellStyle.Format = "c2";
            this.dataGridView1.Columns[4].DefaultCellStyle.Format = "c2";
        }
    }
}
