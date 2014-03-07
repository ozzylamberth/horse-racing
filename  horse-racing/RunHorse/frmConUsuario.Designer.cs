namespace RunHorse
{
    partial class frmConUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dgvTxtUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtCA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTxtTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(847, 330);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ventas";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvTxtUsuario,
            this.dgvTxtValor,
            this.Column1,
            this.dgvTxtIVA,
            this.dgvTxtCA,
            this.dgvTxtFecha,
            this.dgvTxtTicket});
            this.dataGridView1.Location = new System.Drawing.Point(9, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(826, 305);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(616, 104);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha de Consulta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Usuario";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 58);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(352, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(387, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha Desde";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(198, 19);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(163, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(9, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(148, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dgvTxtUsuario
            // 
            this.dgvTxtUsuario.DataPropertyName = "NombreUsuario";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.dgvTxtUsuario.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTxtUsuario.HeaderText = "Usuario";
            this.dgvTxtUsuario.Name = "dgvTxtUsuario";
            this.dgvTxtUsuario.ReadOnly = true;
            this.dgvTxtUsuario.Width = 160;
            // 
            // dgvTxtValor
            // 
            this.dgvTxtValor.DataPropertyName = "Valor";
            this.dgvTxtValor.HeaderText = "Valor (USD)";
            this.dgvTxtValor.Name = "dgvTxtValor";
            this.dgvTxtValor.ReadOnly = true;
            this.dgvTxtValor.Width = 120;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ValorCop";
            this.Column1.HeaderText = "Valor (COP)";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dgvTxtIVA
            // 
            this.dgvTxtIVA.DataPropertyName = "IVA";
            this.dgvTxtIVA.HeaderText = "IVA";
            this.dgvTxtIVA.Name = "dgvTxtIVA";
            this.dgvTxtIVA.ReadOnly = true;
            // 
            // dgvTxtCA
            // 
            this.dgvTxtCA.DataPropertyName = "ValorAdm";
            this.dgvTxtCA.HeaderText = "Costo Adm.";
            this.dgvTxtCA.Name = "dgvTxtCA";
            this.dgvTxtCA.ReadOnly = true;
            // 
            // dgvTxtFecha
            // 
            this.dgvTxtFecha.DataPropertyName = "Fecha";
            this.dgvTxtFecha.HeaderText = "Fecha";
            this.dgvTxtFecha.Name = "dgvTxtFecha";
            this.dgvTxtFecha.ReadOnly = true;
            // 
            // dgvTxtTicket
            // 
            this.dgvTxtTicket.DataPropertyName = "NumTicket";
            this.dgvTxtTicket.HeaderText = "Ticket";
            this.dgvTxtTicket.Name = "dgvTxtTicket";
            this.dgvTxtTicket.ReadOnly = true;
            // 
            // frmConUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 457);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConUsuario";
            this.Text = "frmConUsuario";
            this.Load += new System.EventHandler(this.frmConUsuario_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtCA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTxtTicket;
    }
}