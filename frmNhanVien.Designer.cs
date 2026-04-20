namespace QuanLyCuaHangBanQuaTet
{
    partial class frmNhanVien
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
            this.lblMa = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.cboChucVu = new System.Windows.Forms.ComboBox();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();

            // Layout Setup
            this.lblMa.Location = new System.Drawing.Point(20, 20);
            this.lblMa.Text = "Mã NV:";
            this.txtMa.Location = new System.Drawing.Point(80, 17);

            this.lblTen.Location = new System.Drawing.Point(250, 20);
            this.lblTen.Text = "Họ Tên:";
            this.txtTen.Location = new System.Drawing.Point(320, 17);
            this.txtTen.Size = new System.Drawing.Size(200, 23);

            this.lblGioiTinh.Location = new System.Drawing.Point(550, 20);
            this.lblGioiTinh.Text = "Giới Tính:";
            this.cboGioiTinh.Location = new System.Drawing.Point(620, 17);
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            this.lblDiaChi.Location = new System.Drawing.Point(20, 60);
            this.lblDiaChi.Text = "Địa chỉ:";
            this.txtDiaChi.Location = new System.Drawing.Point(80, 57);
            this.txtDiaChi.Size = new System.Drawing.Size(440, 23);
            this.lblSDT.Location = new System.Drawing.Point(550, 60);
            this.lblSDT.Text = "Điện thoại:";
            this.txtSDT.Location = new System.Drawing.Point(620, 57);
            this.lblChucVu.Location = new System.Drawing.Point(20, 100);
            this.lblChucVu.Text = "Chức vụ:";
            this.cboChucVu.Location = new System.Drawing.Point(80, 97);
            this.cboChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // Buttons
            this.btnThem.Location = new System.Drawing.Point(80, 140);
            this.btnThem.Size = new System.Drawing.Size(80, 30);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Location = new System.Drawing.Point(170, 140);
            this.btnSua.Size = new System.Drawing.Size(80, 30);
            this.btnSua.Text = "Cập nhật";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Location = new System.Drawing.Point(260, 140);
            this.btnXoa.Size = new System.Drawing.Size(80, 30);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.txtTimKiem.Location = new System.Drawing.Point(380, 145);
            this.txtTimKiem.Size = new System.Drawing.Size(200, 23);
            this.btnTimKiem.Location = new System.Drawing.Point(590, 140);
            this.btnTimKiem.Size = new System.Drawing.Size(80, 30);
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // Grid
            this.dgvNhanVien.Location = new System.Drawing.Point(20, 190);
            this.dgvNhanVien.Size = new System.Drawing.Size(750, 250);
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);

            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cboChucVu);
            this.Controls.Add(this.lblChucVu);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.cboGioiTinh);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.lblMa);
            this.Name = "frmNhanVien";
            this.Text = "Quản lý Nhân Viên";
            this.Load += new System.EventHandler(this.frmNhanVien_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvNhanVien;
    }
}
