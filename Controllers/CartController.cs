using Kitchen_Appliances.Helpers;
using Kitchen_Appliances.Infrastructure;
using Kitchen_Appliances.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen_Appliances.Controllers
{
    public class CartController : Controller
    {
        private IStoreRepository repository;
        public CartController(IStoreRepository repo)
        {
            repository = repo;
        }

        public Itemcart Itemcart { get; set; }

        public IActionResult AddToCart(long ProductID)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == ProductID);
            Itemcart = HttpContext.Session.GetJson<Itemcart>("cart") ?? new Itemcart();
            Itemcart.AddItem(product , 1);
            HttpContext.Session.SetJson("cart", Itemcart);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult DeleteToCart(long ProductID)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == ProductID);
            Itemcart = HttpContext.Session.GetJson<Itemcart>("cart") ?? new Itemcart();
            Itemcart.DeleteAItem(product,1);
            HttpContext.Session.SetJson("cart", Itemcart);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult RemoveToCart(long ProductID)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == ProductID);
            Itemcart = HttpContext.Session.GetJson<Itemcart>("cart") ?? new Itemcart();
            Itemcart.RemoveItem(product);
            HttpContext.Session.SetJson("cart", Itemcart);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
