CREATE DATABASE QL_NHAHANG_2
GO
USE QL_NHAHANG_2
GO
CREATE TABLE KieuNguoiDung
(
	idKieunguoidung INT IDENTITY NOT NULL,
	tenKieunguoidung NVARCHAR(100),
	PRIMARY KEY(idKieunguoidung)
)
GO
CREATE TABLE NguoiDung
(
	idNguoidung INT IDENTITY NOT NULL,
	idKieunguoidung INT NOT NULL,
	idNhanvien INT,
	tenHienthi NVARCHAR(200),
	tenDangnhap NVARCHAR(100),
	matKhau NVARCHAR(100),
	tinhTrang CHAR(10)-- true hoặc false là còn hoạt động hay ko
	PRIMARY KEY(idNguoidung)
)
GO
CREATE TABLE Ban
(
	idBan INT IDENTITY NOT NULL,
	tenBan NVARCHAR(100),
	tinhTrang INT, -- 1 là có khách còn 0 là không có khách
	PRIMARY KEY(idBan)
)
GO
CREATE TABLE DanhMucMon
(
	idDanhmuc INT IDENTITY NOT NULL,
	tenDanhmuc NVARCHAR(100),
	PRIMARY KEY(idDanhmuc)
)
GO
CREATE TABLE Mon
(
	idMon INT IDENTITY NOT NULL,
	tenMon NVARCHAR(200),
	donGia INT,
	idDanhmuc INT,
	tinhTrangMon INT DEFAULT (1),
	PRIMARY KEY(idMon),
)
GO
CREATE TABLE HoaDon
(
	idHoadon INT IDENTITY NOT NULL,
	idBan INT  NOT NULL,
	idNguoidung INT,
	ngayNhap DATETIME DEFAULT GETDATE() NOT NULL,
	ngayXuat DATETIME,
	tinhTrangHoaDon INT NOT NULL,--1 là đã thanh toán 0 là chưa thanh toán
	tongTienHoaDon INT,
	
	PRIMARY KEY(idHoadon)
)
GO
CREATE TABLE ChiTietHoaDon
(
	idChitiethoadon INT IDENTITY NOT NULL,
	idHoadon INT NOT NULL,
	idMon INT NOT NULL,
	soLuong INT,
	PRIMARY KEY(idChitiethoadon)
)
GO
CREATE TABLE ChucVu
(
	idChucvu INT IDENTITY NOT NULL,
	tenChucvu NVARCHAR(100),
	luongCoban FLOAT,
	PRIMARY KEY(idChucvu)
)
GO
CREATE TABLE HeSoLuong
(
	idHesoluong INT IDENTITY NOT NULL,
	heSoluong FLOAT,
	PRIMARY KEY(idHesoluong)
)
GO
CREATE TABLE PhuCap
(
	idPhucap INT IDENTITY NOT NULL,
	tienPhucap FLOAT,
	PRIMARY KEY(idPhucap)
)
GO
CREATE TABLE CaLamViec
(
	idCalam INT IDENTITY NOT NULL,
	tenCalam NVARCHAR(50),
	heSo FLOAT,
	PRIMARY KEY(idCalam)
)
GO
CREATE TABLE ChamCong
(
	idChamcong INT PRIMARY KEY
)
GO
CREATE TABLE ChiTietChamCong 
(
	idChitietchamcong INT IDENTITY NOT NULL,
	idChamcong INT,
	thang INT,
	nam INT,
	soNgaylam INT,
	PRIMARY KEY(idChitietchamcong)
)
CREATE TABLE NhanVien
(
	idNhanvien INT IDENTITY NOT NULL,
	tenNhanvien NVARCHAR(200),
	diaChi NVARCHAR(200),
	gioiTinh NVARCHAR(10),
	ngaySinh DATE,
	soDienthoai NVARCHAR(15),
	idChucvu INT NOT NULL,
	idHesoluong INT,
	idPhucap INT,
	idCalam INT,
	idChamcong INT,
	tinhTrang CHAR(10), -- true or false còn làm hay không
	ghiChu NVARCHAR(MAX),
	PRIMARY KEY(idNHanvien),
)
GO
CREATE TABLE Luong
(
	idLuong INT IDENTITY NOT NULL,
	idNhanvien INT,
	thang INT,
	nam INT,
	luong MONEY,
	ghiChu NVARCHAR(MAX)
	PRIMARY KEY(idLuong)
)
GO
ALTER TABLE dbo.NguoiDung
ADD CONSTRAINT FK_NguoiDung_KieuNguoiDung FOREIGN KEY(idKieunguoidung) REFERENCES dbo.KieuNguoiDung(idKieunguoidung),

CONSTRAINT FK_NguoiDung_NhanVien FOREIGN KEY(idNhanvien) REFERENCES dbo.NhanVien(idNhanvien)
GO
ALTER TABLE dbo.Mon
ADD CONSTRAINT FK_Mon_DanhMucMon FOREIGN KEY(idDanhmuc) REFERENCES dbo.DanhMucMon(idDanhmuc)
GO
ALTER TABLE dbo.HoaDon
ADD CONSTRAINT FK_HoaDon_Ban FOREIGN KEY(idBan) REFERENCES dbo.Ban(idBan),
CONSTRAINT FK_HoaDon_NguoiDung FOREIGN KEY(idNguoidung) REFERENCES dbo.NguoiDung(idNguoidung)
GO
ALTER TABLE dbo.ChiTietHoaDon
ADD CONSTRAINT FK_ChiTietHoaDon_HoaDon FOREIGN KEY(idHoadon) REFERENCES dbo.HoaDon(idHoadon)
GO
ALTER TABLE dbo.ChiTietHoaDon
ADD CONSTRAINT FK_ChiTietHoaDon_Mon FOREIGN KEY(idMon) REFERENCES dbo.Mon(idMon)
GO
ALTER TABLE dbo.NhanVien
ADD CONSTRAINT FK_NhanVien_ChucVu FOREIGN KEY(idChucvu) REFERENCES dbo.ChucVu(idChucvu)
GO
ALTER TABLE dbo.NhanVien
ADD CONSTRAINT FK_NhanVien_PhuCap FOREIGN KEY(idPhucap) REFERENCES dbo.PhuCap(idPhucap)
GO
ALTER TABLE dbo.NhanVien
ADD CONSTRAINT FK_NhanVien_HeSo FOREIGN KEY(idHesoluong) REFERENCES dbo.HeSoLuong(idHesoluong),
FOREIGN KEY(idCalam) REFERENCES dbo.CaLamViec(idCalam),
FOREIGN KEY(idChamcong) REFERENCES dbo.ChamCong(idChamcong)
GO
ALTER TABLE dbo.Luong
ADD CONSTRAINT FK_NV_LUONG FOREIGN KEY(idNhanvien) REFERENCES dbo.NhanVien(idNhanvien)
GO
ALTER TABLE dbo.ChiTietChamCong
ADD FOREIGN KEY(idChamcong) REFERENCES dbo.ChamCong(idChamcong)

--Thêm dữ liệu vào chức vụ
SET DATEFORMAT DMY
INSERT INTO dbo.ChucVu
        ( tenChucvu, luongCoban )
VALUES  ( N'Quản lí', -- tenChucvu - nvarchar(100)
          4500000  -- luongCoban - float
          ),
		  (N'Thu ngân',4000000),
		  (N'Order',3500000),
		  (N'Bếp',4500000),
		  (N'Phục vụ',2500000),
		  (N'Tiếp thực',3000000),
		  (N'Nhân viên vệ sinh',3500000)
GO
--Thêm dữ liệu vào hệ số lương
INSERT INTO dbo.HeSoLuong
        ( heSoluong )
VALUES  ( 1  -- heSoluong - float
          ),
		(1.1),
		(1.2),
		(1.3),
		(1.4),
		(1.5)
GO
INSERT INTO dbo.PhuCap
        ( tienPhucap )
VALUES  ( 150000  -- tienPhucap - float
          ),
		  (200000),
		  (230000),
		  (250000),
		  (300000),
		  (350000),
		  (400000)
GO
INSERT INTO dbo.ChamCong
        ( idChamcong )
VALUES  ( 1  -- idChamcong - int
			),
		(2),
		(3),
		(4),
		(5),
		(6),
		(7),
		(8),
		(9),
		(10),
		(11),
		(12),
		(13),
		(14),
		(15),
		(16)
GO
INSERT INTO dbo.CaLamViec
        (tenCalam, heSo )
VALUES  (  -- idCalam - int
          N'Cả ngày', -- tenCalam - nvarchar(50)
          1.0  -- heSo - float
          ),
		  (N'Ca 3 giờ',0.7),
		  (N'Ca 5 giờ',0.5)
GO
SET DATEFORMAT DMY
INSERT INTO dbo.NhanVien
        ( tenNhanvien ,
          diaChi ,
          gioiTinh ,
          ngaySinh ,
          soDienthoai ,
          idChucvu ,
          idHesoluong ,
          idPhucap ,
		  idCalam,
		  idChamcong,
		  tinhTrang
        )
VALUES  ( N'Nguyễn Thế Ngọc' , -- tenNhanvien - nvarchar(200)
          N'140 Lê Trọng Tấn, Q.Tân Phú,TP.HCM' , -- diaChi - nvarchar(200)
          N'Nam' , -- gioiTinh - nvarchar(10)
		  '23/09/2000',
          '0338016618',--soDienthoai - nvarchar(15)
          1 , -- idChucvu - int
          5 , -- idHesoluong - int
          5 , -- idPhucap - int
		  1	,-- idCalam 
		  1 ,-- idChamcong
		  'TRUE' -- tinhTrang - char
        ),
		(N'Hoàng Thị Tâm',N'140 Lê Trọng Tấn,Q.Tân Phú,TP.HCM',N'Nữ','15/10/2001','0123498763',1,4,4,1,2,'TRUE'),
		(N'Đoàn Thị Diễm My',N'15 Chế Lan Viên,Q.Tân Phú,TP.HCM',N'Nữ','06/06/2000','01234912573',2,4,4,1,3,'TRUE'),
		(N'Lưu Văn Hoàng',N'10 Nguyễn Đỗ Cung,Q.Tân Phú,TP.HCM',N'Nam','01/01/2000','01234910087',1,4,4,2,4,'TRUE'),
		(N'Trần Văn Ngoan',N'110 Trường Chinh,Q.Tân Phú,TP.HCM',N'Nam','02/02/2000','01234916601',2,4,4,2,5,'TRUE'),
		(N'Lê Thị Thúy Kiều',N'72 Nguyễn Quế Anh,Q.Tân Phú,TP.HCM',N'Nữ','13/03/2000','0345017160',2,4,4,2,6,'TRUE'),
		(N'Đoàn Thị Diễm My',N'15 Chế Lan Viên,Q.Tân Phú,TP.HCM',N'Nữ','06/06/2000','01234912573',2,4,4,3,7,'FALSE'),
		(N'Nguyễn Thị Quỳnh Như',N'15 Chế Lan Viên,Q.Tân Phú,TP.HCM',N'Nam','06/06/2000','01234912573',3,4,4,3,8,'TRUE')
GO
INSERT INTO dbo.ChiTietChamCong
        ( idChamcong, thang, nam, soNgaylam )
VALUES  ( 1, -- idChamcong - int
          4, -- thang - int
          2021, -- nam - int
          29  -- soNgaylam - int
          ) 
GO      
--Thủ tục kiểm tra đăng nhập
CREATE PROC sp_KiemTraDangNhap @tenDangnhap NVARCHAR(100), @Matkhau NVARCHAR(100), @Kq INT OUTPUT
AS
	BEGIN
	DECLARE @count INT
	SET @count = (SELECT COUNT(*) FROM dbo.NguoiDung WHERE tenDangnhap = @tenDangnhap AND matKhau = @Matkhau AND tinhTrang = 'TRUE')
	IF @count > 0
		SET @Kq = 1
	ELSE
		SET @Kq = 0
	END
GO

--Thủ tục kiểm tra loại tài khoản
CREATE PROC sp_KiemTraTaiKhoan @tenDangnhap NVARCHAR(100), @Matkhau NVARCHAR(100), @Kq NVARCHAR(20) OUTPUT
AS
	BEGIN
	SET @Kq = (SELECT tenKieunguoidung FROM dbo.NguoiDung,dbo.KieuNguoiDung WHERE dbo.KieuNguoiDung.idKieunguoidung = dbo.NguoiDung.idKieunguoidung
	AND tenDangnhap=@tenDangnhap AND matKhau=@Matkhau)
	END
GO
--Thủ tục kiểm tra loại tài khoản trả về idKieunguoidung
CREATE PROC spKiemTraTaiKhoanId @tenDangnhap NVARCHAR(100),@kq INT OUTPUT
AS
	BEGIN 
	SET @kq = (SELECT idKieunguoidung FROM dbo.NguoiDung WHERE tenDangnhap = @tenDangnhap)
	END
GO
--Thủ tục thêm mới tài khoản
CREATE PROC sp_ThemNguoiDung @idKieunguoidung INT,@idNhanvien INT,@tenHienthi NVARCHAR(200),@tenDangnhap NVARCHAR(100),@matKhau NVARCHAR(100)
AS
	BEGIN
		INSERT INTO dbo.NguoiDung
		        ( idKieunguoidung ,
		          idNhanvien ,
		          tenHienthi ,
		          tenDangnhap ,
		          matKhau ,
		          tinhTrang
		        )
		VALUES  ( @idKieunguoidung , -- idKieunguoidung - int
		          @idNhanvien , -- idNhanvien - int
		          @tenHienthi , -- tenHienthi - nvarchar(200)
		          @tenDangnhap , -- tenDangnhap - nvarchar(100)
		          @matKhau , -- matKhau - nvarchar(100)
		          'TRUE'  -- tinhTrang - char(10)
		        )
	END
GO
-----------------------------THỦ TỤC VỀ MÓN ĂN---------------------------------------------------
--Thủ tục thêm mới danh mục
CREATE PROC sp_ThemDanhMucMon @tenDanhmuc NVARCHAR(100)
AS
	INSERT INTO dbo.DanhMucMon
	        ( tenDanhmuc )
	VALUES  (@tenDanhmuc )
GO
--Thủ tục thêm mới món ăn
CREATE PROC sp_ThemMonAn @tenMon NVARCHAR(200), @donGia INT, @idDanhmuc INT
AS
	INSERT INTO dbo.Mon
	        ( tenMon, donGia, idDanhmuc )
	VALUES  (@tenMon, @donGia, @idDanhmuc)

GO
--Lấy thông tin món ăn thông qua idMon
CREATE PROC sp_HienThiMonAnTheoId @idMon INT
AS
	SELECT * FROM dbo.Mon WHERE idMon = @idMon
GO
-----------------------------THỦ TỤC NHÂN VIÊN----------------------------------------------------
--Thủ tục thêm vào bảng chấm công
CREATE PROC sp_ThemChamCong @idChamcong INT
AS
	BEGIN
		INSERT INTO dbo.ChamCong
		        ( idChamcong )
		VALUES  ( @idChamcong  -- idChamcong - int
		          )
	END
GO
--Thủ tục cập nhật ngày công
CREATE PROC sp_CapNhatNgayCong @idChamcong INT, @thang INT, @nam INT,@soNgaylam INT
AS
	BEGIN
		INSERT INTO dbo.ChiTietChamCong
		        ( idChamcong, thang, nam, soNgaylam )
		VALUES  ( @idChamcong, -- idChamcong - int
		          @thang, -- thang - int
		          @nam, -- nam - int
		          @soNgaylam  -- soNgaylam - int
		          )
	END
GO
--Thủ tục hiển thị ngày công theo tháng năm và id chấm công
CREATE PROC sp_HienThiNgayCongTheoThangNam @thang INT,@nam INT
AS
	BEGIN
		SELECT dbo.ChiTietChamCong.idChamcong,dbo.NhanVien.tenNhanvien,thang,nam,soNgaylam FROM dbo.ChamCong,dbo.ChiTietChamCong,dbo.NhanVien WHERE ChamCong.idChamcong = dbo.NhanVien.idChamcong AND dbo.ChiTietChamCong.idChamcong = dbo.ChamCong.idChamcong AND thang = @thang AND nam = @nam
	END
GO
--Thủ tục kiểm tra số ngày công đã được cập nhật hay chưa
CREATE PROC sp_KiemTraCapNhatNgayCong @idChamcong INT, @thang INT, @nam INT, @kq INT OUTPUT
AS
	BEGIN
		DECLARE @res INT
		SET @res = (SELECT COUNT(*) FROM dbo.ChiTietChamCong WHERE idChamcong = @idChamcong AND thang = @thang AND nam = @nam)
		IF @res > 0
			SET @kq = 1
		ELSE 
			SET @kq = 0
	END
GO
--Thủ tục cập nhật lại ngày công theo ngày công đã được nhập trước đó
CREATE PROC sp_CapNhatLaiNgayCong @idChamcong INT, @thang INT, @nam INT,@soNgaylam INT
AS
	BEGIN
		UPDATE dbo.ChiTietChamCong SET soNgaylam = @soNgaylam WHERE idChamcong = @idChamcong AND thang = @thang AND nam = @nam
	END
GO
--Thủ tục kiểm tra lương nhân viên
CREATE PROC sp_KiemTraLuongNhanVien @idNhanvien INT ,@thang INT,@nam INT,@kq INT OUTPUT
AS
	BEGIN
		DECLARE @res INT
		SET @res = (SELECT COUNT(*) FROM dbo.Luong WHERE idNhanvien = @idNhanvien AND thang = @thang AND nam = @nam)
		IF @res > 0
			SET @kq = 1
		ELSE
			SET @kq = 0
	END
GO
--Thủ tục tính lương nhân viên
CREATE PROC sp_TinhLuongNhanVien @idNhanvien INT,@Thuong FLOAT,@Thang INT,@Nam INT ,@KQ MONEY OUTPUT
AS
	BEGIN
		DECLARE @Lcb FLOAT
		DECLARE @Hsl FLOAT  
		DECLARE @Phucap FLOAT
		DECLARE @Calam FLOAT
		DECLARE @Songaylam INT
		DECLARE @Luong FLOAT
		SET @Lcb = (SELECT luongCoban FROM dbo.ChucVu,dbo.NhanVien WHERE dbo.ChucVu.idChucvu = dbo.NhanVien.idChucvu AND idNhanvien = @idNhanvien)
		SET @Hsl = (SELECT heSoluong FROM dbo.NhanVien,dbo.HeSoLuong WHERE dbo.NhanVien.idHesoluong = HeSoluong.idHesoluong AND idNhanvien = @idNhanvien)
		SET @Phucap = (SELECT tienPhuCap FROM dbo.NhanVien,dbo.PhuCap WHERE dbo.NhanVien.idPhucap = dbo.PhuCap.idPhucap AND idNhanvien = @idNhanvien)
		SET @Calam = (SELECT heSo FROM dbo.NhanVien,dbo.CaLamViec WHERE dbo.NhanVien.idCalam = dbo.CaLamViec.idCalam AND idNhanvien = @idNhanvien)
		SET @Songaylam = (SELECT soNgaylam FROM dbo.NhanVien,dbo.ChamCong,dbo.ChiTietChamCong WHERE dbo.NhanVien.idChamcong = dbo.ChamCong.idChamcong AND dbo.ChiTietChamCong.idChamcong = dbo.ChamCong.idChamcong AND dbo.ChiTietChamCong.thang = @Thang AND dbo.ChiTietChamCong.nam = @Nam AND idNhanvien = @idNhanvien)
		SET @Luong = ((@Lcb * @Calam) / 30) * (SELECT CAST(@Songaylam AS FLOAT)) * @Hsl + @Thuong + @Phucap
		SET @KQ = (SELECT CAST(@Luong AS MONEY))
	END
GO

--Thủ tục lưu lương nhân viên
CREATE PROC sp_LuuLuongNhanVien @idNhanvien INT, @thang INT ,@nam INT, @luong MONEY,@ghiChu NVARCHAR(MAX)
AS
	BEGIN
		INSERT INTO dbo.Luong
		        ( idNhanvien, thang, nam, luong, ghiChu )
		VALUES  ( @idNhanvien, -- idNhanvien - int
		          @thang, -- thang - int
		          @nam, -- nam - int
		          @luong, -- luong - float
		          @ghiChu  -- ghiChu - nvarchar(max)
		          )
	END
GO
--Thủ tục cập nhật lương nhân viên
CREATE PROC sp_CapNhatLuongNhanVien @idNhanvien INT, @thang INT ,@nam INT, @luong MONEY,@ghiChu NVARCHAR(MAX)
AS 
	BEGIN
		UPDATE dbo.Luong SET luong = @luong, ghiChu = @ghiChu WHERE idNhanvien = @idNhanvien AND thang = @thang AND nam = @nam
	END
GO
--Thủ tục kiểm tra mã chấm công khi cập nhật
CREATE PROC sp_KiemTraChamCongCapNhat @idNhanvien INT,@idChamcong INT
AS
	BEGIN
	SELECT COUNT(*) FROM dbo.NhanVien WHERE idChamcong = @idChamcong
	EXCEPT
	SELECT COUNT(*) FROM dbo.NhanVien WHERE idNhanvien = @idNhanvien AND idChamcong = @idChamcong
	END
GO
--Hiển thị thông tin nhân viên
CREATE PROC sp_HienThiThongTinNV
AS
	BEGIN
		SELECT dbo.NhanVien.idNhanvien,tenNhanvien,diaChi,gioiTinh,CONVERT(VARCHAR,ngaySinh,103) AS ngaySinh,soDienthoai,tenChucvu,heSoluong,tienPhucap,dbo.CaLamViec.tenCalam,dbo.NhanVien.idChamcong,ghiChu,dbo.NhanVien.tinhTrang FROM dbo.NhanVien,dbo.ChucVu,dbo.HeSoLuong,dbo.PhuCap,dbo.CaLamViec
		WHERE dbo.NhanVien.idChucvu = dbo.ChucVu.idChucvu AND dbo.NhanVien.idHesoluong = heSoluong.idHesoluong AND dbo.NhanVien.idPhucap = dbo.PhuCap.idPhucap AND dbo.CaLamViec.idCalam = dbo.NhanVien.idCalam AND tinhTrang = 'TRUE'
    END
GO
--Hiển thị tất cả những nhân viên đã làm
CREATE PROC sp_HienThiThongTinNVAll
AS
	BEGIN
		SELECT dbo.NhanVien.idNhanvien,tenNhanvien,diaChi,gioiTinh,CONVERT(VARCHAR,ngaySinh,103) AS ngaySinh,soDienthoai,tenChucvu,heSoluong,tienPhucap,dbo.CaLamViec.tenCalam,dbo.NhanVien.idChamcong,ghiChu,dbo.NhanVien.tinhTrang FROM dbo.NhanVien,dbo.ChucVu,dbo.HeSoLuong,dbo.PhuCap,dbo.CaLamViec
		WHERE dbo.NhanVien.idChucvu = dbo.ChucVu.idChucvu AND dbo.NhanVien.idHesoluong = heSoluong.idHesoluong AND dbo.NhanVien.idPhucap = dbo.PhuCap.idPhucap AND dbo.CaLamViec.idCalam = dbo.NhanVien.idCalam
    END
GO
--Thủ tục lọc nhân viên theo chức vụ
CREATE PROC sp_HienThiThongTinNV_ChucVu @idChucvu INT
AS
	BEGIN
	SET DATEFORMAT DMY
		SELECT dbo.NhanVien.idNhanvien,tenNhanvien,diaChi,gioiTinh,CONVERT(VARCHAR,ngaySinh,103) AS ngaySinh,soDienthoai,tenChucvu,heSoluong,tienPhucap,dbo.CaLamViec.tenCalam,dbo.NhanVien.idChamcong,ghiChu,dbo.NhanVien.tinhTrang FROM dbo.NhanVien,dbo.ChucVu,dbo.HeSoLuong,dbo.PhuCap,dbo.CaLamViec
		WHERE dbo.NhanVien.idChucvu = dbo.ChucVu.idChucvu AND dbo.NhanVien.idHesoluong = heSoluong.idHesoluong AND dbo.NhanVien.idPhucap = dbo.PhuCap.idPhucap AND dbo.CaLamViec.idCalam = dbo.NhanVien.idCalam AND tinhTrang = 'TRUE' AND dbo.NhanVien.idChucvu = @idChucvu
    END
GO
--Thủ tục tìm kiếm nhân viên theo tên
CREATE PROC sp_TimKiemNhanVien @tenNhanVien NVARCHAR(200)
AS
	BEGIN
	SET DATEFORMAT DMY
		SELECT dbo.NhanVien.idNhanvien,tenNhanvien,diaChi,gioiTinh,CONVERT(VARCHAR,ngaySinh,103) AS ngaySinh,soDienthoai,tenChucvu,heSoluong,tienPhucap,dbo.CaLamViec.tenCalam,dbo.NhanVien.idChamcong,ghiChu,dbo.NhanVien.tinhTrang FROM dbo.NhanVien,dbo.ChucVu,dbo.HeSoLuong,dbo.PhuCap,dbo.CaLamViec
		WHERE dbo.NhanVien.idChucvu = dbo.ChucVu.idChucvu AND dbo.NhanVien.idHesoluong = heSoluong.idHesoluong AND dbo.NhanVien.idPhucap = dbo.PhuCap.idPhucap AND dbo.CaLamViec.idCalam = dbo.NhanVien.idCalam AND tinhTrang = 'TRUE' AND tenNhanvien LIKE +'%'+@tenNhanVien+'%'
    END
GO
--Thủ tục thêm nhân viên
CREATE PROC sp_ThemNhanVien @tenNhanvien NVARCHAR(200),@diaChi NVARCHAR(200), @gioiTinh NVARCHAR(10), @ngaySinh DATE, @soDienthoai NVARCHAR(15), @idChucvu INT, @idHesoluong INT,@idPhucap INT, @idCalam INT,@idChamcong INT,@ghiChu NVARCHAR(MAX)
AS
	BEGIN
	SET DATEFORMAT MDY
	INSERT INTO dbo.NhanVien
	        ( tenNhanvien ,
	          diaChi ,
	          gioiTinh ,
	          ngaySinh ,
	          soDienthoai ,
	          idChucvu ,
	          idHesoluong ,
	          idPhucap ,
	          idCalam,
			  idChamcong,
			  ghiChu,
			  tinhTrang
	        )
	VALUES  ( @tenNhanvien , -- tenNhanvien - nvarchar(200)
	          @diaChi , -- diaChi - nvarchar(200)
	          @gioiTinh , -- gioiTinh - nvarchar(10)
	          @ngaySinh , -- ngaySinh - date
	          @soDienthoai , -- soDienthoai - nvarchar(15)
	          @idChucvu , -- idChucvu - int
	          @idHesoluong , -- idHesoluong - int
	          @idPhucap , -- idPhucap - int
	          @idCalam,  -- idCalam - int
			  @idChamcong,-- idChamcong - int
			  @ghiChu,
			  'TRUE'
	        ) 
	END
GO
--Lấy danh sách chấm công chưa được cấp
CREATE PROC sp_HienThiChamCongChuaCap
AS
	BEGIN
		SELECT * FROM dbo.ChamCong
		EXCEPT
		SELECT dbo.ChamCong.idChamcong FROM dbo.NhanVien, dbo.ChamCong WHERE dbo.NhanVien.idChamcong = dbo.ChamCong.idChamcong
END
GO
--Hiển thị chấm công nhân viên
CREATE PROC sp_HienThiChamCongNhanVien
AS
	BEGIN 
		SELECT idNhanvien,tenNhanvien,tenChucvu,heSoluong,tienPhucap,dbo.CaLamViec.tenCalam,dbo.NhanVien.idChamcong FROM dbo.NhanVien,dbo.ChucVu,dbo.HeSoLuong,dbo.PhuCap,dbo.CaLamViec
		WHERE dbo.NhanVien.idChucvu = dbo.ChucVu.idChucvu AND dbo.NhanVien.idHesoluong = heSoluong.idHesoluong AND dbo.NhanVien.idPhucap = dbo.PhuCap.idPhucap AND dbo.CaLamViec.idCalam = dbo.NhanVien.idCalam AND tinhTrang = 'TRUE'
	END
GO
--Thủ tục hiển thị thông tin lương nhân viên
CREATE PROC sp_HienThiLuongNhanVien @thang INT,@nam INT
AS
	BEGIN
	SELECT tenNhanvien,dbo.Luong.thang,dbo.Luong.nam,luong,Luong.ghiChu FROM dbo.NhanVien,dbo.Luong
	WHERE dbo.Luong.idNhanvien = dbo.NhanVien.idNhanvien AND dbo.Luong.thang = @thang AND dbo.Luong.nam = @nam
	END
GO

--Hiển thị lương nhân viên theo mặc định
CREATE PROC sp_HienThiLuongNhanVienDefault
AS
	BEGIN
	SELECT dbo.Luong.idNhanvien,tenNhanvien,tenChucvu,heSoluong,tienPhucap,dbo.ChiTietChamCong.idChamcong,dbo.Luong.thang,dbo.Luong.nam,luong FROM dbo.NhanVien,dbo.ChucVu,dbo.HeSoLuong,dbo.PhuCap,dbo.Luong ,dbo.ChiTietChamCong
	WHERE dbo.NhanVien.idChucvu = dbo.ChucVu.idChucvu AND dbo.NhanVien.idHesoluong = dbo.HeSoLuong.idHesoluong AND dbo.NhanVien.idPhucap = dbo.PhuCap.idPhucap AND
    dbo.NhanVien.idNhanvien = dbo.ChiTietChamCong.idChamcong AND dbo.Luong.idNhanvien = dbo.NhanVien.idNhanvien AND dbo.Luong.thang = MONTH(GETDATE()) AND dbo.Luong.nam = YEAR(GETDATE())
	END
GO
--Thủ tục chỉnh sửa nhân viên
CREATE PROC sp_CapNhatNhanVien @idNhanvien INT, @tenNhanvien NVARCHAR(200),@diaChi NVARCHAR(200), @gioiTinh NVARCHAR(10), @ngaySinh DATE, @soDienthoai NVARCHAR(15), @idChucvu INT, @idHesoluong INT,@idPhucap INT,@idChamcong INT, @idCalam INT,@ghiChu NVARCHAR(MAX)
AS
	BEGIN 
	SET DATEFORMAT DMY
	UPDATE dbo.NhanVien SET tenNhanvien = @tenNhanvien, diaChi = @diaChi, gioiTinh = @gioiTinh, ngaySinh = @ngaySinh, soDienthoai = @soDienthoai, idChucvu = @idChucvu, idHesoluong = @idHesoluong, idPhucap = @idPhucap,idChamcong = @idChamcong, idCalam = @idCalam,ghiChu = @ghiChu WHERE idNhanvien = @idNhanvien
	END
GO

--THủ tục lấy lương nhân viên theo năm
CREATE PROC sp_TongluongNVNam @nam INT, @Luong INT OUTPUT
AS
	SET @Luong = (SELECT SUM(Luong) FROM dbo.Luong WHERE nam = @nam) 
GO
--THủ tục lấy lương nhân viên theo tháng
CREATE PROC sp_TongluongNVThang @thang INT,@nam INT, @Luong INT OUTPUT
AS
	SET @Luong = (SELECT SUM(Luong) FROM dbo.Luong WHERE thang = @thang AND nam = @nam) 
GO
INSERT INTO dbo.KieuNguoiDung
        ( tenKieunguoidung )
VALUES  (N'Quản Lí'),
		(N'Kế Toán'),
		(N'Thu Ngân'),
		(N'Bếp Trưởng'),
		(N'Phục Vụ')
GO
INSERT INTO dbo.NguoiDung
        ( idKieunguoidung ,
		  idNhanvien,
          tenHienthi ,
          tenDangnhap ,
          matKhau,
		  tinhTrang
        )
VALUES  ( 1 , -- idKieunguoidung - int
		  1, -- idNhanvien - int
          N'Nguyễn Thế Ngọc' , -- tenHienthi - nvarchar(200)
          N'ngoc123' , -- tenDangnhap - nvarchar(100)
          N'12345678',  -- matKhau - nvarchar(100)
		  'TRUE' --tinhTrang - char(10)
        ),
		( 3 , -- idKieunguoidung - int
		  8 , -- idNhanvien - int
          N'Nguyễn Thị Quỳnh Như' , -- tenHienthi - nvarchar(200)
          N'ngoc456' , -- tenDangnhap - nvarchar(100)
          N'12345678',  -- matKhau - nvarchar(100)
		  'TRUE' --tinhTrang - char(10)
        )
GO

---------------------------------------THỦ TỤC VỀ BÀN---------------------------------

--Thêm danh sách bàn
DECLARE @i INT = 0
WHILE @i <= 60
BEGIN
	INSERT INTO dbo.Ban
	        ( tenBan, tinhTrang )
	VALUES  ( N'Bàn ' + CAST(@i AS NVARCHAR(100)), -- tenBan - nvarchar(100)
	          0  -- tinhTrang - int
	          )
	SET @i = @i + 1
END
GO
INSERT INTO dbo.Ban
        ( tenBan, tinhTrang )
VALUES  ( N'Vip 1', -- tenBan - nvarchar(100)
          0  -- tinhTrang - int
          ),
		  (N'Vip 2',0),
		  (N'Vip 3',0),
		  (N'MV 1',0),
		  (N'MV 2',0)
GO
--Hiển thị danh sách bàn
CREATE PROC sp_HienThiBan
AS
	SELECT * FROM dbo.Ban
GO
--Thêm danh mục món
INSERT INTO dbo.DanhMucMon
        ( tenDanhmuc )
VALUES  ( N'Lẩu'  -- tenDanhmuc - nvarchar(100)
          ),
		  (N'Đồ nướng'),
		  (N'Cơm và món xào'),
		  (N'Hấp'),
		  (N'Thức uống'),
		  (N'Khác')
GO
---------------------------------------------THỦ TỤC VỀ MÓN-------------------------------------------
--Thêm món
CREATE PROC sp_ThemMon  @tenMon NVARCHAR(200),@donGia INT,@idDanhmuc INT,@tinhTrangMon INT
AS
	BEGIN
		INSERT INTO dbo.Mon
		        ( tenMon, donGia, idDanhmuc,tinhTrangMon )
		VALUES  ( @tenMon, -- tenMon - nvarchar(200)
		          @donGia, -- donGia - int
		          @idDanhmuc,  -- idDanhmuc - int
				  @tinhTrangMon
		          )
	END
GO
--Kiểm tra tình trạng bàn
CREATE PROC sp_KiemTraTinhTrangBan @idBan INT, @kq INT OUT
AS
	BEGIN
	SET @kq = (SELECT COUNT(*) FROM dbo.Ban WHERE idBan = @idBan AND tinhTrang = 1)
    END
GO


--Kiểm tra món đã tồn tại hay chưa
CREATE PROC sp_KiemTraMon @tenMon NVARCHAR(200), @kq INT OUTPUT
AS
	BEGIN
	DECLARE @ketquan INT 
		SET @ketquan = (SELECT COUNT(*) FROM dbo.Mon WHERE tenMon = @tenMon)
		IF @ketquan > 0
			SET @kq = 1
		ELSE
			SET @kq = 0
	END
GO
EXEC dbo.sp_KiemTraMon @tenMon = N'', -- nvarchar(200)
    @kq = 0 -- int

--Thêm dữ liệu cho món
INSERT INTO dbo.Mon
        ( tenMon ,
          donGia ,
          idDanhmuc ,
          tinhTrangMon
        )
VALUES  ( N'Lẩu hải sản' , -- tenMon - nvarchar(200)
          250000 , -- donGia - int
          1 , -- idDanhmuc - int
          1  -- tinhTrangMon - int
        ),
		(N'Lẩu thái',250000,1,1),
		(N'Lẩu cá lăng',290000,1,1),
		(N'Lẩu dê tươi',290000,1,1),
		(N'Lẩu cá đuối',250000,1,1),
		(N'Lẩu bò mỹ',290000,1,1),
		(N'Lẩu cá tầm',320000,1,1),
		(N'Lẩu xí quách dê',250000,1,1),
		(N'Bò mỹ nướng sốt tiêu đen',150000,2,1),
		(N'Bò mỹ nướng muối ớt xanh',150000,2,1),
		(N'Bò mỹ nướng sốt nhật',160000,2,1),
		(N'Thăn bò nướng sốt nhật',140000,2,1),
		(N'Sườn bò nướng muối ớt xanh',180000,2,1),
		(N'Sườn bò nướng mọi',180000,2,1),
		(N'Sườn bò nướng sa tế',180000,2,1),
		(N'Bạch tuộc nướng muối ớt xanh',170000,2,1),
		(N'Bạch tuộc nướng sa tế',170000,2,1),
		(N'Bạch tuộc nướng mọi',170000,2,1),
		(N'Chẳng dừng nướng',150000,2,1),
		(N'Sò huyết nướng mọi',130000,2,1),
		(N'Ốc bưu nướng muối tiêu xanh',130000,2,1),
		(N'Ốc hương nướng mọi',130000,2,1),
		(N'Gà ta nướng muối ớt',220000,2,1),
		(N'Cá thu nướng kiểu nhật',130000,2,1),
		(N'Cá lóc nướng trui',140000,2,1),
		(N'Cá lóc nướng bọt biển',160000,2,1),
		(N'Tôm nướng muối ớt',120000,2,1),
		(N'Tôm nướng mọi',120000,2,1),
		(N'Tôm nướng muối ớt xanh',120000,2,1),
		(N'Đùi dê đúc lò',450000,2,1),
		(N'Cơm chiên cá mặn',90000,3,1),
		(N'Cơm chiên tỏi',90000,3,1),
		(N'Cơm chiên dương châu',95000,3,1),
		(N'Mì xào hải sản',100000,3,1),
		(N'Mì xào bò',100000,3,1),
		(N'Mì xào thập cẩm',100000,3,1),
		(N'Lòng xào mướp',90000,3,1),
		(N'Bò né khổ qua',90000,3,1),
		(N'Đậu hủ chiên giòn',50000,3,1),
		(N'Khoai tây chiên',50000,3,1),
		(N'Rau muống xào',50000,3,1),
		(N'Bò xào khổ qua',90000,3,1),
		(N'Ngêu hấp sả',120000,4,1),
		(N'Ngêu hấp thái',120000,4,1),
		(N'Ốc bưu hấp thái',120000,4,1),
		(N'Dê hấp tía tô',150000,4,1),
		(N'Bắp bò hấp gừng',150000,4,1),
		(N'Gà hấp hành',120000,4,1),
		(N'Bia tiger nâu lon',20000,5,1),
		(N'Bia tiger nâu chai',18000,5,1),
		(N'Bia tiger bạc lon',21000,5,1),
		(N'Bia tiger bạc chai',18000,5,1),
		(N'Bia sài giòn xanh lon',20000,5,1),
		(N'Bia sài gòn xanh chai',18000,5,1),
		(N'Bia sài gòn đỏ chai',17000,5,1),
		(N'Bia heineken chai',20000,5,1),
		(N'Bia heineken lon',23000,5,1),
		(N'Bia sapporo lon',18000,5,1),
		(N'Sting lon',15000,5,1),
		(N'Coca lon',15000,5,1),
		(N'Mirinda lon',15000,5,1),
		(N'Mirinda soda kem',15000,5,1),
		(N'Seven up',15000,5,1),
		(N'Strongbow dâu lon',22000,5,1),
		(N'Strongbow mật ông lon',22000,5,1),
		(N'Strongbow dâu tằm lon',22000,5,1),
		(N'Khăn ướt',2000,6,1),
		(N'Khô gà',30000,6,1),
		(N'Trái cây',45000,6,1),
		(N'Khô gà',30000,6,1),
		(N'Bánh đa',20000,6,1),
		(N'Mì gói thêm',2000,6,1)
--Cập nhật món
GO
CREATE PROC sp_CapNhatMon @idMon INT,@tenMon NVARCHAR(200),@donGia INT,@idDanhmuc INT,@tinhTrangMon INT
AS
	BEGIN
		UPDATE dbo.Mon
		SET tenMon = @tenMon,donGia=@donGia,idDanhmuc = @idDanhmuc, tinhTrangMon = @tinhTrangMon WHERE idMon = @idMon
	END
GO
------------------------------------THỦ TỤC VỀ HÓA ĐƠN------------------------------
--Hiển thị hóa đơn theo bàn
CREATE PROC sp_HienThiHoaDonTheoBan @idBan INT 
AS
	BEGIN
		SELECT dbo.Mon.tenMon, dbo.Mon.donGia, dbo.ChiTietHoaDon.soLuong, dbo.Mon.donGia*dbo.ChiTietHoaDon.soLuong AS thanhTien 
		FROM dbo.Mon,dbo.ChiTietHoaDon,dbo.HoaDon
		WHERE dbo.Mon.idMon = dbo.ChiTietHoaDon.idMon AND dbo.ChiTietHoaDon.idHoadon = dbo.HoaDon.idHoadon AND dbo.HoaDon.idBan = @idBan AND tinhTrangHoaDon = 0
	END
GO
--Hiển thị ngày vào theo bàn
CREATE PROC sp_HienThiNgayVao @idBan INT
AS
	BEGIN 
		SELECT ngayNhap FROM dbo.HoaDon WHERE idBan = @idBan AND tinhTrangHoaDon = 0
	END
GO

--Thêm mới hóa đơn vào bàn
GO
CREATE PROC sp_ThemHoaDon @idBan INT, @idNguoidung INT
AS
	BEGIN
	SET DATEFORMAT DMY
		INSERT INTO dbo.HoaDon
		        ( idBan ,
				  idNguoidung,
		          ngayNhap ,
		          ngayXuat ,
		          tinhTrangHoaDon
		        )
		VALUES  ( @idBan , -- idBan - int
				  @idNguoidung, --idNguoidung - int
		          GETDATE() , -- ngayNhap - date
		          NULL , -- ngayXuat - date
		          0  -- tinhTrangHoaDon - int
		        )
	END
GO
--Cập nhật tình trạng bàn
CREATE PROC sp_CapNhatTinhTrangBan1 @idBan INT
AS
	BEGIN
		UPDATE dbo.Ban
		SET tinhTrang = 1 WHERE idBan = @idBan
	END
GO
CREATE PROC sp_CapNhatTinhTrangBan0 @idBan INT
AS
	BEGIN
		UPDATE dbo.Ban
		SET tinhTrang = 0 WHERE idBan = @idBan
	END
GO
--Lẫy mã hóa đơn theo bàn
CREATE PROC sp_LayIdHoaDon @idBan INT, @kq INT OUTPUT
AS
	BEGIN
		SET @kq = (SELECT idHoadon FROM dbo.HoaDon WHERE idBan = @idBan AND tinhTrangHoaDon = 0)
	END
GO
--Thêm mới vào chi tiết hóa đơn
CREATE PROC sp_ThemChiTietHoaDon @idHoadon INT,@idMon INT,@soLuong INT
AS
BEGIN
	DECLARE @isExitChiTietHoaDon INT
	DECLARE @soLuongMon INT = 1
	SELECT @isExitChiTietHoaDon = idChiTietHoaDon ,@soLuongMon = soLuong
	FROM dbo.ChiTietHoaDon WHERE idHoadon = @idHoadon AND idMon = @idMon
	IF(@isExitChiTietHoaDon > 0)
	BEGIN
		DECLARE @newSoLuong INT = @soLuongMon + @soLuong
		IF(@newSoLuong > 0)
			UPDATE dbo.ChiTietHoaDon SET soLuong = @newSoLuong WHERE idMon = @idMon
		ELSE
			DELETE dbo.ChiTietHoaDon WHERE idHoadon = @idHoadon AND idMon = @idMon
	END
	ELSE
	BEGIN
		INSERT INTO dbo.ChiTietHoaDon
				( idHoadon, idMon, soLuong )
		VALUES  ( @idHoadon, -- idHoadon - int
				  @idMon, -- idMon - int
				 @soLuong  -- soLuong - int
				  )
	END
END
GO
--Lấy id hóa đơn vừa nhập vào
CREATE PROC sp_LayMaxIdHoaDon @kq INT OUTPUT
AS
	BEGIN
		SET @kq = (SELECT MAX(idHoadon) FROM dbo.HoaDon)
	END
GO
--Cập nhật hóa đơn
CREATE PROC sp_CapNhatHoaDon @idHoaDon INT,@tongTien INT,@idNguoidung INT
AS
	BEGIN
		UPDATE dbo.HoaDon
		SET tinhTrangHoaDon = 1 WHERE idHoadon = @idHoaDon
		UPDATE dbo.HoaDon
		SET ngayXuat = GETDATE() WHERE idHoaDon = @idHoadon 
		UPDATE dbo.HoaDon
		SET tongTienHoaDon = @tongTien WHERE idHoadon = @idHoaDon
		UPDATE dbo.HoaDon
		SET idNguoidung = @idNguoidung WHERE idHoadon = @idHoaDon
	END
GO
--Lấy tổng tiền theo idHoadon
CREATE PROC sp_LayTongTien @idHoaDon INT, @kq INT OUTPUT
AS
	BEGIN
		SET @kq = (SELECT SUM(donGia*soLuong) FROM dbo.ChiTietHoaDon, dbo.HoaDon, dbo.Mon WHERE dbo.HoaDon.idHoadon = dbo.ChiTietHoaDon.idHoadon AND dbo.Mon.idMon = dbo.ChiTietHoaDon.idMon AND ChiTietHoaDon.idHoadon = @idHoaDon )
	END
GO
--Xóa món từ bảng chi tiết hóa đơn
CREATE PROC sp_XoaMonHoaDon @idHoaDon INT, @tenMon NVARCHAR(200)
AS
	DECLARE @idMon INT
	SET @idMon = (SELECT idMon FROM dbo.Mon WHERE tenMon = @tenMon)
	BEGIN
	DELETE FROM dbo.ChiTietHoaDon WHERE idMon = @idMon AND idHoadon = @idHoaDon
	END
GO
-----------------------------------------THỦ TỤC VỀ BÀN-----------------------------
--Thực hiện chuyển bàn


CREATE PROC sp_ChuyenBan @idBan1 INT, @idBan2 INT
AS
	BEGIN
		DECLARE @idHoaDonCu INT
		DECLARE @idHoaDonMoi INT
		SET @idHoaDonCu = (SELECT idHoaDon FROM dbo.HoaDon WHERE idBan = @idBan1 AND tinhTrangHoaDon = 0)
		SET @idHoaDonMoi = (SELECT idHoaDon FROM dbo.HoaDon WHERE idBan = @idBan2 AND tinhTrangHoaDon = 0)
		BEGIN
			IF(@idHoaDonMoi IS NULL)
			BEGIN
				INSERT INTO dbo.HoaDon
			        ( idBan ,
			          ngayNhap ,
			          ngayXuat ,
			          tinhTrangHoaDon ,
			          tongTienHoaDon
			        )
				VALUES  ( @idBan2 , -- idBan - int
			          GETDATE() , -- ngayNhap - datetime
			          0 , -- ngayXuat - datetime
			          0 , -- tinhTrangHoaDon - int
			          0  -- tongTienHoaDon - int
			        )
				SET @idHoaDonMoi = (SELECT MAX(idHoadon) FROM dbo.HoaDon)
			END
			UPDATE dbo.HoaDon SET tinhTrangHoaDon = 1 WHERE idHoadon = @idHoaDonCu 
			UPDATE dbo.HoaDon SET ngayXuat = GETDATE() WHERE idHoadon = @idHoaDonCu 
			UPDATE dbo.HoaDon SET tongTienHoaDon = 0 WHERE idHoadon = @idHoaDonCu 
			UPDATE dbo.Ban SET tinhTrang = 0 WHERE idBan = @idBan1
			UPDATE dbo.Ban SET tinhTrang = 1 WHERE idBan = @idBan2
			SELECT idChitiethoadon INTO IDThongTinHoaDon FROM dbo.ChiTietHoaDon WHERE idHoadon = @idHoaDonCu
			UPDATE dbo.ChiTietHoaDon SET idHoadon = @idHoaDonMoi WHERE idChitiethoadon IN (SELECT * FROM IDThongTinHoaDon)
			DROP TABLE IDThongTinHoaDon
		END
END
GO

---------------------------------CÁC THỦ TỤC VỀ DOANH THU--------------------------------------------
--Tính doanh thu theo tháng hiện tại
CREATE PROC sp_TongDoanhThuThang @thang INT,@nam INT, @DoanhThu INT OUTPUT
AS
	SET @DoanhThu = (SELECT SUM(tongTienHoaDon) FROM dbo.HoaDon WHERE MONTH(ngayXuat)=@thang AND YEAR(ngayXuat)=@nam) 
GO
--Tính doanh thu năm
CREATE PROC sp_TongDoanhThuNam @nam INT, @DoanhThu INT OUTPUT
AS
	SET @DoanhThu = (SELECT SUM(tongTienHoaDon) FROM dbo.HoaDon WHERE YEAR(ngayXuat)=@nam) 
GO
--Lấy doanh thu theo từng tháng
CREATE PROC sp_LayDoanhThuTungThang @nam INT
AS
	BEGIN
		SELECT MONTH(ngayXuat) AS Thang ,SUM(tongTienHoaDon) AS Tongtien FROM dbo.HoaDon WHERE YEAR(ngayXuat)=@nam GROUP BY MONTH(ngayXuat)
	END
GO
--Lấy tổng lương nhân viên tháng
CREATE PROC sp_TongLuongNhanVienThang @nam INT
AS
	BEGIN
		SELECT thang, SUM(luong) FROM dbo.Luong WHERE nam = @nam GROUP BY thang
	END
GO   
--Tính doanh thu theo ngày tháng nhập vào
CREATE PROC sp_TongDoanhThuNgay @ngay INT,@thang INT,@nam INT, @DoanhThu INT OUTPUT
AS
	SET @DoanhThu = (SELECT SUM(tongTienHoaDon) FROM dbo.HoaDon WHERE DAY(ngayXuat)=@ngay AND MONTH(ngayXuat)=@thang AND YEAR(ngayXuat)=@nam)
GO
--Tính doanh thu của một bàn trong ngày
CREATE PROC sp_TongDoanhThuNgayTheoBan @idBan INT,@ngay INT,@thang INT,@nam INT, @DoanhThu INT OUTPUT
AS
	SET @DoanhThu = (SELECT SUM(tongTienHoaDon) FROM dbo.HoaDon WHERE DAY(ngayXuat)=@ngay AND MONTH(ngayXuat)=@thang AND YEAR(ngayXuat)=@nam AND idBan = @idBan)
GO
--Thủ tục hiển thị tiền bán theo ngày
CREATE PROC sp_TienBanNgay @ngay INT,@thang INT,@nam INT
AS
	BEGIN
	SELECT idHoadon,idBan,ngayNhap,ngayXuat,tinhTrangHoaDon,tongTienHoaDon FROM dbo.HoaDon WHERE DAY(ngayNhap) = @ngay AND MONTH(ngayNhap) = @thang AND YEAR(ngayNhap) = @nam
	END
GO
--Thủ tực hiển thị hóa đơn theo tháng
CREATE PROC sp_TienBanThang @thang INT,@nam INT
AS
	BEGIN
	SELECT * FROM dbo.HoaDon WHERE MONTH(ngayNhap) = @thang AND YEAR(ngayNhap) = @nam
	END
GO
--THủ tục hiển thị hóa đơn theo bàn trong ngày
CREATE PROC sp_TienBanTheoBan @idBan INT,@ngay INT,@thang INT,@nam INT
AS
	BEGIN
		SELECT * FROM dbo.HoaDon WHERE DAY(ngayNhap) = @ngay AND MONTH(ngayNhap) = @thang AND YEAR(ngayNhap) = @nam AND idBan = @idBan
	END
GO
------------------------------------------------TRIGGER--------------------------------------------------
--Trigger cập nhật tình trạng người dùng khi nhân viên nghỉ việc
CREATE TRIGGER updateTinhTrangNguoiDung ON NhanVien
For UPDATE
AS
	IF UPDATE(tinhTrang)
		update NguoiDung
	SET tinhTrang = (Select tinhTrang from inserted ) WHERE idNhanvien = (SELECT idNhanvien FROM inserted)
	SELECT*FROM dbo.NguoiDung
	SELECT*FROM dbo.CaLamViec