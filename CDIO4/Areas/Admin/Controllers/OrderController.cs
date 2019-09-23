using CDIO4.Areas.Admin.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDIO4.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public ActionResult Index()
        {
            ViewBag.DsOrder = new OrderDao().DsOrder();

            return View();
        }

        public ActionResult Detail(int id)
        {          
            ViewBag.Detail = new OrderDao().DsDetail(id);
            ViewBag.Sum = new OrderDao().Sum(id);

            return View();
        }
    }
}