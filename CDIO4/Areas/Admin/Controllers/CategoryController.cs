using CDIO4.Areas.Admin.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDIO4.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            ViewBag.DsDanhMuc = new CategoryDao().DsDanhMuc();

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DanhMuc cate)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();

                var res = dao.Insert(cate);
                if (res > 0)
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cate = new CategoryDao().GetByID(id);

            return View(cate);
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