using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace QuanLyCuaHangBanQuaTet
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadChucVu();
            LoadData();
        }
        private void LoadChucVu()
        {
            DataTable dt = DatabaseUtils.GetDataTable("SELECT * FROM tblChucvu");
            cboChucVu.DataSource = dt;
            cboChucVu.DisplayMember = "TenChucvu";
            cboChucVu.ValueMember = "MaChucvu";
        }
        private void LoadData()
        {
            string query = "SELECT NV.MaNhanvien, NV.HoTen, NV.GioiTinh, NV.DiaChi, NV.SoDienThoai, CV.TenChucvu " +
                           "FROM tblNhanvien NV JOIN tblChucvu CV ON NV.MaChucvu = CV.MaChucvu";
            dgvNhanVien.DataSource = DatabaseUtils.GetDataTable(query);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO tblNhanvien(MaNhanvien, HoTen, GioiTinh, DiaChi, SoDienThoai, MaChucvu) VALUES (@ma, @ten, @gt, @dc, @sdt, @cv)";
            SqlParameter[] p = {
                new SqlParameter("@ma", txtMa.Text),
                new SqlParameter("@ten", txtTen.Text),
                new SqlParameter("@gt", cboGioiTinh.Text),
                new SqlParameter("@dc", txtDiaChi.Text),
                new SqlParameter("@sdt", txtSDT.Text),
                new SqlParameter("@cv", cboChucVu.SelectedValue)
            };
            if (DatabaseUtils.ExecuteNonQuery(query, p) > 0)
            {
                MessageBox.Show("Thêm nhân viên thành công!");
                LoadData();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = "UPDATE tblNhanvien SET HoTen=@ten, GioiTinh=@gt, DiaChi=@dc, SoDienThoai=@sdt, MaChucvu=@cv WHERE MaNhanvien=@ma";
            SqlParameter[] p = {
                new SqlParameter("@ma", txtMa.Text),
                new SqlParameter("@ten", txtTen.Text),
                new SqlParameter("@gt", cboGioiTinh.Text),
                new SqlParameter("@dc", txtDiaChi.Text),
                new SqlParameter("@sdt", txtSDT.Text),
                new SqlParameter("@cv", cboChucVu.SelectedValue)
            };
            if (DatabaseUtils.ExecuteNonQuery(query, p) > 0)
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM tblNhanvien WHERE MaNhanvien=@ma";
                if (DatabaseUtils.ExecuteNonQuery(query, new SqlParameter[] { new SqlParameter("@ma", txtMa.Text) }) > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = "SELECT NV.MaNhanvien, NV.HoTen, NV.GioiTinh, NV.DiaChi, NV.SoDienThoai, CV.TenChucvu " +
                           "FROM tblNhanvien NV JOIN tblChucvu CV ON NV.MaChucvu = CV.MaChucvu " +
                           "WHERE NV.HoTen LIKE @kw OR NV.MaNhanvien LIKE @kw OR NV.SoDienThoai LIKE @kw";
            dgvNhanVien.DataSource = DatabaseUtils.GetDataTable(query, new SqlParameter[] { new SqlParameter("@kw", "%" + txtTimKiem.Text + "%") });
        }
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMa.Text = row.Cells["MaNhanvien"].Value.ToString();
                txtTen.Text = row.Cells["HoTen"].Value.ToString();
                cboGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                cboChucVu.Text = row.Cells["TenChucvu"].Value.ToString();
            }
        }
    }
}
