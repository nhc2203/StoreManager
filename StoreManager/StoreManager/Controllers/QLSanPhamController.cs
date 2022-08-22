using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreManager.Models;
namespace StoreManager.Controllers
{
    public class QLSanPhamController : Controller
    {
        //
        // GET: /QLSanPham/
        QL_QUANAODataContext data = new QL_QUANAODataContext();
        public ActionResult QLSanPham()
        {
            NHANVIEN nv = Session["nhanvien"] as NHANVIEN;
            if (nv == null)
            {
                return RedirectToAction("DangNhapNV", "QLSanPham");
            }
            List<SANPHAM> dssp = data.SANPHAMs.ToList();
            return View(dssp);
        }
        [HttpGet]
        public ActionResult Themmoisp()
        {
       
            return View();
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Them(SANPHAM s, HttpPostedFileBase upHinh)
        {
            s.HINH = upHinh.FileName;
            upHinh.SaveAs(Server.MapPath("/Content/Hinh" + upHinh.FileName));
            data.SANPHAMs.InsertOnSubmit(s);
            data.SubmitChanges();
            return RedirectToAction("QLSanPham");
        }
        [HttpGet]
       
        public ActionResult Suasp(int masp)
        {
            SANPHAM sp = data.SANPHAMs.SingleOrDefault(n => n.MASP == masp);
           
            return View(sp);
        }
        public ActionResult Chitietsp(int id)
        {
            SANPHAM sp = data.SANPHAMs.SingleOrDefault(n => n.MASP == id);
            ViewBag.MASP = sp.MASP;
            if(sp==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }
        [HttpGet]
        public ActionResult Xoasp(int id)
        {
            SANPHAM sp = data.SANPHAMs.SingleOrDefault(n => n.MASP == id);
            ViewBag.MASP = sp.MASP;
            
            return View(sp);
        }
        [HttpPost, ActionName("Xoasp")]
        public ActionResult XacNhanXoa(int id)
        {
            SANPHAM sp = data.SANPHAMs.SingleOrDefault(n => n.MASP == id);
            ViewBag.MASP = sp.MASP;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.SANPHAMs.DeleteOnSubmit(sp);
            data.SubmitChanges();
            return View(sp);
        }
        [HttpGet]
        public ActionResult DangNhapNV()
        {

            return View();
        }
        [HttpPost]
        public ActionResult XLDNNV(FormCollection co)
        {
            string ten = co["txtTendnn"];
            string matkhau = co["txtPasss"];
            NHANVIEN kh = data.NHANVIENs.SingleOrDefault(k => k.TAIKHOAN == ten && k.MATKHAU == matkhau);
            if (kh == null)
            {
                return View();
            }

            Session["nhanvien"] = kh;
            return RedirectToAction("Home", "StoreManager");
        }
        public ActionResult DangXuatNV()
        {
            Session["nhanvien"] = null;
            return RedirectToAction("Home", "StoreManager");
        }
    }
}
