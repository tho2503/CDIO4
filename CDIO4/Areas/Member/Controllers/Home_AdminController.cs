using CDIO4.Areas.Member.Models;
using CDIO4.Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDIO4.Areas.Member.Controllers
{
    public class Home_AdminController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(DangNhapModel model)
        {
            var dao = new TaiKhoanModel();
            var result = dao.Login(model.TenDangNhap, model.MatKhau);
            if (result)
            {
                var user = dao.GetByName(model.TenDangNhap);
                var userSession = new UserLogin();
                userSession.TenDangNhap = user.TenDangNhap;
                Session.Add(Common.CommonStants.USER_SESSION, userSession);
                return RedirectToAction("Index", "Home_Admin");
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập thất bại");
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session[Common.CommonStants.USER_SESSION] = null;
            return Redirect("Index");
        }
    }
}