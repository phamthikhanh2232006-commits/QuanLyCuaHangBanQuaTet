namespace QuanLyCuaHangBanQuaTet
{
    partial class frmKhachHang
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
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.ComboBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblDiem = new System.Windows.Forms.Label();
            this.txtDiem = new System.Windows.Forms.TextBox();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();

            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.SuspendLayout();

            // Layout
            this.lblSDT.Location = new System.Drawing.Point(20, 20);
            this.lblSDT.Text = "SĐT (Khóa):";
            this.txtSDT.Location = new System.Drawing.Point(100, 17);
            this.txtSDT.Size = new System.Drawing.Size(150, 23);

            this.lblMatKhau.Location = new System.Drawing.Point(280, 20);
            this.lblMatKhau.Text = "Mật khẩu:";
            this.txtMatKhau.Location = new System.Drawing.Point(350, 17);

            this.lblHoTen.Location = new System.Drawing.Point(20, 60);
            this.lblHoTen.Text = "Họ Tên:";
            this.txtHoTen.Location = new System.Drawing.Point(100, 57);
            this.txtHoTen.Size = new System.Drawing.Size(150, 23);
            this.lblDiem.Location = new System.Drawing.Point(520, 20);
            this.lblDiem.Text = "Điểm Tích Lũy:";
            this.lblDiem.Size = new System.Drawing.Size(100, 20);
            this.txtDiem.Location = new System.Drawing.Point(620, 17);
            this.txtDiem.ReadOnly = true; // Điểm chỉ xem
            this.txtDiem.Size = new System.Drawing.Size(80, 23);

            // Buttons
            this.btnThem.Location = new System.Drawing.Point(20, 140);
            this.btnThem.Text = "Thêm KH";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Location = new System.Drawing.Point(120, 140);
            this.btnSua.Text = "Cập Nhật";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Location = new System.Drawing.Point(220, 140);
            this.btnXoa.Text = "Xóa KH";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.txtTimKiem.Location = new System.Drawing.Point(340, 142);
            this.txtTimKiem.Size = new System.Drawing.Size(180, 23);

            this.btnTimKiem.Location = new System.Drawing.Point(530, 140);
            this.btnTimKiem.Text = "Tìm SDT/Tên";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 30);
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            // DataGridView
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHang.Location = new System.Drawing.Point(20, 180);
            this.dgvKhachHang.Size = new System.Drawing.Size(700, 200);
            this.dgvKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellClick);

            // Form
            this.ClientSize = new System.Drawing.Size(740, 400);
            this.Controls.Add(this.dgvKhachHang);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.txtDiem);
            this.Controls.Add(this.lblDiem);
            this.Name = "frmKhachHang";
            this.Text = "Quản lý Thẻ Thành Viên (Khách Hàng)";
            this.Load += new System.EventHandler(this.frmKhachHang_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.ComboBox txtSDT;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.TextBox txtDiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvKhachHang;
    }
}