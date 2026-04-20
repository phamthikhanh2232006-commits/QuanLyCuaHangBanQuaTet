using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace QuanLyCuaHangBanQuaTet
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }
        private void frmThongKe_Load(object sender, EventArgs e)
        {
            LoadDataThongKe();
        }
        private void LoadDataThongKe()
        {
            // Tải dữ liệu Thống kê kho Sản Phẩm: Tính Tồn Kho = Nhập - Bán
            string q = "SELECT MaSanpham AS [Mã SP], TenSanpham AS [Tên Sản Phẩm], TenDanhMuc AS [Danh Mục], GiaBan AS [Giá Bán], " +
                       "(Soluongton + TongDaBan) AS [Tổng SP Đã Nhập], TongDaBan AS [Tổng SP Đã Bán], " +
                       "Soluongton AS [Tồn Kho Thực Tế Lấy Từ Kho] " +
                       "FROM vw_ThongKeSanPham";
            DataTable dtSP = DatabaseUtils.GetDataTable(q);
            if(dgvThongKeSP != null) dgvThongKeSP.DataSource = dtSP;
            // Tải dữ liệu Lịch sử toàn bộ Hóa Đơn (Phục vụ kế toán quản lý)
            DataTable dtHD = DatabaseUtils.GetDataTable("SELECT * FROM vw_DanhSachHoaDon");
            dgvLichSuHoaDon.DataSource = dtHD;
        }

        private void btnInDoanhThu_Click(object sender, EventArgs e)
        {
            // Bỏ cái tham số WHERE và SqlParameter rườm rà đi là hết lỗi
            string query = @"SELECT MaDonhang, NgayDatHang, PhuongThucThanhToan, SoDienThoai, Tongtien FROM vw_DanhSachHoaDon";

            DataTable dt = DatabaseUtils.GetDataTable(query); // Lấy trụi lủi hết sạch luôn
            rptDoanhThu rpt = new rptDoanhThu();
            rpt.SetDataSource(dt);
            frmInHoaDon viewerForm = new frmInHoaDon();
            viewerForm.crystalReportViewer1.ReportSource = rpt;
            viewerForm.ShowDialog();
        }

        private void btnInTonKho_Click(object sender, EventArgs e)
        {
            string query = @"SELECT MaSanpham, TenSanpham, TenDanhMuc, (Soluongton + TongDaBan) AS TongDaNhap, TongDaBan, Soluongton AS TonKhoThucTe 
                     FROM vw_ThongKeSanPham";

            DataTable dt = DatabaseUtils.GetDataTable(query);

            rptTonKho rpt = new rptTonKho();
            rpt.SetDataSource(dt);

            frmInHoaDon viewerForm = new frmInHoaDon();
            viewerForm.crystalReportViewer1.ReportSource = rpt;
            viewerForm.ShowDialog();
        }

        private void dgvLichSuHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnInTonKho_Click_1(object sender, EventArgs e)
        {
            string query = @"SELECT MaSanpham, TenSanpham, TenDanhMuc, (Soluongton + TongDaBan) AS TongDaNhap, TongDaBan, Soluongton AS TonKhoThucTe 
             FROM vw_ThongKeSanPham";

            DataTable dt = DatabaseUtils.GetDataTable(query);

            rptTonKho rpt = new rptTonKho();
            rpt.SetDataSource(dt);

            frmInHoaDon viewerForm = new frmInHoaDon();
            viewerForm.crystalReportViewer1.ReportSource = rpt;
            viewerForm.ShowDialog();

        }
    }
}
