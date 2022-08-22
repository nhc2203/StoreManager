using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models
{
    public class CartItem
    {
        public int iMaSP { get; set; }
        public string sTenSP { get; set; }
        public string sSize { get; set; }
        public string sXuatXu { get; set; }
        public string sGioiTinh { get; set; }
        public double dGiaBan { get; set; }
        public string sHinh { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dGiaBan; }
        }

        QL_QUANAODataContext data = new QL_QUANAODataContext();
        public CartItem(int MaSP)
        {
            SANPHAM quanao = data.SANPHAMs.Single(n => n.MASP == MaSP);
            if (quanao != null)
            {
                iMaSP = MaSP;
                sTenSP = quanao.TENSP;
                sSize = quanao.SIZE;
                sXuatXu = quanao.XUATXU;
                sGioiTinh = quanao.GIOITINH;
                dGiaBan = double.Parse(quanao.GIABAN.ToString());
                sHinh = quanao.HINH;
                iSoLuong = 1;
            }
        }
    }
}