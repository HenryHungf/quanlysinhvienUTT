-- Tạo Database
CREATE DATABASE CS_QuanLySinhVien;
GO
USE CS_QuanLySinhVien12;
GO

-- Bảng Users
CREATE TABLE users (
    username NVARCHAR(50) PRIMARY KEY,
    password NVARCHAR(100) NOT NULL
);

-- Bảng Khoa
CREATE TABLE Khoa (
    MaKhoa NVARCHAR(10) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL
);

-- Bảng Ngành
CREATE TABLE Nganh (
    MaNganh NVARCHAR(50) PRIMARY KEY,
    TenNganh NVARCHAR(100) NOT NULL
);

-- Bảng Lớp
CREATE TABLE Lop (
    MaLop NVARCHAR(50) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL,
    MaNganh NVARCHAR(50) NOT NULL,
    FOREIGN KEY (MaNganh) REFERENCES Nganh(MaNganh)
);

-- Bảng Khóa năm học
CREATE TABLE KhoaNamHoc (
    MaKhoaHoc NVARCHAR(10) PRIMARY KEY,
    NamBatDau INT NOT NULL,
    NamKetThuc INT NOT NULL
);

-- Bảng Sinh viên
CREATE TABLE SinhVien (
    MaSV NVARCHAR(50) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    DiaChi NVARCHAR(200),
    GioiTinh NVARCHAR(10) CHECK (GioiTinh IN ('Nam', 'Nữ')),
    DienThoai NVARCHAR(15),
    MaLop NVARCHAR(50) NOT NULL,
    MaKhoaHoc NVARCHAR(10),
    FOREIGN KEY (MaLop) REFERENCES Lop(MaLop),
    FOREIGN KEY (MaKhoaHoc) REFERENCES KhoaNamHoc(MaKhoaHoc)
);

-- Bảng Môn học
CREATE TABLE MonHoc (
    MaMon NVARCHAR(50) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    SoTinChi INT NOT NULL,
    MaNganh NVARCHAR(50),
    FOREIGN KEY (MaNganh) REFERENCES Nganh(MaNganh)
);

-- Bảng Điểm
CREATE TABLE Diem (
    MaSV NVARCHAR(50),
    MaMon NVARCHAR(50),
    Diem FLOAT CHECK (Diem BETWEEN 0 AND 10),
    PRIMARY KEY (MaSV, MaMon),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon)
);

-- Bảng Học lại
CREATE TABLE HocLai (
    MaSV NVARCHAR(50),
    MaMon NVARCHAR(50),
    PRIMARY KEY (MaSV, MaMon),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon)
);

-- Bảng Thi lại
CREATE TABLE ThiLai (
    MaSV NVARCHAR(50),
    MaMon NVARCHAR(50),
    PRIMARY KEY (MaSV, MaMon),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon)
);

-- Bảng Khen thưởng
CREATE TABLE KhenThuong (
    MaSV NVARCHAR(50) PRIMARY KEY,
    LyDo NVARCHAR(200),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV)
);

-- Bảng Kỷ luật
CREATE TABLE KyLuat (
    MaSV NVARCHAR(50),
    LyDo NVARCHAR(255) NOT NULL,
    HinhThuc NVARCHAR(100) NOT NULL,
    NgayKyLuat DATE NOT NULL,
    PRIMARY KEY (MaSV, NgayKyLuat),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV)
);

-- Bảng Bảo lưu
CREATE TABLE BaoLuu (
    MaSV NVARCHAR(50) PRIMARY KEY,
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV)
);

-- Bảng Đăng ký lớp
CREATE TABLE DangKyLop (
    MaSV NVARCHAR(50) PRIMARY KEY,
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV)
);

-- Bảng Học bổng
CREATE TABLE HocBong (
    MaSV NVARCHAR(50),
    TenHocBong NVARCHAR(100) NOT NULL,
    GiaTri DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (MaSV, TenHocBong),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV)
);

-- ------------------------------
-- Dữ liệu mẫu: 5 bản ghi mỗi bảng
-- ------------------------------

INSERT INTO Khoa VALUES
('CNTT', N'Công Nghệ Thông Tin'),
('QTKD', N'Quản Trị Kinh Doanh'),
('KT', N'Kế Toán'),
('MARK', N'Marketing'),
('NN', N'Ngôn Ngữ Anh');

INSERT INTO Nganh VALUES
('CNTT', N'Công Nghệ Thông Tin'),
('QTKD', N'Quản Trị Kinh Doanh'),
('KT', N'Kế Toán'),
('MARK', N'Marketing'),
('NN', N'Ngôn Ngữ Anh');

INSERT INTO Lop VALUES
('CNTT1', N'Công Nghệ Thông Tin 1', 'CNTT'),
('QTKD1', N'Quản Trị Kinh Doanh 1', 'QTKD'),
('KT1', N'Kế Toán 1', 'KT'),
('MARK1', N'Marketing 1', 'MARK'),
('NN1', N'Ngôn Ngữ Anh 1', 'NN');

INSERT INTO KhoaNamHoc VALUES
('K2021', 2021, 2025),
('K2022', 2022, 2026),
('K2023', 2023, 2027),
('K2024', 2024, 2028),
('K2025', 2025, 2029);

INSERT INTO SinhVien VALUES
('SV001', N'Nguyễn Văn A', '2000-05-10', N'Hà Nội', 'Nam', '0123456789', 'CNTT1', 'K2021'),
('SV002', N'Trần Thị B', '2001-06-15', N'Hồ Chí Minh', 'Nữ', '0987654321', 'QTKD1', 'K2022'),
('SV003', N'Lê Văn C', '2002-07-20', N'Đà Nẵng', 'Nam', '0345678901', 'KT1', 'K2023'),
('SV004', N'Phạm Thị D', '2001-09-12', N'Hải Phòng', 'Nữ', '0771234567', 'MARK1', 'K2024'),
('SV005', N'Hoàng Văn E', '2000-11-03', N'Bình Dương', 'Nam', '0937654321', 'NN1', 'K2021');

INSERT INTO MonHoc VALUES
('MH001', N'Lập trình C#', 3, 'CNTT'),
('MH002', N'Quản trị doanh nghiệp', 4, 'QTKD'),
('MH003', N'Kế toán tài chính', 3, 'KT'),
('MH004', N'Marketing căn bản', 3, 'MARK'),
('MH005', N'Ngữ pháp tiếng Anh', 3, 'NN');

INSERT INTO Diem VALUES
('SV001', 'MH001', 8.5),
('SV002', 'MH002', 7.2),
('SV003', 'MH003', 6.8),
('SV004', 'MH004', 8.0),
('SV005', 'MH005', 9.0);

INSERT INTO HocLai VALUES
('SV003', 'MH001'),
('SV002', 'MH003'),
('SV004', 'MH005'),
('SV005', 'MH004'),
('SV001', 'MH003');

INSERT INTO ThiLai VALUES
('SV003', 'MH001'),
('SV002', 'MH003'),
('SV004', 'MH005'),
('SV005', 'MH004'),
('SV001', 'MH003');

INSERT INTO KhenThuong VALUES
('SV001', N'Thành tích học tập xuất sắc'),
('SV002', N'Hoạt động ngoại khóa xuất sắc'),
('SV003', N'Tiến bộ vượt bậc trong học tập'),
('SV004', N'Thành tích nghiên cứu khoa học'),
('SV005', N'Đóng góp xây dựng câu lạc bộ');

INSERT INTO KyLuat VALUES
('SV001', N'Vi phạm nội quy', N'Cảnh cáo', '2024-03-15'),
('SV002', N'Nghỉ học không phép', N'Khiển trách', '2024-04-01'),
('SV003', N'Trốn học nhiều buổi', N'Cảnh cáo', '2024-05-10'),
('SV004', N'Trễ hạn học phí', N'Phạt tiền', '2024-06-01'),
('SV005', N'Thiếu điểm chuyên cần', N'Nhắc nhở', '2024-06-20');

INSERT INTO BaoLuu VALUES
('SV002'),
('SV003'),
('SV004'),
('SV005'),
('SV001');

INSERT INTO DangKyLop VALUES
('SV001'),
('SV002'),
('SV003'),
('SV004'),
('SV005');

INSERT INTO HocBong VALUES
('SV001', N'Học Bổng Xuất Sắc', 5000000),
('SV002', N'Học Bổng Giỏi', 3000000),
('SV003', N'Học Bổng Khuyến Khích', 2000000),
('SV004', N'Học Bổng Cống Hiến', 2500000),
('SV005', N'Học Bổng Tiếng Anh', 4000000);

ALTER TABLE SinhVien DROP CONSTRAINT CK__SinhVien__GioiTi__4222D4EF;

ALTER TABLE SinhVien
ADD CONSTRAINT CK_SinhVien_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác'));

SELECT DISTINCT GioiTinh
FROM SinhVien
WHERE GioiTinh NOT IN (N'Nam', N'Nữ', N'Khác');

ALTER TABLE SinhVien
ADD CONSTRAINT CK_SinhVien_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác'));

UPDATE SinhVien
SET GioiTinh = N'Khác'
WHERE GioiTinh = N'N?';

ALTER TABLE SinhVien
ADD CONSTRAINT CK_SinhVien_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác'));
