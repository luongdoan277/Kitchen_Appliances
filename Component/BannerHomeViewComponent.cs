using Kitchen_Appliances.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen_Appliances.Component
{
    public class BannerHomeViewComponent : ViewComponent
    {
        private IStoreRepository repository;

        public BannerHomeViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
