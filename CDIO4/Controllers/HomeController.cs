﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CDIO4.Common;
using CDIO4.Dao;
using CDIO4.Models;
using Model;
using Model.EF;

namespace CDIO4.Controllers
{
    
    public class HomeController : Controller
    {
        [HttpGet]
        // GET: Home
        public ActionResult Index()
        {
            var sanpham = new SanPhamDao();
            ViewBag.SanPham = sanpham.ListSpDauGia();
            ViewBag.DanhMuc = new DanhMucSanPhamDao().ListSpDauGia();

            return View();
        }
      
        public ActionResult Logout()
        {
            Session[Common.CommonStants.USER_SESSION] = null;
            return Redirect("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            var dao = new UserDao();
            var result = dao.Login(model.TenDangNhap, model.MatKhau , true);

            if (result == 1)
            {
                var user = dao.GetbyUserName(model.TenDangNhap);
                var userSession = new UserLogin();
                userSession.TenDangNhap = user.TenDangNhap;
                Session.Add(Common.CommonStants.USER_SESSION, userSession);
                return Redirect("/");
            }
            else if (result == 0)
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại");
            }
            else if (result == -1)
            {
                ModelState.AddModelError("", "Tài khoản đang bị khóa");
            } else if (result == -2)
            {
                ModelState.AddModelError("", "Mật khẩu không đúng");
            } else if (result == 2)
            {
                var user = dao.GetbyUserName(model.TenDangNhap);
                var userSession = new UserLogin();
                userSession.TenDangNhap = user.TenDangNhap;
                Session.Add(Common.CommonStants.USER_SESSION, userSession);
                return Redirect("/Admin/Admin/Index");
            }
            
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registry(string tendn, string matkhau, string hoten, string diachi, string email, int sdt)
        {
            var dao = new TaiKhoanModel();
            var check = new UserDao();

            if (check.CheckTenDn(tendn))
            {
                ViewBag.TenDn = "Đăng ký không thành công. Tên đăng nhập đã tồn tại";
            }
            else if (check.CheckEmail(email))
            {
                ViewBag.Email = "Đăng ký không thành công. Email đã tồn tại";
            }
            else
            {
                int result = dao.Registry(tendn, matkhau, hoten, diachi, email, sdt);
                if (result > 0)
                {
                    ViewBag.Sucess = "Đăng ký thành công";
                }
                else
                {
                    ViewBag.Failure = "Đăng ký thất bại";
                }
            }

            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UpdateStatus();
                int result = dao.Update(model.IDSanPham);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
            }

            return View("Index");
        }       

        [ChildActionOnly]
        public PartialViewResult ThongBao()
        {
            var cartItem = Session[Common.CommonStants.CartSession];
            var list = new List<CartModel>();
            if (cartItem != null)
            {
                list = (List<CartModel>)cartItem;
            }

            return PartialView(list);
        }
       
    }
}