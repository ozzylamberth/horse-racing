namespace RunHorse
{
    partial class frmTRM
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
            this.txtCupo = new RunHorse.NumericTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCupo
            // 
            this.txtCupo.AllowSpace = false;
            this.txtCupo.Location = new System.Drawing.Point(61, 23);
            this.txtCupo.Name = "txtCupo";
            this.txtCupo.Size = new System.Drawing.Size(163, 20);
            this.txtCupo.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Actualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Valor TRM";
            // 
            // frmTRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.txtCupo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Name = "frmTRM";
            this.Text = "frmTRM";
            this.Load += new System.EventHandler(this.frmTRM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericTextBox txtCupo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}