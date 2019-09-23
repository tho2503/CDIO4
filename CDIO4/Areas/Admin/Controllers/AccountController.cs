using CDIO4.Areas.Admin.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDIO4.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        public ActionResult Index()
        {
            ViewBag.DsTaiKhoan = new TaiKhoanDao().DsTaiKhoan();

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TaiKhoan acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDao();

                var res = dao.Insert(acc);
                if(res != null)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("","Thêm thành công");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(string tendn)
        {
            var acc = new TaiKhoanDao().GetByUserName(tendn);

            return View(acc);
        }
        [HttpPost]
        public ActionResult Edit(TaiKhoan acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDao();

                var res = dao.Update(acc);
                if (res)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(string tendn)
        {
            new TaiKhoanDao().Delete(tendn);

            return RedirectToAction("Index");
        }
    }
}