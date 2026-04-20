namespace QuanLyCuaHangBanQuaTet
{
    partial class frmSanPham
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
            this.lblMaSP = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.ComboBox();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblDVT = new System.Windows.Forms.Label();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaSP
            // 
            this.lblMaSP.Location = new System.Drawing.Point(20, 20);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(100, 23);
            this.lblMaSP.TabIndex = 18;
            this.lblMaSP.Text = "Mã SP:";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(80, 17);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(121, 24);
            this.txtMaSP.TabIndex = 17;
            // 
            // lblTenSP
            // 
            this.lblTenSP.Location = new System.Drawing.Point(250, 20);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(100, 23);
            this.lblTenSP.TabIndex = 16;
            this.lblTenSP.Text = "Tên SP:";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(310, 17);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(100, 22);
            this.txtTenSP.TabIndex = 15;
            // 
            // lblDanhMuc
            // 
            this.lblDanhMuc.Location = new System.Drawing.Point(20, 60);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Size = new System.Drawing.Size(100, 23);
            this.lblDanhMuc.TabIndex = 14;
            this.lblDanhMuc.Text = "Danh Mục:";
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.Location = new System.Drawing.Point(92, 57);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(121, 24);
            this.cboDanhMuc.TabIndex = 13;
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.Location = new System.Drawing.Point(250, 60);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(100, 23);
            this.lblGiaBan.TabIndex = 12;
            this.lblGiaBan.Text = "Giá Bán:";
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(310, 57);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(100, 22);
            this.txtGiaBan.TabIndex = 11;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Location = new System.Drawing.Point(20, 100);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(100, 23);
            this.lblSoLuong.TabIndex = 10;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(80, 97);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(100, 22);
            this.txtSoLuong.TabIndex = 9;
            // 
            // lblDVT
            // 
            this.lblDVT.Location = new System.Drawing.Point(250, 100);
            this.lblDVT.Name = "lblDVT";
            this.lblDVT.Size = new System.Drawing.Size(100, 23);
            this.lblDVT.TabIndex = 8;
            this.lblDVT.Text = "ĐVT:";
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(310, 97);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(100, 22);
            this.txtDVT.TabIndex = 7;
            // 
            // lblMoTa
            // 
            this.lblMoTa.Location = new System.Drawing.Point(20, 140);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(100, 23);
            this.lblMoTa.TabIndex = 6;
            this.lblMoTa.Text = "Mô Tả:";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(80, 137);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(330, 22);
            this.txtMoTa.TabIndex = 5;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(80, 180);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(180, 180);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Cập nhật";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(280, 180);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(520, 180);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm kiếm";
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.ColumnHeadersHeight = 29;
            this.dgvSanPham.Location = new System.Drawing.Point(20, 230);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.Size = new System.Drawing.Size(700, 250);
            this.dgvSanPham.TabIndex = 0;
            this.dgvSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellClick);
            // 
            // frmSanPham
            // 
            this.ClientSize = new System.Drawing.Size(750, 500);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.txtDVT);
            this.Controls.Add(this.lblDVT);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.lblGiaBan);
            this.Controls.Add(this.cboDanhMuc);
            this.Controls.Add(this.lblDanhMuc);
            this.Controls.Add(this.txtTenSP);
            this.Controls.Add(this.lblTenSP);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.lblMaSP);
            this.Name = "frmSanPham";
            this.Text = "Quản lý Sản Phẩm";
            this.Load += new System.EventHandler(this.frmSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.ComboBox txtMaSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblDVT;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvSanPham;
    }
}