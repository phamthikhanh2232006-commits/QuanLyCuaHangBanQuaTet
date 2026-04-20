USE master;
GO
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'DB_QuanLyQuaTet')
BEGIN
    ALTER DATABASE DB_QuanLyQuaTet SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE DB_QuanLyQuaTet;
END
GO
CREATE DATABASE DB_QuanLyQuaTet;
GO
USE DB_QuanLyQuaTet;
GO
-- 1. Table: tblDanhMuc (Categories)
CREATE TABLE tblDanhMuc (
    MaDanhMuc NVARCHAR(10) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL
);
GO
-- 2. Table: tblSanpham (Products)
CREATE TABLE tblSanpham (
    MaSanpham NVARCHAR(10) PRIMARY KEY,
    TenSanpham NVARCHAR(200) NOT NULL,
    MaDanhMuc NVARCHAR(10) FOREIGN KEY REFERENCES tblDanhMuc(MaDanhMuc),
    GiaBan DECIMAL(18, 2) NOT NULL,
    Soluongton INT NOT NULL,
    DonViTinh NVARCHAR(50),
    MoTa NVARCHAR(1000),
    NgayHetHan DATETIME
);
GO
-- 3. Table: tblKhachhang (Customers) - ĐÃ CẬP NHẬT SDT LÀM KHÓA CHÍNH, HOTEN ĐƯỢC PHÉP RỖNG
CREATE TABLE tblKhachhang (
    SoDienThoai VARCHAR(20) PRIMARY KEY,   -- Khóa chính theo yêu cầu
    MatKhau VARCHAR(100) DEFAULT '123456', -- Phục vụ Đăng nhập bằng khách hàng
    HoTen NVARCHAR(100) NULL,              -- Không cần tên trừ khi được yêu cầu
    Email VARCHAR(100) NULL,
    DiaChi NVARCHAR(200) NULL,             -- Không cần địa chỉ trừ khi được yêu cầu
    DiemTichLuy INT DEFAULT 0,             -- Thẻ tích điểm
    NgayDangky DATETIME DEFAULT GETDATE()
);
GO
-- 4. Table: tblChucvu (Positions)
CREATE TABLE tblChucvu (
    MaChucvu NVARCHAR(10) PRIMARY KEY,
    TenChucvu NVARCHAR(50) NOT NULL,
    MoTa NVARCHAR(200)
);
GO
-- 5. Table: tblNhanvien (Employees)
CREATE TABLE tblNhanvien (
    MaNhanvien NVARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE CHECK (DATEDIFF(YEAR, NgaySinh, GETDATE()) >= 18 AND DATEDIFF(YEAR, NgaySinh, GETDATE()) <= 60),
    Gioitinh NVARCHAR(10) CHECK (Gioitinh IN (N'Nam', N'Nữ')),
    Diachi NVARCHAR(200),
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100),
    CCCD VARCHAR(12),
    MaChucvu NVARCHAR(10) FOREIGN KEY REFERENCES tblChucvu(MaChucvu),
    NgayVaoLam DATE DEFAULT GETDATE() CHECK (NgayVaoLam <= GETDATE()),
    Luong DECIMAL(18, 2) CHECK (Luong >= 0 AND Luong <= 100000000),
    GhiChu NVARCHAR(500)
);
GO
-- 6. Table: tblUser (Tài khoản nhân viên)
CREATE TABLE tblUser (
    Username VARCHAR(50) PRIMARY KEY,
    Password VARCHAR(100) NOT NULL,
    MaNhanvien NVARCHAR(10) FOREIGN KEY REFERENCES tblNhanvien(MaNhanvien),
    Quyen NVARCHAR(50) DEFAULT 'User'
);
GO
-- 7. Table: tblDonhang (Orders)
CREATE TABLE tblDonhang (
    MaDonhang NVARCHAR(50) PRIMARY KEY,
    SoDienThoai VARCHAR(20) FOREIGN KEY REFERENCES tblKhachhang(SoDienThoai), -- Khóa ngoại trỏ đến SDT
    NgayDatHang DATETIME DEFAULT GETDATE(),
    DiaChiGiaoHang NVARCHAR(200),
    Tongtien DECIMAL(18, 2),
    Trangthai NVARCHAR(50) DEFAULT N'Đang xử lý',
    PhuongThucThanhToan NVARCHAR(50),
    MaGiamGia NVARCHAR(50) NULL -- Thêm vùng lưu Voucher
);
GO
-- 8. Table: tblChiTietDonHang (Chuẩn hóa Khóa Kép)
CREATE TABLE tblChiTietDonHang (
    MaDonhang NVARCHAR(50) FOREIGN KEY REFERENCES tblDonhang(MaDonhang),
    MaSanpham NVARCHAR(10) FOREIGN KEY REFERENCES tblSanpham(MaSanpham),
    MaNhanvien NVARCHAR(10) FOREIGN KEY REFERENCES tblNhanvien(MaNhanvien),
    Soluong INT NOT NULL,
    DonGia DECIMAL(18, 2) NOT NULL,
    GiamGia DECIMAL(18, 2) DEFAULT 0,
    PRIMARY KEY (MaDonhang, MaSanpham) -- KHÓA CHÍNH KÉP TỪ 2 BẢNG
);
GO
-- TRIGGER TỰ ĐỘNG TRỪ TỒN KHO SAU KHI THANH TOÁN (Yêu cầu GV)
CREATE TRIGGER trg_TruTonKho
ON tblChiTietDonHang
AFTER INSERT
AS
BEGIN
    -- Cập nhật trừ đi số lượng kho từ số lượng đã bán
    UPDATE sp
    SET sp.Soluongton = sp.Soluongton - i.Soluong
    FROM tblSanpham sp
    JOIN inserted i ON sp.MaSanpham = i.MaSanpham;
    
    -- (Tùy chọn) Cộng điểm tích lũy cho khách hàng (Ví dụ: Giao dịch 10k được 1 điểm)
    UPDATE kh
    SET kh.DiemTichLuy = kh.DiemTichLuy + CAST((i.Soluong * i.DonGia)/10000 AS INT)
    FROM tblKhachhang kh
    JOIN tblDonhang dh ON kh.SoDienThoai = dh.SoDienThoai
    JOIN inserted i ON dh.MaDonhang = i.MaDonhang;
END;
GO
-- 9. Table: tblNhaCungCap (Suppliers)
CREATE TABLE tblNhaCungCap (
    MaNhaCungCap NVARCHAR(10) PRIMARY KEY,
    TenNhaCungCap NVARCHAR(200) NOT NULL,
    Nguoilienhe NVARCHAR(100),
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100),
    Diachi NVARCHAR(200)
);
GO
-- 10. Table: tblDonNhapHang (Import Orders)
CREATE TABLE tblDonNhapHang (
    MaDonNhap NVARCHAR(10) PRIMARY KEY,
    MaNhaCungCap NVARCHAR(10) FOREIGN KEY REFERENCES tblNhaCungCap(MaNhaCungCap),
    NgayNhap DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18, 2),
    GhiChu NVARCHAR(500),
    TrangThai NVARCHAR(50) DEFAULT N'Đang xử lý'
);
GO
-- 11. Table: tblChitietNhapHang (Import Details - Khóa kép)
CREATE TABLE tblChitietNhapHang (
    MaDonNhap NVARCHAR(10) FOREIGN KEY REFERENCES tblDonNhapHang(MaDonNhap),
    MaSanpham NVARCHAR(10) FOREIGN KEY REFERENCES tblSanpham(MaSanpham),
    MaNhanvien NVARCHAR(10) FOREIGN KEY REFERENCES tblNhanvien(MaNhanvien),
    SoluongNhap INT NOT NULL,
    DonGiaNhap DECIMAL(18, 2) NOT NULL,
    GhiChu NVARCHAR(200),
    PRIMARY KEY (MaDonNhap, MaSanpham)
);
GO
-- TRIGGER TỰ ĐỘNG CỘNG TỒN KHO SAU KHI NHẬP HÀNG
CREATE TRIGGER trg_CongTonKho
ON tblChitietNhapHang
AFTER INSERT
AS
BEGIN
    UPDATE sp
    SET sp.Soluongton = sp.Soluongton + i.SoluongNhap
    FROM tblSanpham sp
    JOIN inserted i ON sp.MaSanpham = i.MaSanpham;
END;
GO
-- ===========================================
-- VIEWS CUNG CẤP DỮ LIỆU
-- ===========================================
-- Danh sách Hóa đơn theo mô hình Thống Kê
CREATE VIEW vw_DanhSachHoaDon AS
SELECT 
    DH.MaDonhang, 
    DH.NgayDatHang, 
    DH.Tongtien, 
    DH.Trangthai, 
    DH.PhuongThucThanhToan,
    KH.SoDienThoai, 
    KH.HoTen AS TenKhachHang, 
    KH.DiemTichLuy
FROM tblDonhang DH
JOIN tblKhachhang KH ON DH.SoDienThoai = KH.SoDienThoai;
GO
-- Danh sách Chi tiết Giao dịch (Chi tiết 1 Hóa Đơn)
CREATE VIEW vw_HoaDonChiTiet AS
SELECT 
    DH.MaDonhang, KH.HoTen AS TenKhachHang, KH.SoDienThoai, KH.DiaChi AS DiaChiGiaoHang,
    DH.NgayDatHang, NV.HoTen AS TenNhanVien,
    SP.TenSanpham, CT.Soluong, CT.DonGia, CT.GiamGia, DH.MaGiamGia,
    (CT.Soluong * CT.DonGia - CT.GiamGia) AS ThanhTien
FROM tblDonhang DH
JOIN tblKhachhang KH ON DH.SoDienThoai = KH.SoDienThoai
JOIN tblChiTietDonHang CT ON DH.MaDonhang = CT.MaDonhang
JOIN tblSanpham SP ON CT.MaSanpham = SP.MaSanpham
JOIN tblNhanvien NV ON CT.MaNhanvien = NV.MaNhanvien;
GO
-- Danh sách tồn kho (Thống Kê Sản Phẩm) thõa yêu cầu bổ sung
CREATE VIEW vw_ThongKeSanPham AS
SELECT 
    SP.MaSanpham,
    SP.TenSanpham,
    DM.TenDanhMuc,
    SP.GiaBan,
    SP.Soluongton,
    ISNULL((SELECT SUM(CT.Soluong) FROM tblChiTietDonHang CT WHERE CT.MaSanpham = SP.MaSanpham), 0) AS TongDaBan,
    ISNULL((SELECT SUM(CN.SoluongNhap) FROM tblChitietNhapHang CN WHERE CN.MaSanpham = SP.MaSanpham), 0) AS TongDaNhap
FROM tblSanpham SP
JOIN tblDanhMuc DM ON SP.MaDanhMuc = DM.MaDanhMuc;
GO
-- Danh sách Đơn nhập hàng (Phục vụ Quản lý Nhập Hàng)
CREATE VIEW vw_DanhSachDonNhapHang AS
SELECT 
    DN.MaDonNhap, 
    NCC.TenNhaCungCap, 
    DN.NgayNhap, 
    DN.TongTien, 
    DN.TrangThai, 
    DN.GhiChu
FROM tblDonNhapHang DN
JOIN tblNhaCungCap NCC ON DN.MaNhaCungCap = NCC.MaNhaCungCap;
GO
-----------------------------------------------------------
-- DỮ LIỆU MẪU CHO CÁC BẢNG (INSERT DUMMY DATA)
-----------------------------------------------------------
-- 1. Thêm Chức vụ & Nhân viên & Tài khoản
INSERT INTO tblChucvu (MaChucvu, TenChucvu, MoTa) VALUES 
('CV01', N'Quản lý', N'Quản lý toàn bộ chi nhánh'), 
('CV02', N'Bán hàng', N'Thu ngân POS'),
('CV03', N'Kế toán', N'Kiểm toán và xuất nhập kho');
INSERT INTO tblNhanvien (MaNhanvien, HoTen, NgaySinh, Gioitinh, Diachi, SoDienThoai, Email, CCCD, MaChucvu, NgayVaoLam, Luong, GhiChu) VALUES 
('NV01', N'Trần Văn Sếp', '1985-05-15', N'Nam', N'Hà Nội', '0901234567', 'sep@gmail.com', '001085123456', 'CV01', '2020-01-01', 25000000, N'Quản lý chung'),
('NV02', N'Nguyễn Thị Thu', '1995-10-20', N'Nữ', N'Hà Đông', '0912345678', 'thu@gmail.com', '001095112233', 'CV02', '2021-05-15', 8500000, N'Nhân viên xuất sắc'),
('NV03', N'Lê Hoàng Tùng', '1998-02-14', N'Nam', N'Cầu Giấy', '0988776655', 'tung@gmail.com', '001098445566', 'CV02', '2023-02-14', 7500000, N''),
('NV04', N'Phạm Bích Ngọc', '1992-07-30', N'Nữ', N'Bắc Từ Liêm', '0933221144', 'ngoc@gmail.com', '001092778899', 'CV03', '2022-08-01', 12000000, N'Phụ trách sổ sách');
INSERT INTO tblUser (Username, Password, MaNhanvien, Quyen) VALUES 
('admin', '123456', 'NV01', 'Admin'), 
('nhanvien', '123456', 'NV02', 'Nhanvien'),
('ketoan', '123456', 'NV04', 'Ketoan');
-- 2. Danh mục & Sản phẩm
INSERT INTO tblDanhMuc (MaDanhMuc, TenDanhMuc) VALUES 
('DM01', N'Giỏ quà Tết Cao Cấp'), 
('DM02', N'Rượu Ngoại Nhập'),
('DM03', N'Bánh Mứt Truyền Thống'),
('DM04', N'Trà và Cà Phê'),
('DM05', N'Đặc sản Vùng Miền');
INSERT INTO tblSanpham (MaSanpham, TenSanpham, MaDanhMuc, GiaBan, Soluongton, DonViTinh) VALUES 
('SP01', N'Giỏ Quà An Khang Thịnh Vượng (12 Món)', 'DM01', 1250000, 50, N'Giỏ'),
('SP02', N'Giỏ Quà Như Ý Cát Tường', 'DM01', 850000, 100, N'Giỏ'),
('SP03', N'Rượu vang Chivas Regal 12', 'DM02', 1200000, 30, N'Chai'),
('SP04', N'Rượu vang Chile Chateau', 'DM02', 450000, 80, N'Chai'),
('SP05', N'Mứt Gừng Sấy Mật Ong Huế', 'DM03', 120000, 150, N'Hộp'),
('SP06', N'Mứt Sen Trần Truyền Thống', 'DM03', 150000, 120, N'Hộp'),
('SP07', N'Hạt Dẻ Cười Nhập Khẩu Mỹ', 'DM03', 350000, 200, N'Kg'),
('SP08', N'Trà Shan Tuyết Cổ Thụ', 'DM04', 420000, 50, N'Hộp'),
('SP09', N'Thịt Trâu Gác Bếp Tây Bắc', 'DM05', 850000, 40, N'Kg'),
('SP10', N'Lạp xưởng Mai Quế Lộ', 'DM05', 250000, 90, N'Kg');
-- 3. Khách hàng theo Khóa SDT mới
INSERT INTO tblKhachhang (SoDienThoai, MatKhau, HoTen, Email, DiaChi, DiemTichLuy) VALUES 
('0911223344', '123456', N'Phạm Văn A', 'kh01@gmail.com', N'22 Thanh Xuân, HN', 50),
('0944556677', '123456', NULL, NULL, NULL, 5), -- Khách ngoại lai không cần tên
('0977889900', '123456', N'Trần Thị Bích Khuê', 'khue@gmail.com', N'45 Hai Bà Trưng, HN', 210),
('0988112233', '123456', N'Ban Công Đoàn Cty IT', 'congdoan@it.com', N'Tòa nhà Keangnam', 1500),
('0922334455', '123456', N'Lê Minh Tuấn', 'tuan@outlook.com', N'Đống Đa, HN', 0);
-- 4. Nhà cung cấp & Nhập Hàng
INSERT INTO tblNhaCungCap (MaNhaCungCap, TenNhaCungCap, Nguoilienhe, SoDienThoai, Email, Diachi) VALUES 
('NCC01', N'Công ty Bánh Kẹo Hải Hà', N'Anh Hải', '0243123456', 'contact@haiha.vn', N'KCN Phố Nối, Hưng Yên'),
('NCC02', N'Đại lý Phân Phối Rượu Vang', N'Chị Mai', '0912111222', 'mai.vang@nhapkhau.com', N'Quận 1, TP. HCM'),
('NCC03', N'Hợp tác xã Nông Sản Tây Bắc', N'Bác Cường', '0977444333', 'nongsan@taybac.vn', N'Mộc Châu, Sơn La');
INSERT INTO tblDonNhapHang (MaDonNhap, MaNhaCungCap, TongTien) VALUES 
('DN01', 'NCC01', 15000000),
('DN02', 'NCC02', 45000000);
-- Nhập hàng sẽ kích hoạt Trigger tự cộng kho
INSERT INTO tblChitietNhapHang (MaDonNhap, MaSanpham, MaNhanvien, SoluongNhap, DonGiaNhap) VALUES 
('DN01', 'SP05', 'NV04', 100, 80000),
('DN01', 'SP06', 'NV04', 100, 100000),
('DN02', 'SP03', 'NV04', 50, 900000),
('DN02', 'SP04', 'NV04', 100, 300000);
-- 5. Lịch sử Hóa Đơn Bán Hàng (Thống Kê)
INSERT INTO tblDonhang (MaDonhang, SoDienThoai, Tongtien, Trangthai, PhuongThucThanhToan) VALUES 
('HD20240101001', '0911223344', 3350000, N'Đã thanh toán', N'Chuyển khoản'),
('HD20240105002', '0988112233', 12500000, N'Đã thanh toán', N'Công nợ'),
('HD20240110003', '0944556677', 350000, N'Đã thanh toán', N'Tiền mặt'),
('HD20240115004', '0977889900', 850000, N'Đang giao', N'COD');
-- Thêm chi tiết hóa đơn (Kích hoạt Trigger trừ kho)
INSERT INTO tblChiTietDonHang (MaDonhang, MaSanpham, MaNhanvien, Soluong, DonGia, GiamGia) VALUES 
('HD20240101001', 'SP01', 'NV02', 1, 1250000, 0),
('HD20240101001', 'SP03', 'NV02', 1, 1200000, 0),
('HD20240101001', 'SP09', 'NV02', 1, 850000, 0),
('HD20240105002', 'SP01', 'NV03', 10, 1250000, 500000), -- Mua số lượng lớn giảm 500k toàn bill
('HD20240110003', 'SP07', 'NV02', 1, 350000, 0),
('HD20240115004', 'SP02', 'NV03', 1, 850000, 0);
GO
-- ===========================================
-- LIÊN KẾT: THÊM HÓA ĐƠN GIAO DỊCH VÀ XỬ LÝ LÔ GIC TỰ ĐỘNG
-- ===========================================
CREATE PROCEDURE sp_ThemHoaDon
    @MaHoaDon NVARCHAR(50),
    @SoDienThoai NVARCHAR(20),     -- Đã thay bằng SDT
    @TenKhachHang NVARCHAR(100),   -- Thu thập nếu có
    @TenNhanVien NVARCHAR(100),
    @DiaChi NVARCHAR(200),         -- Giao hàng (nếu có)
    @MaSanPham NVARCHAR(50),
    @SoLuong INT,
    @DonGia DECIMAL(18, 2),
    @GiamGia DECIMAL(18, 2),
    @MaGiamGia NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    -- B1. Đăng ký tự động nếu KHÁCH VÃNG LAI (Mới hoàn toàn) chưa có SDT trong hệ thống
    IF NOT EXISTS (SELECT 1 FROM tblKhachhang WHERE SoDienThoai = @SoDienThoai)
    BEGIN
        INSERT INTO tblKhachhang (SoDienThoai, HoTen, DiaChi)
        VALUES (@SoDienThoai, @TenKhachHang, @DiaChi);
    END
    ELSE
    BEGIN
        -- Option: Cập nhật tên địa chỉ nếu trước đó họ là khách ẩn danh (NULL)
        IF ISNULL(@TenKhachHang, '') <> '' 
           AND (SELECT HoTen FROM tblKhachhang WHERE SoDienThoai = @SoDienThoai) IS NULL
        BEGIN
            UPDATE tblKhachhang SET HoTen = @TenKhachHang WHERE SoDienThoai = @SoDienThoai;
        END
    END
    
    -- B2. Chèn thông tin Hóa đơn gốc (Mỗi giỏ hàng 1 mã, nếu Hóa đơn đã tồn tại ở Giỏ rồi thì bỏ qua bước tạo cha)
    IF NOT EXISTS (SELECT 1 FROM tblDonhang WHERE MaDonhang = @MaHoaDon)
    BEGIN
        INSERT INTO tblDonhang (MaDonhang, SoDienThoai, NgayDatHang, DiaChiGiaoHang, MaGiamGia)
        VALUES (@MaHoaDon, @SoDienThoai, GETDATE(), @DiaChi, @MaGiamGia);
    END
    
    -- B3. Chèn giỏ hàng SP vào Chi tiết (Bước này sẽ kích hoạt Tự Động Trừ Tồn Kho của Trigger)
    BEGIN TRY
        INSERT INTO tblChiTietDonHang (MaDonhang, MaSanpham, MaNhanvien, Soluong, DonGia, GiamGia)
        VALUES (@MaHoaDon, @MaSanPham, 
               (SELECT TOP 1 MaNhanvien FROM tblNhanvien WHERE HoTen = @TenNhanVien), 
               @SoLuong, @DonGia, @GiamGia);
    END TRY
    BEGIN CATCH
        -- Bắt văng lỗi nếu cùng một Hóa Đơn chọn cùng 1 sản phẩm 2 lần (Khóa Kép)
        -- Trong trường hợp này Hệ thống cập nhật Cộng Dồn số lượng thay vì lỗi!
        UPDATE tblChiTietDonHang
        SET Soluong = Soluong + @SoLuong
        WHERE MaDonhang = @MaHoaDon AND MaSanpham = @MaSanPham;
    END CATCH
END
GO