-- T?o Database
CREATE DATABASE CS_QuanLySinhVien;
GO
USE CS_QuanLySinhVien;
GO

-- B?ng Ngành
CREATE TABLE Nganh (
    MaNganh NVARCHAR(50) PRIMARY KEY,
    TenNganh NVARCHAR(100) NOT NULL
);

-- B?ng L?p
CREATE TABLE Lop (
    MaLop NVARCHAR(50) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL,
    MaNganh NVARCHAR(50) NOT NULL,
    FOREIGN KEY (MaNganh) REFERENCES Nganh(MaNganh)
);

-- B?ng Sinh viên
CREATE TABLE SinhVien (
    MaSV NVARCHAR(50) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    DiaChi NVARCHAR(200),
    GioiTinh NVARCHAR(10) CHECK (GioiTinh IN ('Nam', 'N?')),
    DienThoai NVARCHAR(15),
    MaLop NVARCHAR(50) NOT NULL,
    FOREIGN KEY (MaLop) REFERENCES Lop(MaLop)
);

-- B?ng B?o lýu
CREATE TABLE BaoLuu (
    MaSV NVARCHAR(50) PRIMARY KEY,
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV)
);

-- B?ng Ðãng k? l?p
CREATE TABLE DangKyLop (
    MaSV NVARCHAR(50) PRIMARY KEY,
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV)
);

-- B?ng Môn h?c
CREATE TABLE MonHoc (
    MaMon NVARCHAR(50) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    SoTinChi INT NOT NULL
);

-- B?ng Ði?m
CREATE TABLE Diem (
    MaSV NVARCHAR(50),
    MaMon NVARCHAR(50),
    Diem FLOAT CHECK (Diem BETWEEN 0 AND 10),
    PRIMARY KEY (MaSV, MaMon),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon)
);

-- B?ng H?c l?i
CREATE TABLE HocLai (
    MaSV NVARCHAR(50),
    MaMon NVARCHAR(50),
    PRIMARY KEY (MaSV, MaMon),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon)
);

-- B?ng Khen thý?ng
CREATE TABLE KhenThuong (
    MaSV NVARCHAR(50) PRIMARY KEY,
    LyDo NVARCHAR(200),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV)
);

-- B?ng Thi l?i
CREATE TABLE ThiLai (
    MaSV NVARCHAR(50),
    MaMon NVARCHAR(50),
    PRIMARY KEY (MaSV, MaMon),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon)
);
-- Bảng Khoa
CREATE TABLE Khoa (
    MaKhoa NVARCHAR(10) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL
);

-- Bảng HocBong
CREATE TABLE HocBong (
    MaSV NVARCHAR(50),
    TenHocBong NVARCHAR(100) NOT NULL,
    GiaTri DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (MaSV, TenHocBong),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV)
);

-- Bảng KyLuat
CREATE TABLE KyLuat (
    MaSV NVARCHAR(50),
    LyDo NVARCHAR(255) NOT NULL,
    HinhThuc NVARCHAR(100) NOT NULL,
    NgayKyLuat DATE NOT NULL,
    PRIMARY KEY (MaSV, NgayKyLuat),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV)
);

-- Bảng KhoaNamHoc
CREATE TABLE KhoaNamHoc (
    MaKhoaHoc NVARCHAR(10) PRIMARY KEY,
    NamBatDau INT NOT NULL,
    NamKetThuc INT NOT NULL
);

ALTER TABLE MonHoc ADD MaNganh NVARCHAR(50);
ALTER TABLE MonHoc
ADD CONSTRAINT FK_MonHoc_Nganh FOREIGN KEY (MaNganh) REFERENCES Nganh(MaNganh);

ALTER TABLE SinhVien
ADD MaKhoaHoc NVARCHAR(10);

ALTER TABLE SinhVien
ADD CONSTRAINT FK_SinhVien_KhoaNamHoc FOREIGN KEY (MaKhoaHoc) REFERENCES KhoaNamHoc(MaKhoaHoc);

INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES
('CNTT', N'Công Nghệ Thông Tin'),
('QTKD', N'Quản Trị Kinh Doanh'),
('KT', N'Kế Toán');

INSERT INTO HocBong (MaSV, TenHocBong, GiaTri) VALUES
('SV001', N'Học Bổng Xuất Sắc', 5000000),
('SV002', N'Học Bổng Giỏi', 3000000),
('SV003', N'Học Bổng Khuyến Khích', 2000000);

INSERT INTO KyLuat (MaSV, LyDo, HinhThuc, NgayKyLuat) VALUES
('SV001', N'Vi phạm nội quy', N'Cảnh cáo', '2024-03-15'),
('SV002', N'Nghỉ học không phép', N'Khiển trách', '2024-04-01'),
('SV003', N'Trốn học nhiều buổi', N'Cảnh cáo', '2024-05-10');

INSERT INTO KhoaNamHoc (MaKhoaHoc, NamBatDau, NamKetThuc) VALUES
('K2021', 2021, 2025),
('K2022', 2022, 2026),
('K2023', 2023, 2027);


--Thêm--
INSERT INTO Nganh VALUES
('CNTT', 'Công ngh? thông tin'),
('QTKD', 'Qu?n tr? kinh doanh'),
('KT', 'K? toán');

INSERT INTO Lop VALUES
('CNTT1', 'Công ngh? thông tin 1', 'CNTT'),
('QTKD1', 'Qu?n tr? kinh doanh 1', 'QTKD'),
('KT1', 'K? toán 1', 'KT');

INSERT INTO SinhVien VALUES
('SV001', 'Nguy?n Vãn A', '2000-05-10', 'Hà N?i', 'Nam', '0123456789', 'CNTT1'),
('SV002', 'Tr?n Th? B', '2001-06-15', 'H? Chí Minh', 'N?', '0987654321', 'QTKD1'),
('SV003', 'Lê Vãn C', '2002-07-20', 'Ðà N?ng', 'Nam', '0345678901', 'KT1');

INSERT INTO BaoLuu VALUES
('SV002'),
('SV003')

INSERT INTO DangKyLop VALUES
('SV001'),
('SV002'),
('SV003');

INSERT INTO MonHoc VALUES
('MH001', 'L?p tr?nh C#', 3),
('MH002', 'Qu?n tr? doanh nghi?p', 4),
('MH003', 'K? toán tài chính', 3);

INSERT INTO Diem VALUES
('SV001', 'MH001', 8.5),
('SV002', 'MH002', 7.2),
('SV003', 'MH003', 6.8);

INSERT INTO HocLai VALUES
('SV003', 'MH001'),
('SV002', 'MH003');

INSERT INTO KhenThuong VALUES
('SV001', 'Thành tích h?c t?p xu?t s?c'),
('SV002', 'Ho?t ð?ng ngo?i khóa xu?t s?c');

INSERT INTO ThiLai VALUES
('SV003', 'MH001'),
('SV002', 'MH003');

SELECT name 
FROM sys.check_constraints 
WHERE parent_object_id = OBJECT_ID('SinhVien') 
AND parent_column_id = (SELECT column_id FROM sys.columns WHERE object_id = OBJECT_ID('SinhVien') AND name = 'GioiTinh');

ALTER TABLE SinhVien DROP CONSTRAINT CK__SinhVien__GioiTi__3C69FB99;