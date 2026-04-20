using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
namespace QuanLyCuaHangBanQuaTet
{
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();

            // Đăng ký sự kiện tự động cho POS
            cboSanPham.SelectedIndexChanged += cboSanPham_SelectedIndexChanged;
            txtSDT.Leave += txtSDT_Leave;

            // Sửa Text các nút lại cho đúng với máy tính tiền
            btnSua.Text = "Thanh toán & Mới";
            btnXoa.Text = "Xóa món";
            btnThem.Text = "Thêm món vào Giỏ";
        }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            TaoMoiHoaDon(); // Mở lên là tự tạo 1 phiên trống mới

            // Mở quyền bán hàng cho Kế toán
            // string role = Program.CurrentUserRole.ToLower();
            // if (role == "kế toán" || role == "ke toan" || role == "ketoan")
            // {
            //     // Hệ thống đã mở full quyền, không khóa nữa
            // }
        }
        private void LoadComboBoxes()
        {
            // Load Sản Phẩm
            DataTable dtSP = DatabaseUtils.GetDataTable("SELECT MaSanpham, TenSanpham FROM tblSanpham");
            cboSanPham.DataSource = dtSP;
            cboSanPham.DisplayMember = "TenSanpham";
            cboSanPham.ValueMember = "MaSanpham";
            // Load Nhân Viên (để chọn người bán)
            DataTable dtNV = DatabaseUtils.GetDataTable("SELECT HoTen FROM tblNhanvien");
            cboNhanVien.DataSource = dtNV;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "HoTen";
        }
        private void TaoMoiHoaDon()
        {
            // Tự động sinh mã hóa đơn duy nhất theo thời gian hiện tại
            txtMaHD.Text = "HD" + DateTime.Now.ToString("yyMMddHHmmss");
            txtMaHD.ReadOnly = true;

            txtSDT.Clear();
            txtSoLuong.Text = "1";
            txtGiamGia.Text = "0";

            LoadData(); // Load giỏ hàng của chính cái Hóa đơn mới này (Cơ bản là Grid sẽ được Clear láng o)
        }
        private void LoadData()
        {
            // CHỈ LOAD GIỎ HÀNG CỦA HÓA ĐƠN HIỆN TẠI ĐANG THAO TÁC, KHÔNG LOAD TOÀN BỘ CSDL
            string query = "SELECT * FROM vw_HoaDonChiTiet WHERE MaDonhang = @ma";
            DataTable dt = DatabaseUtils.GetDataTable(query, new SqlParameter[] { new SqlParameter("@ma", txtMaHD.Text) });
            dgvHoaDon.DataSource = dt;

            // Xóa các cột thừa do View mang sang hiển thị (chỉ giữ lại SP)
            string[] cacCotThua = { "MaDonhang", "TenKhachHang", "SoDienThoai", "DiaChiGiaoHang", "NgayDatHang", "TenNhanVien", "MaGiamGia" };
            foreach (string cot in cacCotThua)
            {
                if (dgvHoaDon.Columns.Contains(cot))
                    dgvHoaDon.Columns[cot].Visible = false;
            }

            // Tính tổng tiền
            decimal tong = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["ThanhTien"] != DBNull.Value)
                    tong += Convert.ToDecimal(row["ThanhTien"]);
            }
            if(txtTongTien != null) txtTongTien.Text = tong.ToString("N0");
        }
        // Tự động điền giá khi chọn Sản Phẩm (POS Feature)
        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedIndex >= 0 && cboSanPham.SelectedValue != null)
            {
                string msp = cboSanPham.SelectedValue.ToString();
                if (msp.Contains("DataRowView")) return; // Bỏ qua nhịp load ảo của DataBinding

                DataTable dt = DatabaseUtils.GetDataTable("SELECT GiaBan FROM tblSanpham WHERE MaSanpham = @msp",
                                new SqlParameter[] { new SqlParameter("@msp", msp) });
                if (dt.Rows.Count > 0)
                {
                    txtDonGia.Text = dt.Rows[0]["GiaBan"].ToString();
                }
            }
        }
        // Tự động tìm Khách hàng khi rời ô SDT (POS Feature)
        private void txtSDT_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSDT.Text)) return;

            DataTable dt = DatabaseUtils.GetDataTable("SELECT DiemTichLuy FROM tblKhachhang WHERE SoDienThoai = @sdt",
                            new SqlParameter[] { new SqlParameter("@sdt", txtSDT.Text) });

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show($"Tìm thấy khách quen! Điểm tích lũy hiện tại: {dt.Rows[0]["DiemTichLuy"]} điểm", "Thẻ Tích Điểm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Không tìm thấy thì bỏ qua
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Mã Hóa Đơn bị rỗng!");
                return;
            }
            // Nếu không có Thẻ TV -> Tự động đánh dấu là Khách Lẻ (0000000000)
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                txtSDT.Text = "0000000000";

                // Mẹo: Đảm bảo trong CSDL có chứa Số Tạm này để khỏi dính lỗi Foreign Key
                string qCheck = "IF NOT EXISTS (SELECT 1 FROM tblKhachhang WHERE SoDienThoai='0000000000') " +
                                "INSERT INTO tblKhachhang(SoDienThoai, HoTen) VALUES ('0000000000', N'Khách Lẻ')";
                DatabaseUtils.ExecuteNonQuery(qCheck);
            }
            string query = "EXEC sp_ThemHoaDon @MaHoaDon, @SoDienThoai, @TenKhachHang, @TenNhanVien, @DiaChi, @MaSanPham, @SoLuong, @DonGia, @GiamGia, @MaGiamGia";
            SqlParameter[] paras = {
                new SqlParameter("@MaHoaDon", txtMaHD.Text),
                new SqlParameter("@SoDienThoai", txtSDT.Text),
                new SqlParameter("@TenKhachHang", DBNull.Value),
                new SqlParameter("@TenNhanVien", cboNhanVien.Text),
                new SqlParameter("@DiaChi", DBNull.Value),
                new SqlParameter("@MaSanPham", cboSanPham.SelectedValue),
                new SqlParameter("@SoLuong", int.Parse(txtSoLuong.Text)),
                new SqlParameter("@DonGia", decimal.Parse(string.IsNullOrEmpty(txtDonGia.Text) ? "0" : txtDonGia.Text)),
                new SqlParameter("@GiamGia", decimal.Parse(string.IsNullOrEmpty(txtGiamGia.Text) ? "0" : txtGiamGia.Text)),
                new SqlParameter("@MaGiamGia", DBNull.Value) // Bỏ qua nếu ko xài Voucher
            };
            if (DatabaseUtils.ExecuteNonQuery(query, paras) > 0 || true)
            {
                LoadData(); // Cập nhật giỏ hàng ngay lập tức
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Nút này giờ là "Thanh toán & Tính Tiền (Mở HĐ Mới)"
            if (dgvHoaDon.Rows.Count <= 1)
            {
                MessageBox.Show("Giỏ hàng đang trống!");
                return;
            }

            // Xóa sổ, sẵn sàng cho người tiếp theo
            MessageBox.Show("Thanh toán thành công! Hệ thống tự động trừ kho và lấy điểm tích lũy.", "Thành Công");
            TaoMoiHoaDon();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Xóa món khỏi giỏ hàng
            if (dgvHoaDon.CurrentRow != null && MessageBox.Show("Gỡ món này khỏi giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string mahd = txtMaHD.Text;
                string masp = dgvHoaDon.CurrentRow.Cells["TenSanpham"].Value.ToString();

                // Mẹo: Vì Grid đang hiện Tên nhưng DB cần Mã SP, ta join hoặc subquery
                string q = "DELETE FROM tblChiTietDonHang WHERE MaDonhang=@mhd AND MaSanpham = (SELECT MaSanpham FROM tblSanpham WHERE TenSanpham=@tensp)";
                DatabaseUtils.ExecuteNonQuery(q, new SqlParameter[] {
                    new SqlParameter("@mhd", mahd),
                    new SqlParameter("@tensp", masp)
                });
                LoadData();
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count <= 1)
            {
                MessageBox.Show("Giao dịch/Giỏ hàng này trống, mời thêm hàng trước khi in!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string maHD = txtMaHD.Text;
                // Lấy dữ liệu Giỏ hàng dựa theo Mã hóa đơn hiện tại
                string query = "SELECT * FROM vw_HoaDonChiTiet WHERE MaDonhang = @ma";
                DataTable dt = DatabaseUtils.GetDataTable(query, new SqlParameter[] { new SqlParameter("@ma", maHD) });

                if (dt.Rows.Count > 0)
                {
                    // 1. Phác thảo File Mẫu rptHoaDon
                    rptHoaDon bao_cao = new rptHoaDon();
                    bao_cao.SetDataSource(dt);

                    // 2. Gọi cái màn hình (Khung form) lên
                    frmInHoaDon formViewer = new frmInHoaDon();
                    // Lưu ý: Nếu máy bạn báo lỗi dòng chữ này, hãy xoá thử để chữ C in thường (crystalReportViewer1) nhé
                    formViewer.crystalReportViewer1.ReportSource = bao_cao;
                    formViewer.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu hóa đơn này trong hệ thống Database!", "Thông báo lỗi Load");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hệ thống Crystal Report đang gặp trục trặc: " + ex.Message, "Lỗi in báo cáo");
            }
        }
        private void btnTaoTheKhach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập SĐT để tạo Thẻ Thành Viên mới!", "Thông báo");
                return;
            }
            string q = "INSERT INTO tblKhachhang(SoDienThoai, HoTen, MatKhau, DiemTichLuy) VALUES (@sdt, NULL, '123456', 0)";
            SqlParameter[] p = {
                new SqlParameter("@sdt", txtSDT.Text.Trim())
            };
            if (DatabaseUtils.ExecuteNonQuery(q, p) > 0)
            {
                MessageBox.Show("Tạo Thẻ Thành Viên thành công! Khách hàng bắt đầu được phép tích lũy điểm.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

}
