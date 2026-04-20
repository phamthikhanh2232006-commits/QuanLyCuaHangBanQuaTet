using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace QuanLyCuaHangBanQuaTet
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // 1. Kiểm tra bảng Nhân Viên
            string qNhanVien = "SELECT Quyen FROM tblUser WHERE Username = @user AND Password = @pass";
            SqlParameter[] tNV = new SqlParameter[] { new SqlParameter("@user", user), new SqlParameter("@pass", pass) };
            DataTable dtNV = DatabaseUtils.GetDataTable(qNhanVien, tNV);
            if (dtNV.Rows.Count > 0)
            {
                string quyen = dtNV.Rows[0]["Quyen"].ToString();
                Program.CurrentUserRole = quyen;
                ChuyenTrangChu(quyen);
                return;
            }
            // 2. Kiểm tra bảng Khách Hàng (Tài khoản = SĐT Khách hàng)
            string qKhachHang = "SELECT HoTen FROM tblKhachhang WHERE SoDienThoai = @user AND MatKhau = @pass";
            SqlParameter[] tKH = new SqlParameter[] { new SqlParameter("@user", user), new SqlParameter("@pass", pass) };
            DataTable dtKH = DatabaseUtils.GetDataTable(qKhachHang, tKH);
            if (dtKH.Rows.Count > 0)
            {
                Program.CurrentUserRole = "Khách Hàng";
                ChuyenTrangChu("Khách Hàng");
                return;
            }
            // 3. Đăng nhập sai
            MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void ChuyenTrangChu(string quyen)
        {
            MessageBox.Show($"Đăng nhập thành công với vai trò: {quyen}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            frmMain mainForm = new frmMain(quyen);
            mainForm.ShowDialog();
            this.Close();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
