using CDIO4.Areas.Admin.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDIO4.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            ViewBag.ListProduct = new ProductDao().ListProduct();

            return View();
        }

        [HttpGet]
        public ActionResult AddItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddItem(string tensp, string mota, DateTime handaugia, int giadukien, int danhmuc, string hinhanh)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();

                var res = dao.AddItem(tensp, mota, handaugia, giadukien, danhmuc, hinhanh);
                if (res > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thành công");
                }
            }

            return View("Index");
        }
     
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = new ProductDao().GetByID(id);

            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(int id, string tensp, string mota, DateTime handaugia, int giadukien, int danhmuc, string hinhanh)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();

                var res = dao.Update(id, tensp, mota, handaugia, giadukien, danhmuc, hinhanh);
                if (res)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);

            return RedirectToAction("Index");
        }
    }
}