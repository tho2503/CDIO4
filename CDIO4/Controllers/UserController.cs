using CDIO4.Common;
using CDIO4.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDIO4.Controllers
{
    public class UserController : Controller
    {
        // GET: Login
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            var dao = new TaiKhoanModel();
            var result = dao.Login(model.TenDangNhap, model.MatKhau);
            if (result)
            {
                var user = dao.GetByName(model.TenDangNhap);
                var userSession = new UserLogin();
                userSession.TenDangNhap = user.TenDangNhap;
                Session.Add(Common.CommonStants.USER_SESSION, userSession);
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập thất bại");
            }
            return View("Index");
        }
    }
}