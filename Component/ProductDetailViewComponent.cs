using Kitchen_Appliances.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen_Appliances.Component
{
    public class ProductDetailViewComponent : ViewComponent
    {
        private IStoreRepository repository;

        public ProductDetailViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke(Product product)
        {
            return View(product);
        }
    }
}
