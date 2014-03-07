namespace RunHorse
{
    partial class FormHistory
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
            this.geckoWebBrowser1 = new Skybound.Gecko.GeckoWebBrowser();
            this.SuspendLayout();
            // 
            // geckoWebBrowser1
            // 
            this.geckoWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geckoWebBrowser1.Location = new System.Drawing.Point(0, 0);
            this.geckoWebBrowser1.Name = "geckoWebBrowser1";
            this.geckoWebBrowser1.Size = new System.Drawing.Size(284, 262);
            this.geckoWebBrowser1.TabIndex = 0;
            this.geckoWebBrowser1.DocumentCompleted += new System.EventHandler(this.geckoWebBrowser1_DocumentCompleted);
            this.geckoWebBrowser1.DomMouseDown += new Skybound.Gecko.GeckoDomMouseEventHandler(this.geckoWebBrowser1_DomMouseDown);
            this.geckoWebBrowser1.DomClick += new Skybound.Gecko.GeckoDomEventHandler(this.geckoWebBrowser1_DomClick);
            // 
            // FormHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.geckoWebBrowser1);
            this.Name = "FormHistory";
            this.Text = "Full History";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Skybound.Gecko.GeckoWebBrowser geckoWebBrowser1;
    }
}