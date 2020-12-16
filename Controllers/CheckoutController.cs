using Kitchen_Appliances.Helpers;
using Kitchen_Appliances.Infrastructure;
using Kitchen_Appliances.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Kitchen_Appliances.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            Itemcart Items = HttpContext.Session.GetJson<Itemcart>("cart");
            return View(Items);
        }
    }
}
