using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreManager.Models;
namespace StoreManager.Controllers
{
    public class QLHOADONController : Controller
    {
        //
        // GET: /QLHOADON/
        QL_QUANAODataContext data = new QL_QUANAODataContext();
        public ActionResult QLHangHoa()
        {
            NHANVIEN nv = Session["nhanvien"] as NHANVIEN;
            if (nv == null)
            {
                return RedirectToAction("DangNhapNV", "QLSanPham");
            }
            List<HOADON> dshd = data.HOADONs.ToList();
            return View(dshd);
        }
        public ActionResult ThongKe(int mhd)
        {
            List<CTHOADON> dsct = data.CTHOADONs.Where(c => c.MAHD == mhd).ToList();

            var thanhtien = dsct.Sum(ct => ct.SoLuong * ct.SANPHAM.GIABAN);
            ViewBag.tt = thanhtien;
            return PartialView(dsct);

        }
        public ActionResult LietKe(int mhd)
        {
            List<CTHOADON> dsct = data.CTHOADONs.Where(c => c.MAHD == mhd).ToList();

            return PartialView(dsct);
        }
        [HttpPost]
        public ActionResult CapNhatGiaoHang(FormCollection c)
        {
            int n = int.Parse(c["tong"]);
            for (int i = 1; i <= n; i++)
            {
                string tenck = i.ToString();
                if (c[tenck] != null)// dc chọn 0k
                {
                    // cap nhat tinh trang giao hang
                    int mhd = int.Parse(c[tenck]);
                    HOADON hd = data.HOADONs.SingleOrDefault(d => d.MAHD == mhd);
                    hd.NgayThanhToan = DateTime.Now;

                    UpdateModel(hd);
                    data.SubmitChanges();
                }
            }
            return RedirectToAction("QLHangHoa", "QLHOADON");
        }

    }
}
