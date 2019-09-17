using CDIO4.Dao;
using CDIO4.Models;
using Model;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDIO4.Controllers
{
    public class ProductController : Controller
    {
        AuctionOnlineDbContext db = new AuctionOnlineDbContext();
        // GET: Product
        public ActionResult Detail(long id)
        {          
            var product = new SanPhamDao().ViewDetail(id);
            ViewBag.SanPhamLienQuan = new SanPhamDao().ListSpLienquan(id);
            ViewBag.List = new BiddingDao().ListBidding(id);
            ViewBag.BidTop = new BiddingDao().BiddTop(id);
            return View(product);
        }

        public ActionResult Bidding(long tien, long id, string ten)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhienDauGiaModel();
                int result = dao.Update_Bidding(tien, id, ten);               
            }

            return Redirect("Detail/"+id);
        }


    }
}