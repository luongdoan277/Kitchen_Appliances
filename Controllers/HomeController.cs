using Kitchen_Appliances.Component;
using Kitchen_Appliances.Models;
using Kitchen_Appliances.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen_Appliances.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreRepository repository;
        public int PageSize = 6;

        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index(string category, int productPage = 1)
        {
            ProductsListViewModel productsList = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(d => category == null || d.Categories.CategoryName == category)
                .OrderBy(d => d.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                Categories = repository.Categories.OrderBy(d => d.CategoryID),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(
                        e => e.Categories.CategoryName == category).Count()
                },
                CurrentCategory = category
            };
            return View(productsList);
        }


        //public ViewResult Detail(int id)
        //    => View(new ProductsListViewModel
        //    {
        //        Products = repository.Products
        //         .Where(p => p.ProductID == id),

        //    });


        public IActionResult Privacy()
        {
            return View();
        }
    }
}
