using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreManager.Models
{
    public class GioHang
    {
        public List<CartItem> lst;
        public GioHang()
        {
            lst = new List<CartItem>();
        }
        public GioHang(List<CartItem> lstGH)
        {
            if (lstGH == null)
                lst = new List<CartItem>();
            else
                lst = lstGH;
        }
        public int SoMatHang()
        {
            if (lst == null)
                return 0;
            return lst.Count;
        }
        public int TongSLHang()
        {
            int iTongSoLuong = 0;

            if (lst != null)
            {
                iTongSoLuong = lst.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }

        public double TongThanhTien()
        {
            double iTongTien = 0;
            if (lst != null)
            {
                iTongTien = lst.Sum(n => n.ThanhTien);
            }
            return iTongTien;
        }
        public int Them(int iMaSP)
        {
            CartItem sanpham = lst.Find(n => n.iMaSP == iMaSP);
            if (sanpham == null)
            {
                CartItem quanao = new CartItem(iMaSP);
                if (quanao == null)
                    return -1;
                lst.Add(quanao);
            }
            else
            {
                sanpham.iSoLuong++;

            }
            return 1;
        }
        public int Xoa(int iMaSP)
        {
            CartItem sanpham = lst.Find(n => n.iMaSP == iMaSP);
            if (sanpham != null)
            {
                lst.Remove(sanpham);
                return 1;
            }
            return -1;
        }
        public int Sua(int MaSP, int SoLuong)
        {
            CartItem sanpham = lst.Find(n => n.iMaSP == MaSP);
            if (sanpham != null)
            {
                sanpham.iSoLuong = SoLuong;
                return 1;
            }
            return -1;
        }

        public void XoaGioHang()
        {
            lst.Clear();
        }
    }
}   