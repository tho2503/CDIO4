using CDIO4.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDIO4.Controllers
{
    public class MyBiddingController : Controller
    {
        // GET: MyBidding
        public ActionResult Index(string ten)
        {
            ViewBag.LichSuDG = new BiddingDao().DsDangDauGiaThang(ten);
            ViewBag.DSThang = new SanPhamDao().DsDangDauGia(ten);
            ViewBag.DSDangDG = new SanPhamDao().DsDauGiaThang(ten);

            return View();
        }
    }
}