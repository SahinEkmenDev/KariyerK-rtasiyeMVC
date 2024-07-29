using KariyerKırtasiye.MvcWebUi.Entity;
using KariyerKırtasiye.MvcWebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerKırtasiye.MvcWebUi.Controllers
{
    public class CartController : Controller
    {

        private DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);

            if (product !=null) 
            { 
                GetCart().AddProduct(product,1);

            }

            return RedirectToAction("Index");

        }

        public ActionResult RemoveFromToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);

            if (product != null)
            {
                GetCart().DeleteProduct(product);

            }

            return RedirectToAction("Index");

        }
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;

            }
            return cart;
        }
    }
}