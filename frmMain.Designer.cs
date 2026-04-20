namespace QuanLyCuaHangBanQuaTet
{
    partial class frmMain
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnNhapHang = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(50, 40);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(446, 41);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "HỆ THỐNG QUẢN LÝ QUÀ TẾT";
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Location = new System.Drawing.Point(50, 100);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(180, 50);
            this.btnKhachHang.TabIndex = 6;
            this.btnKhachHang.Text = "Quản lý Thẻ Thành Viên";
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.Location = new System.Drawing.Point(250, 100);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(180, 50);
            this.btnSanPham.TabIndex = 5;
            this.btnSanPham.Text = "Quản lý Sản Phẩm";
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.Location = new System.Drawing.Point(50, 170);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(180, 50);
            this.btnHoaDon.TabIndex = 4;
            this.btnHoaDon.Text = "Máy POS Bán Hàng";
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.Location = new System.Drawing.Point(250, 170);
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(180, 50);
            this.btnNhapHang.TabIndex = 3;
            this.btnNhapHang.Text = "Quản lý Nhập Kho";
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Location = new System.Drawing.Point(50, 240);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(180, 50);
            this.btnNhanVien.TabIndex = 2;
            this.btnNhanVien.Text = "Quản lý Nhân Viên";
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(250, 240);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(180, 50);
            this.btnThongKe.TabIndex = 1;
            this.btnThongKe.Text = "Báo Cáo Thống Kê";
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(150, 310);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(180, 50);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Đăng xuất / Thoát";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(575, 400);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnNhanVien);
            this.Controls.Add(this.btnNhapHang);
            this.Controls.Add(this.btnHoaDon);
            this.Controls.Add(this.btnSanPham);
            this.Controls.Add(this.btnKhachHang);
            this.Controls.Add(this.lblWelcome);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng Điều Khiển Cửa Hàng (Dashboard)";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnNhapHang;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnLogout;
    }
}
