using Kitchen_Appliances.Helpers;
using Kitchen_Appliances.Infrastructure;
using Kitchen_Appliances.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen_Appliances.Component
{
    public class CartListViewComponent : ViewComponent
    {
        private IStoreRepository repository;

        public CartListViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            Itemcart Items = HttpContext.Session.GetJson<Itemcart>("cart");
            return View(Items);
        }
    }
}
