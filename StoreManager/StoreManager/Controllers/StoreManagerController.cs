using StoreManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManager.Controllers
{
    public class StoreManagerController : Controller
    {
        //
        // GET: /StoreManager/
        QL_QUANAODataContext data = new QL_QUANAODataContext();
        public ActionResult Home()
        {
            List<SANPHAM> dstl = data.SANPHAMs.Take(12).ToList();
            return View(dstl);
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult HTTENLOAI()
        {
            List<LOAIQUANAO> dsL = data.LOAIQUANAOs.ToList();
            return PartialView(dsL);
        }
        public ActionResult HTSP(int ml)
        {
            List<SANPHAM> dsSP = data.SANPHAMs.Where(t => t.MALOAI == ml).ToList();
            ViewBag.lst1 = dsSP;
            return View("Home", dsSP);
        }
        [HttpGet]
        public ActionResult DangNhap()
        {

            return View();
        }
        [HttpPost]
        public ActionResult XLDN(FormCollection co)
        {
            string ten = co["txtTendn"];
            string matkhau = co["txtPass"];
            KHACHHANG kh = data.KHACHHANGs.SingleOrDefault(k => k.TAIKHOAN == ten && k.MATKHAU == matkhau);
            if (kh == null)
            {
                return View();
            }

            Session["khachhang"] = kh;
            return RedirectToAction("Home", "StoreManager");
        }
        public ActionResult DangXuat()
        {
            Session["khachhang"] = null;
            return RedirectToAction("Home", "StoreManager");
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DangKyKH(KHACHHANG kh)
        {
            data.KHACHHANGs.InsertOnSubmit(kh);
            data.SubmitChanges();
            return RedirectToAction("Home");
        }
       
        public ActionResult XemGioHang()
        {
            GioHang gh = (GioHang)Session["gh"];
            return View(gh);
        }
        public ActionResult ThemMatHang(int id)
        {
            GioHang gh = (GioHang)Session["gh"];
            if (gh == null)
            {
                gh = new GioHang();
            }
            gh.Them(id);
            Session["gh"] = gh;

            return RedirectToAction("Home", "StoreManager");

        }
        public ActionResult XoaMatHang(int id)
        {
            GioHang gh = (GioHang)Session["gh"];
            if (gh == null)
            {
                gh = new GioHang();
            }
            gh.Xoa(id);
            Session["gh"] = gh;

            return RedirectToAction("XemGioHang", "StoreManager");

        }
        public ActionResult SuaMatHang(int id,int sl)
        {
            GioHang gh = (GioHang)Session["gh"];
            if (gh == null)
            {
                gh = new GioHang();
            }
            gh.Sua(id,sl);
            Session["gh"] = gh;

            return RedirectToAction("XemGioHang", "StoreManager");

        }
        public ActionResult XoaGioHang()
        {
            GioHang gh = (GioHang)Session["gh"];
            if (gh == null)
            {
                gh = new GioHang();
            }
            gh.XoaGioHang();
            Session["gh"] = gh;

            return RedirectToAction("XemGioHang", "StoreManager");

        }
        public ActionResult Support()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ThemSP()
        {
            return View();
        }
        public ActionResult ChiTietSP(int id)
        {
            SANPHAM s = data.SANPHAMs.FirstOrDefault(t => t.MASP == id);

            return View(s);
        }
        public ActionResult XacNhanDongHang()
        {
            KHACHHANG kh = Session["khachhang"] as KHACHHANG;
            if (kh == null)
            {
                return RedirectToAction("DangNhap", "StoreManager");
            }
            return View(kh);
        }
        [HttpPost]
        public ActionResult LuuDatHang(FormCollection co)
        {
            GioHang gh = (GioHang)Session["gh"];
            KHACHHANG kh = (KHACHHANG)Session["khachhang"];
            if (Session["khachhang"] == null)
                return RedirectToAction("Home", "StoreManager");
            if (Session["gh"] == null || gh.lst.Count == 0)
                return RedirectToAction("XemGioHang", "StoreManager");
            string ngaygiao = co["txtDate"];

            HOADON hd = new HOADON();
            hd.MAKH = kh.MAKH;
            hd.NGAYHD = DateTime.Now;
            data.HOADONs.InsertOnSubmit(hd);
            data.SubmitChanges();
            foreach (CartItem sp in gh.lst)
            {
                CTHOADON ct = new CTHOADON();
                ct.MAHD = hd.MAHD;
                ct.MaSP = sp.iMaSP;
                ct.SoLuong = sp.iSoLuong;
                data.CTHOADONs.InsertOnSubmit(ct);
            }
            data.SubmitChanges();
            gh.XoaGioHang();
            return View();
        }
        [HttpPost]//bắt buộc có để tìm kiếm
        public ActionResult XuLiTK(FormCollection col)
        {
            string tk = col["txtTuKhoa"].ToString();
            
            List<SANPHAM> dsS = data.SANPHAMs.Where(s => s.TENSP.Contains(tk) == true ).ToList();

            return View("Home", dsS);
        }
       
        
    }
}
