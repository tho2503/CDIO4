using CDIO4.Areas.Admin.Dao;
using CDIO4.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDIO4.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Edit(string tendn)
        {
            var user = new UserDao().GetbyUserName(tendn);
            ViewBag.DanhMuc = new DanhMucSanPhamDao().ListSpDauGia();

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string tendn, string matkhau, string hoten, string diachi, string email, int sdt)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                var res = dao.Update(tendn, matkhau, hoten, diachi, email, sdt);
                if (res)
                {
                    return RedirectToAction("Edit", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa thành công");
                }
            }
            return View("Edit");
        }
    }
}