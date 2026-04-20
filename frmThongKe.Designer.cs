namespace QuanLyCuaHangBanQuaTet
{
    partial class frmThongKe
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSanPham = new System.Windows.Forms.TabPage();
            this.dgvThongKeSP = new System.Windows.Forms.DataGridView();
            this.tabHoaDon = new System.Windows.Forms.TabPage();
            this.btnInDoanhThu = new System.Windows.Forms.Button();
            this.dgvLichSuHoaDon = new System.Windows.Forms.DataGridView();
            this.btnInTonKho = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeSP)).BeginInit();
            this.tabHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSanPham);
            this.tabControl1.Controls.Add(this.tabHoaDon);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(900, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSanPham
            // 
            this.tabSanPham.Controls.Add(this.btnInTonKho);
            this.tabSanPham.Controls.Add(this.dgvThongKeSP);
            this.tabSanPham.Location = new System.Drawing.Point(4, 25);
            this.tabSanPham.Name = "tabSanPham";
            this.tabSanPham.Padding = new System.Windows.Forms.Padding(3);
            this.tabSanPham.Size = new System.Drawing.Size(892, 471);
            this.tabSanPham.TabIndex = 0;
            this.tabSanPham.Text = "Thống Kê Sản Phẩm Tồn / Bán Ra";
            this.tabSanPham.UseVisualStyleBackColor = true;
            // 
            // dgvThongKeSP
            // 
            this.dgvThongKeSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKeSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongKeSP.Location = new System.Drawing.Point(3, 3);
            this.dgvThongKeSP.Name = "dgvThongKeSP";
            this.dgvThongKeSP.RowHeadersWidth = 51;
            this.dgvThongKeSP.Size = new System.Drawing.Size(886, 465);
            this.dgvThongKeSP.TabIndex = 0;
            // 
            // tabHoaDon
            // 
            this.tabHoaDon.Controls.Add(this.btnInDoanhThu);
            this.tabHoaDon.Controls.Add(this.dgvLichSuHoaDon);
            this.tabHoaDon.Location = new System.Drawing.Point(4, 25);
            this.tabHoaDon.Name = "tabHoaDon";
            this.tabHoaDon.Padding = new System.Windows.Forms.Padding(3);
            this.tabHoaDon.Size = new System.Drawing.Size(892, 471);
            this.tabHoaDon.TabIndex = 1;
            this.tabHoaDon.Text = "Lịch Sử Toàn Bộ Hóa Đơn";
            this.tabHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnInDoanhThu
            // 
            this.btnInDoanhThu.Location = new System.Drawing.Point(759, 440);
            this.btnInDoanhThu.Name = "btnInDoanhThu";
            this.btnInDoanhThu.Size = new System.Drawing.Size(125, 23);
            this.btnInDoanhThu.TabIndex = 1;
            this.btnInDoanhThu.Text = "In Doanh Thu  ";
            this.btnInDoanhThu.UseVisualStyleBackColor = true;
            this.btnInDoanhThu.Click += new System.EventHandler(this.btnInDoanhThu_Click);
            // 
            // dgvLichSuHoaDon
            // 
            this.dgvLichSuHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSuHoaDon.Location = new System.Drawing.Point(3, 3);
            this.dgvLichSuHoaDon.Name = "dgvLichSuHoaDon";
            this.dgvLichSuHoaDon.RowHeadersWidth = 51;
            this.dgvLichSuHoaDon.Size = new System.Drawing.Size(886, 465);
            this.dgvLichSuHoaDon.TabIndex = 0;
            this.dgvLichSuHoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLichSuHoaDon_CellContentClick);
            // 
            // btnInTonKho
            // 
            this.btnInTonKho.Location = new System.Drawing.Point(756, 410);
            this.btnInTonKho.Name = "btnInTonKho";
            this.btnInTonKho.Size = new System.Drawing.Size(108, 23);
            this.btnInTonKho.TabIndex = 1;
            this.btnInTonKho.Text = "In Tồn Kho";
            this.btnInTonKho.UseVisualStyleBackColor = true;
            this.btnInTonKho.Click += new System.EventHandler(this.btnInTonKho_Click_1);
            // 
            // frmThongKe
            // 
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmThongKe";
            this.Text = "Báo Cáo Thống Kê Máy POS";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSanPham.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeSP)).EndInit();
            this.tabHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuHoaDon)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSanPham;
        private System.Windows.Forms.DataGridView dgvThongKeSP;
        private System.Windows.Forms.TabPage tabHoaDon;
        private System.Windows.Forms.DataGridView dgvLichSuHoaDon;
        private System.Windows.Forms.Button btnInDoanhThu;
        private System.Windows.Forms.Button btnInTonKho;
    }
}