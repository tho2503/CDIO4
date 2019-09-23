using CDIO4.Areas.Admin.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDIO4.Areas.Admin.Controllers
{
    public class BiddController : Controller
    {
        // GET: Admin/Bidd
        public ActionResult Index()
        {
            ViewBag.DsBidd = new BiddDao().DsPhienDauGia();

            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new BiddDao().Delete(id);

            return RedirectToAction("Index");
        }
    }
}