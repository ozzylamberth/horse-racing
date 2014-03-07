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
    public partial class frmConUsuario : Form
    {
        private BLVentas objV = null;
        private Seguridad objS = null;
        public frmConUsuario()
        {
            InitializeComponent();
            objV = new BLVentas();
            objS = new Seguridad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dateTimePicker1.Value.Date > this.dateTimePicker2.Value.Date)
                MessageBox.Show("La fecha de Inicio debe ser anterio o igual a la fecha final", "Horse Racing Soft 2.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                this.dataGridView1.DataSource = objV.ObtenerVentasUsuario(this.dateTimePicker1.Value.Date, this.dateTimePicker2.Value.Date, (Guid)comboBox1.SelectedValue);
                this.dataGridView1.Refresh();
                dataGridView1.Rows[dataGridView1.RowCount - 1].DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            }
        }

        private void frmConUsuario_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.comboBox1.DataSource = objS.ObtenerUsuarios();
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.DisplayMember = "Nombre";
            this.comboBox1.Refresh();
            this.dataGridView1.Columns[1].DefaultCellStyle.Format = "c2";
            this.dataGridView1.Columns[2].DefaultCellStyle.Format = "c2";
            this.dataGridView1.Columns[3].DefaultCellStyle.Format = "c2";
            this.dataGridView1.Columns[4].DefaultCellStyle.Format = "c2";
        }
    }
}
