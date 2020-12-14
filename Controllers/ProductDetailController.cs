using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen_Appliances.Models;
using Kitchen_Appliances.Models.ViewModels;

namespace Kitchen_Appliances.Controllers
{
    public class ProductDetailController : Controller
    {

        private IStoreRepository repository;

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult DetailProduct(int id)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                 .Where(p => p.ProductID == id),

            });
    }
}
