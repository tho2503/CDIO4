using CDIO4.Areas.Member.Codes;
using CDIO4.Areas.Member.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDIO4.Areas.Member.Controllers
{
    public class HomeController : Controller
    {
        // GET: Member/Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DangNhapModel model)
        {
            var result = new TaiKhoanModel().Login(model.TenDangNhap, model.MatKhau);
            if (result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { TenDangNhap = model.TenDangNhap });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");              
            }

            return View(model);
        }
    }
}