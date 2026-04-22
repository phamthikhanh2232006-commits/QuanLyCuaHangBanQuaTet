using System;
using System.Windows.Forms;
namespace QuanLyCuaHangBanQuaTet
{
    public partial class frmMain : Form
    {
        private string currentUserRole = "User";
        public frmMain(string role = "Admin")
        {
            InitializeComponent();
            this.currentUserRole = role;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"XIN CHÀO: {currentUserRole.ToUpper()}";
            // Phân quyền hiển thị Menu
            if (currentUserRole == "Khách Hàng")
            {
                btnKhachHang.Visible = false;
                btnHoaDon.Visible = true;
                btnNhapHang.Visible = false;
                btnNhanVien.Visible = false;
                btnThongKe.Visible = false;
                btnSanPham.Text = "Xem Món Quà Tết";
            }
            else if (currentUserRole.ToLower() == "nhân viên" || currentUserRole.ToLower() == "nhan vien" || currentUserRole.ToLower() == "user" || currentUserRole.ToLower() == "nhanvien")
            {
                // Chỉ cấp quyền POS Bán Hàng, Thẻ Khách Hàng
                btnKhachHang.Visible = true;
                btnHoaDon.Visible = true;
                btnSanPham.Visible = false;
                btnNhapHang.Visible = false;
                btnNhanVien.Visible = false;
                btnThongKe.Visible = false;
            }
            else if (currentUserRole.ToLower() == "kế toán" || currentUserRole.ToLower() == "ke toan" || currentUserRole.ToLower() == "ketoan")
            {
                // Kế toán: Nhân viên, Sản phẩm, Bán hàng, Khách hàng
                btnNhapHang.Visible = true;
                btnThongKe.Visible = true;
            }
            // Admin thì hiển thị tất cả
        }
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            if (currentUserRole == "Admin" || currentUserRole.ToLower().Contains("kế toán") || currentUserRole.ToLower() == "ke toan" || currentUserRole.ToLower() == "ketoan" || currentUserRole.ToLower().Contains("nhân viên") || currentUserRole.ToLower().Contains("nhan vien") || currentUserRole.ToLower().Contains("nhanvien") || currentUserRole.ToLower() == "user")
            {
                frmKhachHang f = new frmKhachHang();
                f.ShowDialog();
            }
            else MessageBox.Show("Bạn không có quyền truy cập mục này!");
        }
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            if (currentUserRole == "Admin" || currentUserRole.ToLower() == "kế toán" || currentUserRole.ToLower() == "ke toan" || currentUserRole.ToLower() == "ketoan" || currentUserRole == "Khách Hàng")
            {
                frmSanPham f = new frmSanPham();
                f.ShowDialog();
            }
            else MessageBox.Show("Bạn không có quyền truy cập mục này!");
        }
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            if (currentUserRole == "Admin" || currentUserRole.ToLower().Contains("kế toán") || currentUserRole.ToLower() == "ke toan" || currentUserRole.ToLower() == "ketoan" || currentUserRole.ToLower().Contains("nhân viên") || currentUserRole.ToLower().Contains("nhan vien") || currentUserRole.ToLower().Contains("nhanvien") || currentUserRole.ToLower() == "user")
            {
                frmHoaDon f = new frmHoaDon();
                f.ShowDialog();
            }
            else MessageBox.Show("Bạn không có quyền truy cập mục này!");
        }
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            if (currentUserRole == "Admin" || currentUserRole.ToLower().Contains("kế toán") || currentUserRole.ToLower() == "ke toan" || currentUserRole.ToLower() == "ketoan")
            {
                frmNhapHang f = new frmNhapHang();
                f.ShowDialog();
            }
            else MessageBox.Show("Chỉ có Admin và Kế toán mới được xem mục này!");
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            if (currentUserRole == "Admin" || currentUserRole.ToLower() == "kế toán" || currentUserRole.ToLower() == "ke toan" || currentUserRole.ToLower() == "ketoan")
            {
                frmNhanVien f = new frmNhanVien();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chỉ có Admin và Kế toán mới được xem mục này!");
            }
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (currentUserRole == "Admin" || currentUserRole.ToLower().Contains("kế toán") || currentUserRole.ToLower() == "ke toan" || currentUserRole.ToLower() == "ketoan")
            {
                frmThongKe f = new frmThongKe();
                f.ShowDialog();
            }
            else MessageBox.Show("Chỉ có Admin và Kế toán mới được xem mục này!");
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin f = new frmLogin();
            f.Show();
        }
    }
}
