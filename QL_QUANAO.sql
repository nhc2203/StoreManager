drop database QL_QUANAO
create database QL_QUANAO
go
use QL_QUANAO
go
create table NHACUNGCAP
(
	MACC nchar(10) not null, --CHINH
	TENCC nchar(30),
	DIACHI nvarchar(50),
	DTHOAI nchar(15)
)
create table LOAIQUANAO
(
	MALOAI INT  IDENTITY(1,1) not null, --CHINH
	TENLOAI nvarchar(60)
)
Create table SANPHAM
(
	MASP INT  IDENTITY(1,1), --CHINH
	TENSP nvarchar(100),
	SIZE nchar(10),
	XUATXU nvarchar(30),
	GIOITINH nvarchar (5),
	SoLuong int,
	GIABAN money,
	TinhTrang NVARCHAR(50),
	HINH nchar(100),
	MALOAI int not null --NGOAI
)

create table NHAPHANG
(
	MANHAP nchar(10) not null, --CHINH
	MACC nchar(10) not null, --NGOAI
	TIENDAUTU money,
	NGAYNHAP date
)
create table CTSANPHAMNHAP
(
	MANHAP nchar(10) not null,--NGOAI
	MASP int not null,--CHINH,NGOAI	
	SOLUONG int,
	DONGIA money
)
create table KHACHHANG
(
	MAKH nchar(10) not null,--CHINH
	TENKH nvarchar(30),
	NGSINH Date,
	DIACHI nvarchar(30),
	DTHOAI nchar(12),
	TAIKHOAN nchar(50),
	MATKHAU nchar(50)
)

create table NHANVIEN
(
	MANV nchar(10) not null,--CHINH
	TENNV nvarchar(30),
	NGSINH Date,
	DIACHI nvarchar(30),
	DTHOAI nchar(12),
	LUONG money,
	TAIKHOAN nchar(50),
	MATKHAU nchar(50)
)
create table HOADON
(
	MAHD int IDENTITY(1,1) not null,--CHINH
	NGAYHD Date,
	MAKH nchar(10) not null,--NGOAI
    TongTien money,
	MANV nchar(10)
)
create table CTHOADON
(
     MAHD int,
	 MaSP int,
	 SoLuong int,
	 DonGia money
	 constraint fk_mahd_masp primary key(MAHD,MaSP),
)


alter table NHACUNGCAP
add constraint PK_MACC primary key (MACC)

alter table LOAIQUANAO
add constraint PK_MALQA primary key (MALOAI)

alter table NHAPHANG
add constraint PK_MANHAP primary key (MANHAP)

alter table CTSANPHAMNHAP
add constraint PK_MASP primary key (MASP)

alter table SANPHAM 
add constraint PK_MASP2 primary key (MASP)

alter table KHACHHANG 
add constraint PK_MAKH primary key (MAKH)

alter table NHANVIEN 
add constraint PK_MANV primary key (MANV)

alter table HOADON
add constraint PK_MAHD primary key (MAHD)


-----------KHÓA NGOẠI------------

alter table SANPHAM 
add constraint FK_MA foreign key (MALOAI) references LOAIQUANAO (MALOAI)
alter table NHAPHANG
add constraint FK_MACC foreign key (MACC) references NHACUNGCAP (MACC)
alter table CTSANPHAMNHAP
add constraint FK_CTMANHAP foreign key (MANHAP) references NHAPHANG(MANHAP)
alter table CTSANPHAMNHAP
add constraint FK_CTMASP foreign key (MASP) references SANPHAM(MASP)
alter table HOADON 
add constraint FK_MAKH foreign key (MAKH) references KHACHHANG (MAKH)
alter table HOADON 
add constraint FK_MANV foreign key (MANV) references NHANVIEN (MANV)
alter table CTHOADON
add constraint FK_mahd_1masp foreign key(MAHD) references HOADON(MAHD)
alter table CTHOADON
add constraint FK_mahdmasp foreign key(MaSP) references SANPHAM(MASP) 
                     
insert LOAIQUANAO (TENLOAI)
values (N'Thế Giới Quần'),
	   (N'Thế Giới Áo'),
	   (N'Thế Giới Váy'),
	    (N'Thế Giới Giày'),
		 (N'Thế Giới Mũ'),
       (N'Phụ kiện')



SELECT * FROM HOADON
insert SANPHAM (TENSP, SIZE, XUATXU, GIOITINH, GIABAN,HINH, MALOAI, SoLuong)--//QUAN
values (N'Quần short kaki', 'Free Size', N'Việt Nam', N'NAM', 400000,'quan_short__kaki_nam_dep_7.jpg', 1, 10),
(N'Quần Baggy kaki', 'Free Size', N'Trung Quốc', N'NỮ', 550000,'quanBaggy.jfif', 1, 10),
(N'Quần Baggy jean', 'Free Size', N'MỸ', N'NỮ', 155000,'Quanbaggy.jpg', 1, 10),
(N'Quần jean', 'Free Size', N'Việt Nam', N'NAM', 550000,'Quanjean.jpg', 1, 10),
(N'Quần jean rách rưới', 'Free Size', N'Việt Nam', N'NAM', 590000,'Quanjeanrach.jpg', 1, 10),
(N'Quần jogger kaki nam', 'Free Size', N'HÀN', N'NAM', 550000,'quanjoggerkakinam.jpg', 1, 10),
(N'Quần kaki', 'Free Size', N'Việt Nam', N'NAM', 550000,'QuanKaki.jpg', 1, 10),
(N'Quần short thể thao', 'Free Size', N'MỸ', N'NAM', 455000,'quanshort.jfif', 1, 10),
(N'Quần Tây', 'Free Size', N'Hàn', N'NAM', 1500000,'Quantay.jpg', 1, 10),
(N'Quần dài thể thao ', 'Free Size', N'Việt Nam', N'NAM', 10000000,'Quanthethao.jpg', 1, 10)
insert SANPHAM (TENSP, SIZE, XUATXU, GIOITINH, GIABAN,HINH, MALOAI, SoLuong)--//AO
values (N'Áo Ba Lỗ', 'S', N'Việt Nam', N'NAM', 40000,'aobalo.jpg', 2, 10),
(N'Áo Croptop', 'L', N'Trung Quốc', N'NỮ', 55000,'aocroptop.jpg', 2, 10),
(N'Áo Hoodie tai mèo', 'Free Size', N'Trung Quốc', N'NỮ', 250000,'aohoodietaimeo.png', 2, 10),
(N'Áo Khoác Bomber', 'Free Size', N'Việt Nam', N'NAM', 100000,'aokhoacbomber.jpg', 2, 10),
(N'Áo Khoác Dù', 'XL', N'Việt Nam', N'NAM', 120000,'aokhoacdu.jpg', 2, 10),
(N'Áo len nữ', 'L', N'HÀN', N'NỮ', 800000,'aolennu.jpg', 2, 10),
(N'Áo sơ mi', 'XL', N'Việt Nam', N'NAM', 250000,'aosomi.jpg', 2, 10),
(N'Áo Sweater', 'Free Size', N'MỸ', N'NỮ', 455000,'aosweater.jpg', 2, 10),
(N'Áo tay lỡ', 'Free Size', N'Hàn', N'NAM', 2500000,'aotaylo.jpg', 2, 10),
(N'Áo thun nam ', 'L', N'Việt Nam', N'NAM', 200000,'aothunnam.jpg', 2, 10)
insert SANPHAM (TENSP, SIZE, XUATXU, GIOITINH, GIABAN,HINH, MALOAI, SoLuong)--//GIAY
values (N'Giày convert', 'S', N'Việt Nam', N'NAM', 40000000,'giayconvert.jfif', 4, 10),
(N'Giày sport time', 'L', N'Trung Quốc', N'NỮ', 55000,'giay2.jfif', 4, 10),
(N'Giày frezz', 'Free Size', N'Trung Quốc', N'Nam', 250000,'giay3.jfif', 4, 10),
(N'Giay Convert cổ cao', 'Free Size', N'Việt Nam', N'NAM', 120000,'giay4.jfif', 4, 10),
(N'Giay thể thao', 'XL', N'Việt Nam', N'NAM', 1120000,'giay5.jfif', 4, 10),
(N'Giày crop', 'L', N'HÀN', N'NỮ', 880000,'giay6.jfif', 4, 10),
(N'Giày mỹ', 'XL', N'Mỹ Tho', N'NAM', 250000,'giay7.jfif', 4, 10),
(N'Giày adias', 'Free Size', N'MỸ', N'NỮ', 455000,'giay8.jfif', 4, 10),
(N'Giày baleciaga', 'Free Size', N'Hàn', N'NAM', 12500000,'giay9.jfif', 4, 10),
(N'Giay Tổ Ong', 'L', N'Việt Nam', N'NAM', 999999999,'giay10.jfif', 4, 10)
insert SANPHAM (TENSP, SIZE, XUATXU, GIOITINH, GIABAN,HINH, MALOAI, SoLuong)--Phu KIEN
values (N'Thắc lưng trơn', 'Free Size', N'THAILAN', N'NAM', 315000,'ThacLungTron.png', 6, 10),
(N'Thắc lưng da họa tiết', 'Free Size', N'MỸ', N'NAM', 550000,'ThacLung1.png', 6, 10),
(N'Thắc lưng cao cấp', 'Free Size', N'MỸ', N'NAM', 1550000,'ThacLung2.png', 6, 10),
(N'Túi đeo chéo', 'Free Size', N'MỸ', N'NAM', 550000,'TuiDeoCheo1.png', 6, 10),
(N'Túi đeo chéo, có thêu', 'Free Size', N'MỸ', N'NAM', 590000,'TuiDeoCheo2.png', 6, 10),
(N'Túi TOTE vải DENIM', 'Free Size', N'HÀN', N'NAM', 550000,'TuiDeoCheo3.png', 6, 10),
(N'Túi Bao Tử', 'Free Size', N'MỸ', N'NAM', 550000,'TuiDeoCheo4.png', 6, 10),
(N'Ví da lịch lãm', 'Free Size', N'MỸ', N'NAM', 455000,'ViDa1.png', 6, 10),
(N'Ví da phong cách', 'Free Size', N'Hàn', N'NAM', 1500000,'ViDa2.png', 6, 10),
(N'Ví Da đẳng cấp ', 'Free Size', N'MỸ', N'NAM', 10000000,'ViDa3.png', 6, 10),
(N'Vớ dài phối màu', 'Free Size', N'MỸ', N'NAM', 350000,'Vo1.png', 6, 10),
(N'Vớ dài kẻ sọc', 'Free Size', N'MỸ', N'NAM', 350000,'Vo2.png', 6, 10),
(N'Vớ cotton ngắn trơn', 'Free Size', N'MỸ', N'NAM', 250000,'Vo3.png', 6, 10),
(N'Vớ dài phối cotton', 'Free Size', N'MỸ', N'NAM', 550000,'Vo4.png', 6, 10)
set dateformat dmy
insert KHACHHANG (MAKH, TENKH, NGSINH, DIACHI, DTHOAI,TAIKHOAN, MATKHAU)
values ('KH001', N'Nguyễn Duy Mạnh', '30-03-2001', N'Tân phú', '0996562411','duymanh', 'duymanh')


insert NHANVIEN (MANV, TENNV, NGSINH, DIACHI, DTHOAI,TAIKHOAN, MATKHAU)
values ('NV001', N'Nguyễn Cuong Cho', '23-03-2001', N'Go Vap', '0992827323','cuong', '1')
select  * from HOADON
select  * from CTHOADON
insert KHACHHANG (MAKH, TENKH, NGSINH, DIACHI, DTHOAI,TAIKHOAN, MATKHAU)
values ('KH002', N'Nguyễn Duy Mạnh', '30-03-2001', N'Tân phú', '0996562411','dacdat', '1')

set dateformat dmy
insert into HOADON (MAKH, NGAYHD, MANV) values('KH002', getdate(), 'NV001')

insert into CTHOADON (MAHD, MASP,SOLUONG, DONGIA) values(1, 6, 3,5999000)

insert into NHACUNGCAP(MACC, TENCC, DIACHI, DTHOAI)
values ('NCC001', N'Huynh Phat', N'Tan Phu', '09324123123')

insert into NHAPHANG(MANHAP, MACC, TIENDAUTU, NGAYNHAP)
values ('MN001', 'NCC001', 5000000, GETDATE())
create trigger KT_SOLUONG on SANPHAM
for insert,update
as
begin
	     UPDATE SANPHAM
		 SET TINHTRANG = N'Hết hàng' where SOLUONG = 0
		UPDATE SANPHAM
		SET TINHTRANG = N'Còn hàng' where SOLUONG > 0
	
end
drop trigger KT_SOLUONG