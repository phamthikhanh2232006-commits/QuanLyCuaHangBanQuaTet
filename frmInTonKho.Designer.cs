namespace QuanLyCuaHangBanQuaTet
{
    partial class frmInTonKho
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
            this.crystalReportViewer4 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer4
            // 
            this.crystalReportViewer4.ActiveViewIndex = -1;
            this.crystalReportViewer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer4.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer4.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer4.Name = "crystalReportViewer4";
            this.crystalReportViewer4.Size = new System.Drawing.Size(800, 450);
            this.crystalReportViewer4.TabIndex = 0;
            this.crystalReportViewer4.Load += new System.EventHandler(this.crystalReportViewer4_Load);
            // 
            // frmInTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crystalReportViewer4);
            this.Name = "frmInTonKho";
            this.Text = "frmInTonKho";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer4;
    }
}