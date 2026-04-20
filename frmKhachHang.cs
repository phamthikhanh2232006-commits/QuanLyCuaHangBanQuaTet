using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace QuanLyCuaHangBanQuaTet
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
            txtSDT.SelectedIndexChanged += txtSDT_SelectedIndexChanged;
            txtSDT.Leave += txtSDT_SelectedIndexChanged; // Phát hiện khi gõ tay ròi chuyển ô
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            DataTable dt = DatabaseUtils.GetDataTable("SELECT SoDienThoai, MatKhau, HoTen, DiemTichLuy, NgayDangky FROM tblKhachhang");
            dgvKhachHang.DataSource = dt;

            // Xóa danh sách rớt xuống cũ và nạp danh sách SĐT mới vào ComboBox
            txtSDT.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                txtSDT.Items.Add(row["SoDienThoai"].ToString());
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại (Khóa) không được để trống!");
                return;
            }
            string query = "INSERT INTO tblKhachhang (SoDienThoai, MatKhau, HoTen) VALUES (@sdt, @mk, @ten)";
            SqlParameter[] paras = {
                new SqlParameter("@sdt", txtSDT.Text),
                new SqlParameter("@mk", string.IsNullOrEmpty(txtMatKhau.Text) ? "123456" : txtMatKhau.Text),
                new SqlParameter("@ten", string.IsNullOrEmpty(txtHoTen.Text) ? (object)DBNull.Value : txtHoTen.Text)
            };
            if (DatabaseUtils.ExecuteNonQuery(query, paras) > 0)
            {
                MessageBox.Show("Thêm Khách Hàng (hoặc Thẻ tích điểm) thành công!");
                LoadData();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Hãy chọn Khách hàng cần sửa!");
                return;
            }
            string query = "UPDATE tblKhachhang SET MatKhau=@mk, HoTen=@ten WHERE SoDienThoai=@sdt";
            SqlParameter[] paras = {
                new SqlParameter("@sdt", txtSDT.Text),
                new SqlParameter("@mk", txtMatKhau.Text),
                new SqlParameter("@ten", string.IsNullOrEmpty(txtHoTen.Text) ? (object)DBNull.Value : txtHoTen.Text)
            };
            if (DatabaseUtils.ExecuteNonQuery(query, paras) > 0)
            {
                MessageBox.Show("Cập nhật thông tin Khách hàng thành công!");
                LoadData();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSDT.Text)) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa thẻ Thành Viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM tblKhachhang WHERE SoDienThoai=@sdt";
                if (DatabaseUtils.ExecuteNonQuery(query, new SqlParameter[] { new SqlParameter("@sdt", txtSDT.Text) }) > 0)
                {
                    MessageBox.Show("Đã xóa Khách Hàng!");
                    LoadData();
                }
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = "%" + txtTimKiem.Text + "%";
            string query = "SELECT * FROM tblKhachhang WHERE SoDienThoai LIKE @k OR HoTen LIKE @k";
            DataTable dt = DatabaseUtils.GetDataTable(query, new SqlParameter[] { new SqlParameter("@k", keyword) });

            if (dt.Rows.Count > 0)
            {
                dgvKhachHang.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Số điện thoại hoặc tên này không tồn tại trong hệ thống!", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadData(); // Phục hồi lại danh sách cũ
            }
        }
        private void txtSDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSDT.Text)) return;

            DataTable dt = DatabaseUtils.GetDataTable("SELECT * FROM tblKhachhang WHERE SoDienThoai = @sdt",
                           new SqlParameter[] { new SqlParameter("@sdt", txtSDT.Text) });

            if (dt.Rows.Count > 0)
            {
                // Khi chọn SĐT có sẵn, tự động điền các thông tin của nó xuống dưới
                txtMatKhau.Text = dt.Rows[0]["MatKhau"].ToString();
                txtHoTen.Text = dt.Rows[0]["HoTen"].ToString();
                txtDiem.Text = dt.Rows[0]["DiemTichLuy"].ToString();
            }
            else
            {
                // Khi gõ SĐT mới toanh để Thêm khách hàng -> Xóa trắng các dòng dưới để nhập dứ liệu mới
                txtMatKhau.Clear();
                txtHoTen.Clear();
                txtDiem.Clear();
            }
        }
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtSDT.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value?.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                txtDiem.Text = row.Cells["DiemTichLuy"].Value?.ToString();
            }
        }
    }
}