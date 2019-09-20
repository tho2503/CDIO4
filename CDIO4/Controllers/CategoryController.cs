using CDIO4.Dao;
using CDIO4.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDIO4.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(string tendanhmuc)
        {
            ViewBag.Sp_DanhMuc = new SanPhamDao().DsTheoDanhMuc(tendanhmuc);
            ViewBag.DanhMuc = new DanhMucSanPhamDao().ListSpDauGia();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, string tendm)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.UpdateStatus();
                int result = dao.Update(id);
                if (result > 0)
                {
                    return Redirect("/Category/Index?tendanhmuc="+tendm);
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
            }

            return View("Index");
        }
    }
}