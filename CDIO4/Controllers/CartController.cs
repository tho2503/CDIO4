using CDIO4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using CDIO4.Dao;

namespace CDIO4.Controllers
{
    public class CartController : Controller
    {
        private string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartModel>();
            
            if (cart != null)
            {
                list = (List<CartModel>)cart;
            }

            return View(list);
        }

        public ActionResult AddItem(int id, int soluong)
        {
            var product = new SanPhamDao().ViewDetail(id);
            var cart = Session[CartSession];
            ViewBag.BidTop = new BiddingDao().BiddTop(id);
            if (cart != null)
            {
                var list = (List<CartModel>)cart;
                if (list.Exists(x => x.Product.ID_SanPham == id))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID_SanPham == id)
                        {
                            item.SoLuong += soluong;
                        }
                    }
                }
                else
                {
                    var item = new CartModel();
                    item.Product = product;
                    item.SoLuong = soluong;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                //Tạo mới đối tượng cart model
                var item = new CartModel();
                item.Product = product;
                item.SoLuong = soluong;
                var list = new List<CartModel>();
                list.Add(item);

                //Gán vào session
                Session[CartSession] = list;
            }

            return RedirectToAction("Index");
        }
    }
}