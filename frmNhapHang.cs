using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace QuanLyCuaHangBanQuaTet
{
    public partial class frmNhapHang : Form
    {
        public frmNhapHang()
        {
            InitializeComponent();
        }
        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadData();
            // RBAC Kế toán
            string role = Program.CurrentUserRole.ToLower();
            if (role == "kế toán" || role == "ke toan" || role == "ketoan")
            {
                // Chỉ cấm xóa đơn hàng, vẫn cho kế toán xem và nhập hàng
                btnXoa.Enabled = false;
                if (dgvNhapHang != null) dgvNhapHang.ReadOnly = true;
            }
        }
        private void LoadComboBoxes()
        {
            txtMaDon.Text = "DN" + DateTime.Now.ToString("ddHHmmss");
            DataTable dtNCC = DatabaseUtils.GetDataTable("SELECT MaNhaCungCap, TenNhaCungCap FROM tblNhaCungCap");
            cboNhaCungCap.DataSource = dtNCC;
            cboNhaCungCap.DisplayMember = "TenNhaCungCap";
            cboNhaCungCap.ValueMember = "MaNhaCungCap";

            try
            {
                // Đoạn thêm để liên kết hộp Thoại Sản Phẩm
                DataTable dtSP = DatabaseUtils.GetDataTable("SELECT MaSanpham, TenSanpham FROM tblSanpham");

                // Nếu người dùng lỡ đặt tên combobox khác đi xíu, ta linh hoạt bắt lỗi
                if (cboSanPham != null)
                {
                    cboSanPham.DataSource = dtSP;
                    cboSanPham.DisplayMember = "TenSanpham";
                    cboSanPham.ValueMember = "MaSanpham";
                    // Gắn code tự động tìm Giá Sản Phẩm khi Chọn rớt xuống
                    cboSanPham.SelectedIndexChanged -= CboSanPham_SelectedIndexChanged; // Tránh gắn đúp
                    cboSanPham.SelectedIndexChanged += CboSanPham_SelectedIndexChanged;
                }
            }
            catch { }
        }
        private void CboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboSanPham.SelectedValue != null && cboSanPham.SelectedValue is string)
                {
                    string maSP = cboSanPham.SelectedValue.ToString();
                    DataTable dtPrice = DatabaseUtils.GetDataTable("SELECT GiaBan FROM tblSanpham WHERE MaSanpham=@ma", new SqlParameter[] { new SqlParameter("@ma", maSP) });
                    if (dtPrice.Rows.Count > 0)
                    {
                        // Lôi giá cũ ra điền sẵn, người dùng thích thì có thể gõ đè giá mới vào
                        decimal gia = Convert.ToDecimal(dtPrice.Rows[0]["GiaBan"]);
                        txtDonGia.Text = gia.ToString("0");
                    }
                }
            }
            catch { }
        }
        private void LoadData()
        {
            DataTable dt = DatabaseUtils.GetDataTable("SELECT * FROM vw_DanhSachDonNhapHang");
            dgvNhapHang.DataSource = dt;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO tblDonNhapHang(MaDonNhap, MaNhaCungCap, NgayNhap, TongTien, TrangThai, GhiChu) " +
                           "VALUES (@MaDonNhap, @MaNhaCungCap, GETDATE(), 0, N'Đang xử lý', @GhiChu)";
            SqlParameter[] paras = {
                new SqlParameter("@MaDonNhap", txtMaDon.Text.Trim()),
                new SqlParameter("@MaNhaCungCap", cboNhaCungCap.SelectedValue ?? DBNull.Value),
                new SqlParameter("@GhiChu", txtGhiChu.Text.Trim())
            };
            try
            {
                if (DatabaseUtils.ExecuteNonQuery(query, paras) > 0)
                {
                    MessageBox.Show("Thêm Đơn nhập hàng thành công! Vui lòng chọn Sản phẩm và lưu Chi tiết bên dưới.");
                    LoadData();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Mã Đơn Tạm này ĐÃ TỒN TẠI. Nếu anh/chị muốn nhập tiếp hàng vào đơn này, HÃY KÉO XUỐNG VÀ XÀI NÚT LƯU CHI TIẾT. Để tạo Phiếu Mới hoàn toàn, nhấn Tạo Đơn Mới (Xóa Form) nha!");
                }
                else
                {
                    MessageBox.Show("Lỗi CSDL: " + ex.Message);
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = "UPDATE tblDonNhapHang SET MaNhaCungCap=@MaNhaCungCap, " +
                           "TrangThai=@TrangThai, GhiChu=@GhiChu WHERE MaDonNhap=@MaDonNhap";
            SqlParameter[] paras = {
                new SqlParameter("@MaDonNhap", txtMaDon.Text.Trim()),
                new SqlParameter("@MaNhaCungCap", cboNhaCungCap.SelectedValue ?? DBNull.Value),
                new SqlParameter("@TrangThai", string.IsNullOrEmpty(txtTrangThai.Text) ? "Đang xử lý" : txtTrangThai.Text.Trim()),
                new SqlParameter("@GhiChu", txtGhiChu.Text.Trim())
            };
            if (DatabaseUtils.ExecuteNonQuery(query, paras) > 0)
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa hoàn toàn đơn nhập hàng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string md = txtMaDon.Text;
                DatabaseUtils.ExecuteNonQuery("DELETE FROM tblChitietNhapHang WHERE MaDonNhap=@md", new SqlParameter[] { new SqlParameter("@md", md) });
                int kq = DatabaseUtils.ExecuteNonQuery("DELETE FROM tblDonNhapHang WHERE MaDonNhap=@md", new SqlParameter[] { new SqlParameter("@md", md) });
                if (kq > 0)
                {
                    MessageBox.Show("Xóa hóa đơn nhập thành công!");
                    LoadData();
                }
            }
        }
        private bool ExecuteSP(string spName, SqlParameter[] paras)
        {
            int kq = 0;
            try
            {
                using (SqlConnection conn = DatabaseUtils.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(spName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(paras);
                        kq = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return false;
            }
            return true;
        }
        private void dgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhapHang.Rows[e.RowIndex];
                txtMaDon.Text = row.Cells["MaDonNhap"].Value.ToString();
                cboNhaCungCap.Text = row.Cells["TenNhaCungCap"].Value.ToString();
                txtTongTien.Text = row.Cells["TongTien"].Value.ToString();
                txtTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaDon.Text = "DN" + DateTime.Now.ToString("ddHHmmss");
            txtTongTien.Clear();
            txtGhiChu.Clear();
            txtTrangThai.Text = "Đang xử lý";
        }
        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            string maDN = txtMaDon.Text;
            string query = @"SELECT DN.MaDonNhap, NCC.TenNhaCungCap, DN.NgayNhap, NV.HoTen AS TenNhanVien, SP.TenSanpham, CT.SoluongNhap, CT.DonGiaNhap, (CT.SoluongNhap * CT.DonGiaNhap) AS ThanhTien
        FROM tblDonNhapHang DN
        JOIN tblNhaCungCap NCC ON DN.MaNhaCungCap = NCC.MaNhaCungCap
        JOIN tblChitietNhapHang CT ON DN.MaDonNhap = CT.MaDonNhap
        JOIN tblSanpham SP ON CT.MaSanpham = SP.MaSanpham
        JOIN tblNhanvien NV ON CT.MaNhanvien = NV.MaNhanvien
        WHERE DN.MaDonNhap = @ma";
            DataTable dt = DatabaseUtils.GetDataTable(query, new SqlParameter[] { new SqlParameter("@ma", maDN) });
            rptDonNhapHang rpt = new rptDonNhapHang();
            rpt.SetDataSource(dt);
            frmInHoaDon viewerForm = new frmInHoaDon();
            viewerForm.crystalReportViewer1.ReportSource = rpt;
            viewerForm.ShowDialog();
        }
        private void btnInPhieu_Click_1(object sender, EventArgs e)
        {
            string maDN = txtMaDon.Text;
            string query = @"SELECT DN.MaDonNhap, NCC.TenNhaCungCap, DN.NgayNhap, NV.HoTen AS TenNhanVien, SP.TenSanpham, CT.SoluongNhap, CT.DonGiaNhap, (CT.SoluongNhap * CT.DonGiaNhap) AS ThanhTien
        FROM tblDonNhapHang DN
        LEFT JOIN tblNhaCungCap NCC ON DN.MaNhaCungCap = NCC.MaNhaCungCap
        LEFT JOIN tblChitietNhapHang CT ON DN.MaDonNhap = CT.MaDonNhap
        LEFT JOIN tblSanpham SP ON CT.MaSanpham = SP.MaSanpham
        LEFT JOIN tblNhanvien NV ON CT.MaNhanvien = NV.MaNhanvien
        WHERE DN.MaDonNhap = @ma";
            DataTable dt = DatabaseUtils.GetDataTable(query, new SqlParameter[] { new SqlParameter("@ma", maDN) });
            if (dt.Rows.Count == 0 || (dt.Rows.Count == 1 && string.IsNullOrEmpty(dt.Rows[0]["TenSanpham"].ToString())))
            {
                MessageBox.Show($"Bị rỗng rồi! Không tìm thấy dữ liệu mặt hàng nào cho phiếu {maDN} trong Database. Hãy đảm bảo bạn đã lưu Chi Tiết Nhập Hàng trước khi in!");
                return;
            }
            rptDonNhapHang rpt = new rptDonNhapHang();
            rpt.SetDataSource(dt);
            frmInHoaDon viewerForm = new frmInHoaDon();
            viewerForm.crystalReportViewer1.ReportSource = rpt;
            viewerForm.ShowDialog();
        }
        private void btnLuuChiTiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoLuong.Text) || string.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Rỗng rồi kìa! Phải gõ Số Lượng (VD: 23) và Đơn Giá (VD: 2400) mới lưu được!");
                return;
            }
            try
            {
                // Lấy 1 nhân viên bất kỳ còn tồn tại trong kho (để tránh lỗi 547 nếu NV01 đã bị xóa)
                DataTable dtNV = DatabaseUtils.GetDataTable("SELECT TOP 1 MaNhanvien FROM tblNhanvien");
                string maNVThuCong = dtNV.Rows.Count > 0 ? dtNV.Rows[0][0].ToString() : "NV01";
                string query = "INSERT INTO tblChitietNhapHang (MaDonNhap, MaSanpham, MaNhanvien, SoluongNhap, DonGiaNhap) " +
                               "VALUES (@MaDonNhap, @MaSanpham, @MaNhanvien, @SoluongNhap, @DonGiaNhap)";
                SqlParameter[] paras = {
                    new SqlParameter("@MaDonNhap", txtMaDon.Text.Trim()),
                    new SqlParameter("@MaSanpham", cboSanPham.SelectedValue),
                    new SqlParameter("@MaNhanvien", maNVThuCong),
                    new SqlParameter("@SoluongNhap", int.Parse(txtSoLuong.Text.Trim())),
                    new SqlParameter("@DonGiaNhap", decimal.Parse(txtDonGia.Text.Trim()))
                };
                if (DatabaseUtils.ExecuteNonQuery(query, paras) > 0)
                {
                    // Tự động CỘNG DỒN tổng tiền vào Phiếu Nhập Hàng, tạo một Parameter Array MỚI HOÀN TOÀN để tránh lỗi "is already contained"
                    string queryUpdateTongTien = "UPDATE tblDonNhapHang SET TongTien = TongTien + (@SoLuong * @DonGia), TrangThai = N'Hoàn thành' WHERE MaDonNhap = @MaDon";
                    SqlParameter[] parasUpdate = {
                        new SqlParameter("@MaDon", txtMaDon.Text.Trim()),
                        new SqlParameter("@SoLuong", Convert.ToInt32(txtSoLuong.Text.Trim())),
                        new SqlParameter("@DonGia", Convert.ToDecimal(txtDonGia.Text.Trim()))
                    };
                    DatabaseUtils.ExecuteNonQuery(queryUpdateTongTien, parasUpdate);

                    MessageBox.Show("Nhập thêm hàng vô Đơn thành công! Máy đã cộng số lượng vào Kho và Cập nhật Tổng Tiền Phiếu.");
                    txtSoLuong.Clear();
                    txtDonGia.Clear();
                    LoadData(); // Tải lại DataGrid để kế toán thấy Tổng Tiền nhảy số
                    
                    // Lôi cái Tổng Tiền mới nhất từ CSDL đắp thẳng lên mặt TextBox cho người dùng khỏi hoang mang
                    DataTable dtTienMoi = DatabaseUtils.GetDataTable("SELECT TongTien FROM tblDonNhapHang WHERE MaDonNhap=@ma", new SqlParameter[] { new SqlParameter("@ma", txtMaDon.Text.Trim()) });
                    if(dtTienMoi.Rows.Count > 0) {
                        txtTongTien.Text = dtTienMoi.Rows[0]["TongTien"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Phân biệt nếu bị lỗi trùng sản phẩm
                if (ex.Message.Contains("Violation of PRIMARY KEY"))
                {
                    MessageBox.Show("Sản phẩm này ĐÃ CÓ TRONG ĐƠN NHẬP này rồi! Không thể thêm trùng lặp.", "Lỗi");
                }
                else
                {
                    MessageBox.Show("Lỗi chi tiết khi lưu hàng: " + ex.Message, "Lỗi");
                }
            }
        }
    }
}