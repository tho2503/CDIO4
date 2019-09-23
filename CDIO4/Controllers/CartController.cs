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
            ViewBag.DanhMuc = new DanhMucSanPhamDao().ListSpDauGia();

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

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartModel>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ID_SanPham == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        [HttpGet]
        public ActionResult Payment()
        {
            ViewBag.DanhMuc = new DanhMucSanPhamDao().ListSpDauGia();
            var cart = Session[CartSession];
            var list = new List<CartModel>();
            if(cart != null)
            {
                list = (List<CartModel>)cart;
            }

            return View(list);
        }
        public ActionResult Payment(string tendg, string ten, string sdt, string diachi, string email)
        {
            ViewBag.DanhMuc = new DanhMucSanPhamDao().ListSpDauGia();

            try
            {
                var hd = new HoaDon();
                hd.NgayTao = DateTime.Now;
                hd.TenDN = tendg;
                hd.Ten_Ship = ten;
                hd.SDT = sdt;
                hd.DiaChi = diachi;
                hd.Email = email;
                var id = new HoaDonDao().Insert(hd);
                var cart = (List<CartModel>)Session[CartSession];
                var hdct = new HoaDonChiTietDao();
                foreach (var item in cart)
                {
                    var detail_hd = new HoaDon_ChiTiet();
                    detail_hd.ID_SanPham = item.Product.ID_SanPham;
                    detail_hd.ID_HoaDon = id;
                    detail_hd.Gia = (item.Product.GiaBanRa / 10) + item.Product.GiaBanRa;
                    detail_hd.SoLuong = item.SoLuong;
                    hdct.Insert(detail_hd);
                }
            }
            catch
            {
                return Redirect("/Cart/failure");
            }                       
            return Redirect("/Cart/Finish");
        }

        public ActionResult Finish()
        {
            ViewBag.DanhMuc = new DanhMucSanPhamDao().ListSpDauGia();

            return View();
        }
    }
}