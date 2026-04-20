using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace QuanLyCuaHangBanQuaTet
{
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
            txtMaSP.SelectedIndexChanged += txtMaSP_SelectedIndexChanged;
            txtMaSP.Leave += txtMaSP_SelectedIndexChanged;
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
            LoadData();

            // RBAC Kế toán
            string role = Program.CurrentUserRole.ToLower();
            if (role == "kế toán" || role == "ke toan" || role == "ketoan")
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                if(dgvSanPham != null) dgvSanPham.ReadOnly = true;
            }
        }
        private void LoadDanhMuc()
        {
            DataTable dt = DatabaseUtils.GetDataTable("SELECT * FROM tblDanhMuc");
            cboDanhMuc.DataSource = dt;
            cboDanhMuc.DisplayMember = "TenDanhMuc";
            cboDanhMuc.ValueMember = "MaDanhMuc";
        }
        private void LoadData()
        {
            string query = "SELECT SP.MaSanpham, SP.TenSanpham, DM.TenDanhMuc, SP.GiaBan, " +
                           "ISNULL((SELECT TOP 1 DonGiaNhap FROM tblChitietNhapHang WHERE MaSanpham = SP.MaSanpham ORDER BY DonGiaNhap DESC), 0) AS GiaNhapGanNhat, " +
                           "SP.Soluongton, SP.DonViTinh, SP.MoTa " +
                           "FROM tblSanpham SP JOIN tblDanhMuc DM ON SP.MaDanhMuc = DM.MaDanhMuc";
            DataTable dt = DatabaseUtils.GetDataTable(query);
            dgvSanPham.DataSource = dt;

            txtMaSP.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                txtMaSP.Items.Add(row["MaSanpham"].ToString());
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO tblSanpham(MaSanpham, TenSanpham, MaDanhMuc, GiaBan, Soluongton, DonViTinh, MoTa) " +
                           "VALUES (@ma, @ten, @madm, @gia, @sl, @dvt, @mota)";
            SqlParameter[] paras = {
                new SqlParameter("@ma", txtMaSP.Text),
                new SqlParameter("@ten", txtTenSP.Text),
                new SqlParameter("@madm", cboDanhMuc.SelectedValue),
                new SqlParameter("@gia", decimal.Parse(txtGiaBan.Text.Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture)),
                new SqlParameter("@sl", int.Parse(txtSoLuong.Text)),
                new SqlParameter("@dvt", txtDVT.Text),
                new SqlParameter("@mota", txtMoTa.Text)
            };

            if (DatabaseUtils.ExecuteNonQuery(query, paras) > 0)
            {
                MessageBox.Show("Thêm thành công!");
                LoadData();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = "UPDATE tblSanpham SET TenSanpham=@ten, MaDanhMuc=@madm, GiaBan=@gia, Soluongton=@sl, DonViTinh=@dvt, MoTa=@mota WHERE MaSanpham=@ma";
            SqlParameter[] paras = {
                new SqlParameter("@ma", txtMaSP.Text),
                new SqlParameter("@ten", txtTenSP.Text),
                new SqlParameter("@madm", cboDanhMuc.SelectedValue),
                new SqlParameter("@gia", decimal.Parse(txtGiaBan.Text.Replace(",", ""), System.Globalization.CultureInfo.InvariantCulture)),
                new SqlParameter("@sl", int.Parse(txtSoLuong.Text)),
                new SqlParameter("@dvt", txtDVT.Text),
                new SqlParameter("@mota", txtMoTa.Text)
            };

            if (DatabaseUtils.ExecuteNonQuery(query, paras) > 0)
            {
                MessageBox.Show("Sửa thành công!");
                LoadData();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM tblSanpham WHERE MaSanpham=@ma";
                if (DatabaseUtils.ExecuteNonQuery(query, new SqlParameter[] { new SqlParameter("@ma", txtMaSP.Text) }) > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
            }
        }
        private void txtMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text)) return;
            string query = "SELECT * FROM tblSanpham WHERE MaSanpham = @ma";
            DataTable dt = DatabaseUtils.GetDataTable(query, new SqlParameter[] { new SqlParameter("@ma", txtMaSP.Text) });

            if (dt.Rows.Count > 0)
            {
                txtTenSP.Text = dt.Rows[0]["TenSanpham"].ToString();
                cboDanhMuc.SelectedValue = dt.Rows[0]["MaDanhMuc"];
                txtGiaBan.Text = dt.Rows[0]["GiaBan"].ToString();
                txtSoLuong.Text = dt.Rows[0]["Soluongton"].ToString();
                txtDVT.Text = dt.Rows[0]["DonViTinh"].ToString();
                txtMoTa.Text = dt.Rows[0]["MoTa"].ToString();
            }
            else
            {
                txtTenSP.Clear();
                txtGiaBan.Clear();
                txtSoLuong.Clear();
                txtDVT.Clear();
                txtMoTa.Clear();
            }
        }
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["MaSanpham"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSanpham"].Value.ToString();
                cboDanhMuc.Text = row.Cells["TenDanhMuc"].Value.ToString();
                txtGiaBan.Text = row.Cells["GiaBan"].Value.ToString();
                txtSoLuong.Text = row.Cells["Soluongton"].Value.ToString();
                txtDVT.Text = row.Cells["DonViTinh"].Value.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
            }
        }
    }
}