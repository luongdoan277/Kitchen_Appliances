using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen_Appliances.Infrastructure;
using Kitchen_Appliances.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kitchen_Appliances.Pages
{
    public class CartModel : PageModel
    {
        private IStoreRepository repository;
        public CartModel(IStoreRepository repo)
        {
            repository = repo;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long ProductID, string returnUrl)
        {
            Product drink = repository.Products
                .FirstOrDefault(p => p.ProductID == ProductID);
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(drink, 1);
            HttpContext.Session.SetJson("cart", Cart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
