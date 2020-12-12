using Kitchen_Appliances.Models;
using Kitchen_Appliances.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen_Appliances.Component
{
    public class ItemproductHomeViewComponent : ViewComponent
    {
        private readonly IStoreRepository repository;
        public int PageSize = 6;

        public ItemproductHomeViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke(string category, int productPage)
        {
            ProductsListViewModel productsList = new ProductsListViewModel { };
            //if (category == null)
            //{
            //    productsList = new ProductsListViewModel
            //    {
            //        Products = repository.Products
            //        .OrderBy(d => d.ProductID)
            //        .Skip((productPage - 1) * PageSize)
            //        .Take(PageSize)
            //    };
            //}
            //else
            //{
                productsList = new ProductsListViewModel
                {
                    Products = repository.Products
                    .Where(d => category==null || d.Category.CategoryName == category)
                    .OrderBy(d => d.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize)
                };
            //}
            return View(productsList);
        }
    }
}
