using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen_Appliances.Models;
using Kitchen_Appliances.Models.ViewModels;

namespace Kitchen_Appliances.Controllers
{
    public class ProductController : Controller
    {

        private IStoreRepository repository;

        public ProductController(IStoreRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(int ProductID)
        {
            return View(new ProductsListViewModel
            {
                Products = repository.Products
                 .Where(p => p.ProductID == ProductID),
            });
        }
    }
    
}
