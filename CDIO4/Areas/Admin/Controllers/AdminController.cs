using CDIO4.Areas.Admin.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDIO4.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.DsBidd = new AdminDao().DsBidd();
            ViewBag.DsSP = new AdminDao().DsSP();
            ViewBag.DsHD = new AdminDao().DsHD();
            ViewBag.DsTK = new AdminDao().DsTaiKhoan();
            
            //Thống kê phiên đấu giá
            ViewBag.CountBiddT1 = new AdminDao().DsBiddT1();
            ViewBag.CountBiddT2 = new AdminDao().DsBiddT2();
            ViewBag.CountBiddT3 = new AdminDao().DsBiddT3();
            ViewBag.CountBiddT4 = new AdminDao().DsBiddT4();
            ViewBag.CountBiddT5 = new AdminDao().DsBiddT5();
            ViewBag.CountBiddT6 = new AdminDao().DsBiddT6();
            ViewBag.CountBiddT7 = new AdminDao().DsBiddT7();
            ViewBag.CountBiddT8 = new AdminDao().DsBiddT8();
            ViewBag.CountBiddT9 = new AdminDao().DsBiddT9();
            ViewBag.CountBiddT10 = new AdminDao().DsBiddT10();
            ViewBag.CountBiddT11 = new AdminDao().DsBiddT11();
            ViewBag.CountBiddT12 = new AdminDao().DsBiddT12();

            //Thống kê doanh thu
            ViewBag.DoanhThuT1 = new AdminDao().DoanhThuT1();
            ViewBag.DoanhThuT2 = new AdminDao().DoanhThuT2();
            ViewBag.DoanhThuT3 = new AdminDao().DoanhThuT3();
            ViewBag.DoanhThuT4 = new AdminDao().DoanhThuT4();
            ViewBag.DoanhThuT5 = new AdminDao().DoanhThuT5();
            ViewBag.DoanhThuT6 = new AdminDao().DoanhThuT6();
            ViewBag.DoanhThuT7 = new AdminDao().DoanhThuT7();
            ViewBag.DoanhThuT8 = new AdminDao().DoanhThuT8();
            ViewBag.DoanhThuT9 = new AdminDao().DoanhThuT9();
            ViewBag.DoanhThuT10 = new AdminDao().DoanhThuT10();
            ViewBag.DoanhThuT11 = new AdminDao().DoanhThuT11();
            ViewBag.DoanhThuT12 = new AdminDao().DoanhThuT12();

            //Sản phẩm theo doanh mục
            ViewBag.SpMuc1 = new AdminDao().SpMuc1();
            ViewBag.SpMuc2 = new AdminDao().SpMuc2();
            ViewBag.SpMuc3 = new AdminDao().SpMuc3();
            ViewBag.SpMuc4 = new AdminDao().SpMuc4();
            ViewBag.SpMuc5 = new AdminDao().SpMuc5();
            ViewBag.SpMuc6 = new AdminDao().SpMuc6();
            ViewBag.SpMuc7 = new AdminDao().SpMuc7();
            ViewBag.SpMuc8 = new AdminDao().SpMuc8();
            ViewBag.SpMuc9 = new AdminDao().SpMuc9();
            ViewBag.SpMuc10 = new AdminDao().SpMuc10();

            return View();
        }

        public ActionResult Logout()
        {
            Session[Common.CommonStants.USER_SESSION] = null;
            return Redirect("/Home/Index");
        }
    }
}