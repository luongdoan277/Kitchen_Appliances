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

    public class AdminController : Controller
    {
        private readonly IStoreRepository repository;

        public int PageSize = 4;

        public AdminController(IStoreRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View();
        }


        //public IActionResult AdminProduct()
        //{
        //    return View();
        //}

        //public IActionResult AdminProduct(int productPage = 1)
        //    => View(repository.Products
        //        .OrderBy(p => p.ProductID)
        //        .Skip((productPage - 1) * PageSize)
        //        .Take(PageSize)
        //        );



        //public IActionResult Index() => View(repository.Products);

        public IActionResult AdminProduct(string category ,int productPage = 1)
        {
            ProductsListViewModel productsList = new ProductsListViewModel
            {
                Products = repository.Products
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

            return View("AdminProduct", productsList);
        }

       // public IActionResult AdminProduct(int productPage = 1)
       //=> View(new ProductsListViewModel
       //{
       //    Products = repository.Products
       //        .OrderBy(p => p.ProductID)
       //        .Skip((productPage - 1) * PageSize)
       //        .Take(PageSize),

       //    PagingInfo = new PagingInfo
       //    {
       //        CurrentPage = productPage,
       //        ItemsPerPage = PageSize,

       //        TotalItems = repository.Products.Count()
       //    }
       //});

    }
}
