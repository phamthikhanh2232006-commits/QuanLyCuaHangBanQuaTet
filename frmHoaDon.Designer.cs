namespace QuanLyCuaHangBanQuaTet
{
    partial class frmHoaDon
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
            this.lblMaHD = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblNgayBan = new System.Windows.Forms.Label();
            this.dtpNgayBan = new System.Windows.Forms.DateTimePicker();
            this.lblSanPham = new System.Windows.Forms.Label();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.btnTaoTheKhach = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaHD
            // 
            this.lblMaHD.Location = new System.Drawing.Point(20, 20);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(100, 23);
            this.lblMaHD.TabIndex = 22;
            this.lblMaHD.Text = "Mã HĐ:";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(90, 17);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(100, 22);
            this.txtMaHD.TabIndex = 21;
            // 
            // lblSDT
            // 
            this.lblSDT.Location = new System.Drawing.Point(220, 20);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(100, 23);
            this.lblSDT.TabIndex = 20;
            this.lblSDT.Text = "SĐT:";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(290, 17);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(100, 22);
            this.txtSDT.TabIndex = 19;
            // 
            // lblNgayBan
            // 
            this.lblNgayBan.Location = new System.Drawing.Point(20, 57);
            this.lblNgayBan.Name = "lblNgayBan";
            this.lblNgayBan.Size = new System.Drawing.Size(100, 23);
            this.lblNgayBan.TabIndex = 18;
            this.lblNgayBan.Text = "Ngày Bán:";
            // 
            // dtpNgayBan
            // 
            this.dtpNgayBan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBan.Location = new System.Drawing.Point(126, 57);
            this.dtpNgayBan.Name = "dtpNgayBan";
            this.dtpNgayBan.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayBan.TabIndex = 17;
            // 
            // lblSanPham
            // 
            this.lblSanPham.Location = new System.Drawing.Point(20, 100);
            this.lblSanPham.Name = "lblSanPham";
            this.lblSanPham.Size = new System.Drawing.Size(100, 23);
            this.lblSanPham.TabIndex = 16;
            this.lblSanPham.Text = "Sản Phẩm:";
            // 
            // cboSanPham
            // 
            this.cboSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSanPham.Location = new System.Drawing.Point(90, 97);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(121, 24);
            this.cboSanPham.TabIndex = 15;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Location = new System.Drawing.Point(20, 140);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(100, 23);
            this.lblSoLuong.TabIndex = 12;
            this.lblSoLuong.Text = "Số Lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(90, 137);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(100, 22);
            this.txtSoLuong.TabIndex = 11;
            // 
            // lblDonGia
            // 
            this.lblDonGia.Location = new System.Drawing.Point(220, 140);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(100, 23);
            this.lblDonGia.TabIndex = 10;
            this.lblDonGia.Text = "Đơn Giá:";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(290, 137);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(100, 22);
            this.txtDonGia.TabIndex = 9;
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.Location = new System.Drawing.Point(420, 140);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(100, 23);
            this.lblGiamGia.TabIndex = 8;
            this.lblGiamGia.Text = "Giảm giá:";
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Location = new System.Drawing.Point(490, 137);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(100, 22);
            this.txtGiamGia.TabIndex = 7;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.Location = new System.Drawing.Point(220, 100);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(100, 23);
            this.lblNhanVien.TabIndex = 14;
            this.lblNhanVien.Text = "Nhân viên:";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.Location = new System.Drawing.Point(290, 97);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(121, 24);
            this.cboNhanVien.TabIndex = 13;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(90, 180);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(200, 30);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm đơn hàng / Thêm món";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(300, 180);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 30);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "In Hóa Đơn";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(440, 180);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 30);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa PB/ĐC";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(550, 180);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 30);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa Hóa Đơn";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.ColumnHeadersHeight = 29;
            this.dgvHoaDon.Location = new System.Drawing.Point(20, 230);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(750, 230);
            this.dgvHoaDon.TabIndex = 2;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Location = new System.Drawing.Point(520, 470);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(188, 24);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "TỔNG TIỀN (VNĐ):";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtTongTien.ForeColor = System.Drawing.Color.Red;
            this.txtTongTien.Location = new System.Drawing.Point(670, 467);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(100, 30);
            this.txtTongTien.TabIndex = 1;
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnTaoTheKhach
            // 
            this.btnTaoTheKhach.Location = new System.Drawing.Point(440, 20);
            this.btnTaoTheKhach.Name = "btnTaoTheKhach";
            this.btnTaoTheKhach.Size = new System.Drawing.Size(90, 25);
            this.btnTaoTheKhach.TabIndex = 23;
            this.btnTaoTheKhach.Text = "Tạo Thẻ Mới";
            this.btnTaoTheKhach.Click += new System.EventHandler(this.btnTaoTheKhach_Click);
            // 
            // frmHoaDon
            // 
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.txtGiamGia);
            this.Controls.Add(this.lblGiamGia);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.lblDonGia);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.cboNhanVien);
            this.Controls.Add(this.lblNhanVien);
            this.Controls.Add(this.cboSanPham);
            this.Controls.Add(this.lblSanPham);
            this.Controls.Add(this.dtpNgayBan);
            this.Controls.Add(this.lblNgayBan);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.txtMaHD);
            this.Controls.Add(this.lblMaHD);
            this.Controls.Add(this.btnTaoTheKhach);
            this.Name = "frmHoaDon";
            this.Text = "Quản lý Bán Hàng (Hóa Đơn)";
            this.Load += new System.EventHandler(this.frmHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblNgayBan;
        private System.Windows.Forms.DateTimePicker dtpNgayBan;
        private System.Windows.Forms.Label lblSanPham;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTaoTheKhach;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
    }
}