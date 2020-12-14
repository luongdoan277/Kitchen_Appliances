using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kitchen_Appliances.Models;

namespace Kitchen_Appliances.Component
{
    public class FeatureProductViewComponent : ViewComponent
    {
        private IStoreRepository  repository;

        public FeatureProductViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
