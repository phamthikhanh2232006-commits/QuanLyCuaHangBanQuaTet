namespace QuanLyCuaHangBanQuaTet
{
    partial class frmNhapHang
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
            this.lblMaDon = new System.Windows.Forms.Label();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.lblNhaCungCap = new System.Windows.Forms.Label();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvNhapHang = new System.Windows.Forms.DataGridView();
            this.btnInPhieu = new System.Windows.Forms.Button();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.btnLuuChiTiet = new System.Windows.Forms.Button();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapHang)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaDon
            // 
            this.lblMaDon.Location = new System.Drawing.Point(20, 20);
            this.lblMaDon.Name = "lblMaDon";
            this.lblMaDon.Size = new System.Drawing.Size(100, 23);
            this.lblMaDon.TabIndex = 14;
            this.lblMaDon.Text = "Mã Đơn Tạm:";
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(110, 17);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(100, 22);
            this.txtMaDon.TabIndex = 13;
            // 
            // lblNhaCungCap
            // 
            this.lblNhaCungCap.Location = new System.Drawing.Point(240, 20);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(100, 23);
            this.lblNhaCungCap.TabIndex = 12;
            this.lblNhaCungCap.Text = "Nhà Cung Cấp:";
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCungCap.Location = new System.Drawing.Point(346, 12);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(121, 24);
            this.cboNhaCungCap.TabIndex = 11;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Location = new System.Drawing.Point(240, 60);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(100, 23);
            this.lblTrangThai.TabIndex = 8;
            this.lblTrangThai.Text = "Trạng Thái:";
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(330, 57);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(100, 22);
            this.txtTrangThai.TabIndex = 7;
            this.txtTrangThai.Text = "Đang xử lý";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(20, 100);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(100, 23);
            this.lblGhiChu.TabIndex = 6;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(100, 97);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(350, 22);
            this.txtGhiChu.TabIndex = 5;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(23, 174);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 30);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm Đơn Mới";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(285, 174);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 30);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Cập Nhật Hóa Đơn";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(433, 171);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 30);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa Đơn Nhập";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(568, 171);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 30);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Tạo Đơn Mới (Xóa Form)";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // dgvNhapHang
            // 
            this.dgvNhapHang.ColumnHeadersHeight = 29;
            this.dgvNhapHang.Location = new System.Drawing.Point(23, 219);
            this.dgvNhapHang.Name = "dgvNhapHang";
            this.dgvNhapHang.RowHeadersWidth = 51;
            this.dgvNhapHang.Size = new System.Drawing.Size(650, 200);
            this.dgvNhapHang.TabIndex = 0;
            this.dgvNhapHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhapHang_CellClick);
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Location = new System.Drawing.Point(168, 178);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(75, 23);
            this.btnInPhieu.TabIndex = 15;
            this.btnInPhieu.Text = "In Đơn ";
            this.btnInPhieu.UseVisualStyleBackColor = true;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click_1);
            // 
            // cboSanPham
            // 
            this.cboSanPham.FormattingEnabled = true;
            this.cboSanPham.Location = new System.Drawing.Point(243, 143);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(121, 24);
            this.cboSanPham.TabIndex = 16;
            // 
            // btnLuuChiTiet
            // 
            this.btnLuuChiTiet.Location = new System.Drawing.Point(583, 145);
            this.btnLuuChiTiet.Name = "btnLuuChiTiet";
            this.btnLuuChiTiet.Size = new System.Drawing.Size(105, 23);
            this.btnLuuChiTiet.TabIndex = 17;
            this.btnLuuChiTiet.Text = "Lưu Chi Tiết ";
            this.btnLuuChiTiet.UseVisualStyleBackColor = true;
            this.btnLuuChiTiet.Click += new System.EventHandler(this.btnLuuChiTiet_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(59, 146);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(100, 22);
            this.txtSoLuong.TabIndex = 18;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(462, 146);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(100, 22);
            this.txtDonGia.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "SL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Sản Phẩm ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(385, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Đơn Giá ";
            // 
            // lblTongTien
            // 
            this.lblTongTien.Location = new System.Drawing.Point(20, 60);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(100, 23);
            this.lblTongTien.TabIndex = 23;
            this.lblTongTien.Text = "Tổng Tiền:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(110, 57);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(100, 22);
            this.txtTongTien.TabIndex = 24;
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmNhapHang
            // 
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.btnLuuChiTiet);
            this.Controls.Add(this.cboSanPham);
            this.Controls.Add(this.btnInPhieu);
            this.Controls.Add(this.dgvNhapHang);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.txtTrangThai);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.cboNhaCungCap);
            this.Controls.Add(this.lblNhaCungCap);
            this.Controls.Add(this.txtMaDon);
            this.Controls.Add(this.lblMaDon);
            this.Name = "frmNhapHang";
            this.Text = "Quản lý Đơn Nhập Hàng";
            this.Load += new System.EventHandler(this.frmNhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhapHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label lblMaDon;
        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label lblNhaCungCap;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvNhapHang;
        private System.Windows.Forms.Button btnInPhieu;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.Button btnLuuChiTiet;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
    }
}
